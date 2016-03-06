using System.Collections.ObjectModel;
using System.Linq;

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