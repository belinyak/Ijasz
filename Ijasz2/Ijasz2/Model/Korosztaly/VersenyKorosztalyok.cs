using System;
using System.Collections.Generic;
using System.Linq;

namespace Ijasz2.Model.Korosztaly {
    /// <summary>
    ///     |
    ///     verseny szintu |
    /// </summary>
    public class VersenyKorosztalyok {
        public List<VersenyKorosztaly> _versenyKorosztalyok;

        /// <summary>
        ///     |
        ///     uj verseny letrehozasakor |
        /// </summary>
        /// <param name="versenyKorosztaly"></param>
        public void Add( VersenyKorosztaly versenyKorosztaly ) {
            _versenyKorosztalyok.Add( versenyKorosztaly );
        }

        /// <summary>
        ///     |
        ///     verseny torlesekor |
        /// </summary>
        /// <param name="versenyKorosztaly"></param>
        public void Remove( VersenyKorosztaly versenyKorosztaly ) {
            _versenyKorosztalyok.Remove( versenyKorosztaly );
        }

        /// <summary>
        ///     |
        ///     korosztalyok betoltese adatbazisbol |
        /// </summary>
        public void Load( ) {
            _versenyKorosztalyok = Adatbazis.Korosztaly.Korosztaly.Load( );
        }

        /// <summary> |
        /// model update |
        /// adatbazis update | 
        /// </summary>
        /// <param name="korosztaly"></param>
        public void Update( Korosztaly korosztaly ) {
            foreach( var versenyKorosztaly in _versenyKorosztalyok.Where( versenyKorosztaly => versenyKorosztaly.VersenyAzonosito.Equals( korosztaly.Verseny ) ) ) {
                foreach( var korosztaly1 in versenyKorosztaly.Korosztalyok ) {
                    if( korosztaly1.Azonosito.Equals( korosztaly.Azonosito ) ) {
                        korosztaly1.Megnevezes = korosztaly.Megnevezes;
                        korosztaly1.AlsoHatar = korosztaly.AlsoHatar;
                        korosztaly1.FelsoHatar = korosztaly.FelsoHatar;
                        korosztaly1.Nokre = korosztaly.Nokre;
                        korosztaly1.Ferfiakra = korosztaly.Ferfiakra;
                        korosztaly1.InduloNok = korosztaly.InduloNok;
                        korosztaly1.InduloFerfiak = korosztaly.InduloFerfiak;
                        korosztaly1.Egyben = korosztaly.Egyben;
                        Adatbazis.Korosztaly.Korosztaly.Update( korosztaly );
                        return;

                    }
                }
            }
        }

        /// <summary>
        /// TODO ennek sem itt kéne lenni !!!
        /// </summary>
        /// <param name="versenyAzonosito"></param>
        /// <param name="korosztalyAzonosito"></param>
        public static List<KorosztalyInduloSeged> Tagok( string versenyAzonosito, string korosztalyAzonosito ) {
            List<KorosztalyInduloSeged> tagokList = new List<KorosztalyInduloSeged>();

            foreach( var versenyeredmenyek in Data.Data.Eredmenyek._versenyEredmenyek.Where( eredmeny => eredmeny.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                foreach( var eredmeny in versenyeredmenyek.Eredmenyek._eredmenyek.Where( eredmeny => eredmeny.KorosztalyAzonosito.Equals( korosztalyAzonosito ) ) ) {
                    var indulo = (from indulo1 in Data.Data.Indulok._indulok
                                  where indulo1.Nev.Equals(eredmeny.Indulo)
                                  select indulo1).First();

                    tagokList.Add( new KorosztalyInduloSeged {
                        Nev = indulo.Nev,
                        Nem = indulo.Nem,
                        Kor = eredmeny.Kor
                    } );

                    tagokList = tagokList.OrderBy( seged => seged.Kor ).ToList( );
                }
            }
            return tagokList;
        }
        
        /// <summary>
        /// | model update |
        /// adatbazis update |
        /// </summary>
        /// <param name="versenyAzonosito"></param>
        /// <param name="korosztalyAzonosito"></param>
        public void NokNoveles( string versenyAzonosito, string korosztalyAzonosito ) {
            foreach( var versenykorosztaly in _versenyKorosztalyok.Where( korosztaly => korosztaly.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                foreach( var korosztaly in versenykorosztaly.Korosztalyok.Where( korosztaly => korosztaly.Azonosito.Equals( korosztalyAzonosito ) ) ) {
                    korosztaly.InduloNok += 1;
                    Adatbazis.Korosztaly.Korosztaly.NokNoveles( korosztaly );

                }
            }
        }

        /// <summary>
        /// | model update |
        /// adatbazis update |
        /// </summary>
        /// <param name="versenyAzonosito"></param>
        /// <param name="korosztalyAzonosito"></param>
        public void FerfiakNoveles( string versenyAzonosito, string korosztalyAzonosito ) {
            foreach( var versenykorosztaly in _versenyKorosztalyok.Where( korosztaly => korosztaly.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                foreach( var korosztaly in versenykorosztaly.Korosztalyok.Where( korosztaly => korosztaly.Azonosito.Equals( korosztalyAzonosito ) ) ) {
                    korosztaly.InduloFerfiak += 1;
                    Adatbazis.Korosztaly.Korosztaly.FerfiakNoveles( korosztaly );

                }
            }

        }

        public void TagokCsokkentes( Eredmeny.Eredmeny eredmeny ) {
            var nem = (from indulo in Data.Data.Indulok._indulok
                       where indulo.Nev.Equals(eredmeny.Indulo)
                       select indulo.Nem).First();

            foreach(
                var korosztaly in
                    _versenyKorosztalyok.Where( korosztaly => korosztaly.VersenyAzonosito.Equals( eredmeny.Verseny ) )
                        .SelectMany(
                            versenykorosztalyok =>
                                versenykorosztalyok.Korosztalyok.Where(
                                    korosztaly => korosztaly.Azonosito.Equals( eredmeny.KorosztalyAzonosito ) ) ) ) {
                if( nem.Equals( "F" ) || nem.Equals( "f" ) ) {
                    korosztaly.InduloFerfiak -= 1;
                    Adatbazis.Korosztaly.Korosztaly.FerfiakCsokkentes( korosztaly );
                    return;
                }
                korosztaly.InduloNok -= 1;
                Adatbazis.Korosztaly.Korosztaly.NokCsokkentes( korosztaly );
                return;
            }
        }

        public int BetoltottKor( string versenyDatum, string induloSzuletesiDatum ) {
            var value = (new DateTime(1, 1, 1) + ((Convert.ToDateTime(versenyDatum)) - DateTime.Parse(induloSzuletesiDatum))).Year - 1;
            return value;
        }
    }
}