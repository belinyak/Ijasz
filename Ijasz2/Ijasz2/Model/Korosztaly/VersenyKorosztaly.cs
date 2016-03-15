using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Ijasz2.Megjelenites.Korosztaly;

namespace Ijasz2.Model.Korosztaly {
    public class VersenyKorosztaly {
        public ObservableCollection<Korosztaly> Korosztalyok { get; set; }
        public string VersenyAzonosito { get; set; }

        public VersenyKorosztaly( ) {
        }

        public VersenyKorosztaly( string versenyAzonosito ) {
            VersenyAzonosito = versenyAzonosito;
            Korosztalyok = new ObservableCollection<Korosztaly>( );
        }

        /// <summary> | 
        /// TODO nem megjelent bele számít-e ??? | 
        /// felülírttal nem foglalkozunk
        /// </summary>
        /// <param name="versenyAzonosito"></param>
        public void KorosztalySzamolas( string versenyAzonosito ) {
            // mivel ujraszamolom ki kell nullazni
            // itt nem kell db update, ugyis lesz a vegen
            foreach( var korosztaly in Korosztalyok ) {
                korosztaly.InduloFerfiak = 0;
                korosztaly.InduloNok = 0;
            }

            // indulokat localba, mert nem modositom, így lehet torolni, gyorsul a kereses
            var localIndulok = Data.Data.Indulok._indulok.ToList();

            foreach( var versenyEredmenyek in Data.Data.Eredmenyek._versenyEredmenyek.Where( eredmeny => eredmeny.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                foreach( var eredmeny in versenyEredmenyek.Eredmenyek._eredmenyek.Where( eredmeny => eredmeny.Megjelent.Equals( true ) ) ) {
                    var indulo = (from indulo2 in localIndulok
                                  where indulo2.Nev.Equals(eredmeny.Indulo)
                                  select indulo2).First();
                    localIndulok.Remove( indulo );

                    if( eredmeny.KorosztalyModositott.Equals( false ) ) {

                        foreach( var korosztaly in Korosztalyok ) {
                            if( indulo.Nem.ToLower( ).Equals( "f" ) && korosztaly.Ferfiakra.Equals( true ) &&
                                ( korosztaly.AlsoHatar <= eredmeny.Kor && eredmeny.Kor <= korosztaly.FelsoHatar ) ) {
                                korosztaly.InduloFerfiak += 1;
                                eredmeny.KorosztalyAzonosito = korosztaly.Azonosito;
                            }
                            else if( indulo.Nem.ToLower( ).Equals( "n" ) && korosztaly.Nokre.Equals( true ) &&
                                 ( korosztaly.AlsoHatar <= eredmeny.Kor && eredmeny.Kor <= korosztaly.FelsoHatar ) ) {
                                korosztaly.InduloNok += 1;
                                eredmeny.KorosztalyAzonosito = korosztaly.Azonosito;
                            }
                        }

                    }
                    else if( eredmeny.KorosztalyModositott.Equals( true ) ) {
                        foreach( var korosztaly in Korosztalyok.Where( korosztaly => korosztaly.Azonosito.Equals( eredmeny.KorosztalyAzonosito ) ) ) {
                            if( indulo.Nem.ToLower( ).Equals( "f" ) ) {
                                korosztaly.InduloFerfiak += 1;
                            }
                            else if( indulo.Nem.ToLower( ).Equals( "n" ) ) {
                                korosztaly.InduloNok += 1;
                            }
                        }
                    }
                }

                Adatbazis.Korosztaly.Korosztaly.KorosztalySzamolas_EredmenyUpdate( versenyEredmenyek );
            }
            Adatbazis.Korosztaly.Korosztaly.KorosztalySzamolas_IndulokSzamaUpdate( Korosztalyok );
        }

        /// <summary>
        /// | mindig visszaadja az ajanlott korosztalyt |
        /// ha a versenysorozat, valamelyik versenyen felul volt irva, akkor message-ben visszaadja |
        /// </summary>
        /// <param name="indulo"></param>
        /// <param name="verseny"></param>
        /// <returns></returns>
        public static KorosztalyInfo InduloBeirasKorosztaly( Model.Indulo.Indulo indulo, Model.Verseny.Verseny verseny ) {
            string datum = "";
            var value = new KorosztalyInfo();

            if( string.IsNullOrEmpty( verseny.Versenysorozat ) ) {
                datum = verseny.Datum;
            }
            else {
                datum = ( from verseny1 in Model.Data.Data.Versenyek._versenyek
                          where verseny1.Versenysorozat.Equals( verseny.Versenysorozat )
                          orderby verseny1.Datum ascending
                          select verseny1.Datum ).First( );

                // versenysorozat minden indulohoz tartozo eredmenye
                foreach( var verseny1 in Model.Data.Data.Versenyek._versenyek.Where( verseny1 => verseny1.Versenysorozat.Equals( verseny.Versenysorozat ) ) ) {
                    foreach( var versenyeredmeny in Model.Data.Data.Eredmenyek._versenyEredmenyek.Where( eredmeny => eredmeny.VersenyAzonosito.Equals( verseny1.Azonosito ) ) ) {
                        foreach( var eredmeny in versenyeredmeny.Eredmenyek._eredmenyek.Where( eredmeny => eredmeny.Indulo.Equals( indulo.Nev ) ) ) {
                            // ha volt korosztalymodositas, akkor az üzenetekhez hozzaadjuk
                            if( eredmeny.KorosztalyModositott.Equals( true ) ) {
                                if( value.KorosztalyMessages == null ) {
                                    value.KorosztalyMessages = new List<KorosztalyMessage>( );
                                }
                                value.KorosztalyMessages.Add( new KorosztalyMessage {
                                    KorosztalyAzonosito = eredmeny.KorosztalyAzonosito,
                                    VersenyAzonosito = verseny1.Azonosito,
                                    VersenysorozatAzonosito = verseny.Versenysorozat
                                } );
                            }
                            // ha mar van eredmenye a versenyen, amire beirjuk, akkor az ajanlott korosztalyazonosito megvan
                            if( eredmeny.Verseny.Equals( verseny.Azonosito ) ) {
                                value.KorosztalyAzonosito = eredmeny.KorosztalyAzonosito;
                            }
                        }
                    }
                }
                // ha nem null, akkor olyan versenyre irjuk, be ahol volt már beíva, nem kell továbbmenni
                if( !string.IsNullOrEmpty( value.KorosztalyAzonosito ) ) {
                    return value;
                }
            }

            // itt akkkor vagyunk, ha nincs versenysorozat, vagy nem volt még beírva a versenyre
            var kor = Data.Data.Korosztalyok.BetoltottKor(datum, indulo.SzuletesiDatum);

            // verseny korosztalyaibol kikeressuk, azt amelyikbe tartozik
            foreach( var versenykorosztalyok in Model.Data.Data.Korosztalyok._versenyKorosztalyok.Where( korosztaly => korosztaly.VersenyAzonosito.Equals( verseny.Azonosito ) ) ) {
                foreach( var korosztaly in versenykorosztalyok.Korosztalyok ) {
                    if( indulo.Nem.ToLower( ).Equals( "f" ) && korosztaly.Ferfiakra.Equals( true ) ) {
                        if( korosztaly.AlsoHatar <= kor && kor <= korosztaly.FelsoHatar ) {
                            value.KorosztalyAzonosito = korosztaly.Azonosito;
                            return value;
                        }
                    }
                    else if( indulo.Nem.ToLower( ).Equals( "n" ) && korosztaly.Nokre.Equals( true ) ) {
                        if( korosztaly.AlsoHatar <= kor && kor <= korosztaly.FelsoHatar ) {
                            value.KorosztalyAzonosito = korosztaly.Azonosito;
                            return value;
                        }
                    }
                }
            }
            // TODO ide nam szabadna eljutni
            //throw new Exception( );
            return value;
        }

        /// <summary> |
        /// adatbazis torles |
        /// model torles |
        /// </summary>
        /// <param name="korosztaly"></param>
        public void Remove( Korosztaly korosztaly ) {
            Korosztalyok.Remove( korosztaly );
            Adatbazis.Korosztaly.Korosztaly.Remove( korosztaly );
        }

        /// <summary> |
        /// adatbazis hozzaadas |
        /// model hozzaadas |
        /// TODO rendezes
        /// </summary>
        /// <param name="korosztaly"></param>
        public void Add( Korosztaly korosztaly ) {
            Korosztalyok.Add( korosztaly );
            Adatbazis.Korosztaly.Korosztaly.Add( korosztaly );

        }
    }
}