using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Ijasz2.Model.Eredmeny;

namespace Ijasz2.Nyomtatas.Seged {

    public class InduloAdat {
        public string Nev { get; set; }
        public int Sorszam { get; set; }
        public int Kor { get; set; }
        public string Egyesulet { get; set; }
        public int Csapat { get; set; }
        public string Ijtipus { get; set; }
        public string Nem { get; set; }
        public string Engedely { get; set; }
        public string KorosztalyMegnevezes { get; set; }

        public int Szazalek { get; set; }
        public int OsszPont { get; set; }

        public InduloAdat( ) {
        }

        public InduloAdat( Eredmeny eredmeny ) {
            var indulo = ( from indulo1 in Model.Data.Data.Indulok._indulok
                           where indulo1.Nev.Equals( eredmeny.Indulo )
                           select indulo1 ).First( );
            Nev = eredmeny.Indulo;
            Sorszam = eredmeny.Sorszam;
            Kor = eredmeny.Kor;
            Egyesulet = indulo.Egyesulet;
            Engedely = indulo.Engedely;
            Nem = indulo.Nem;
            Csapat = eredmeny.Csapat;
            Szazalek = eredmeny.Szazalek;
            OsszPont = eredmeny.OsszPont;

            Ijtipus = ( from ijtipus in Model.Data.Data.Ijtipusok._ijtipusok
                        where ijtipus.Azonosito.Equals( eredmeny.Ijtipus )
                        select ijtipus.Megnevezes ).First( );

            foreach( var versenykorosztaly in Model.Data.Data.Korosztalyok._versenyKorosztalyok.Where( korosztaly => korosztaly.VersenyAzonosito.Equals( eredmeny.Verseny ) ) ) {
                foreach( var korosztaly in versenykorosztaly.Korosztalyok.Where( korosztaly => korosztaly.Azonosito.Equals( eredmeny.KorosztalyAzonosito ) ) ) {
                    KorosztalyMegnevezes = korosztaly.Megnevezes;
                }
            }
        }
    }

    public class InduloAdatok {
        public List<InduloAdat> Indulok { get; set; }

        public InduloAdatok( ) {
        }

        public InduloAdatok( string versenyAzonosito, bool nemMegjelentNyomtat = false ) {
            Indulok = new List<InduloAdat>( );

            // cache-eljuk az indulokat
            var indulok = Model.Data.Data.Indulok._indulok.ToList();

            foreach( var versenyeredmenyek in Model.Data.Data.Eredmenyek._versenyEredmenyek.Where( eredmeny => eredmeny.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                foreach( var eredmeny in versenyeredmenyek.Eredmenyek._eredmenyek.Where( eredmeny => eredmeny.Megjelent.Equals( !nemMegjelentNyomtat ) ).OrderBy(eredmeny => eredmeny.Indulo) ) {
                    var indulo = (from indulo1 in indulok
                                  where indulo1.Nev.Equals(eredmeny.Indulo)
                                  select indulo1).First();
                    indulok.Remove( indulo );

                    Indulok.Add( new InduloAdat {
                        Nev = eredmeny.Indulo,
                        Sorszam = eredmeny.Sorszam,
                        Kor = eredmeny.Kor,
                        Csapat = eredmeny.Csapat,
                        Ijtipus = ( from ijtipus in Model.Data.Data.Ijtipusok._ijtipusok
                                    where ijtipus.Azonosito.Equals( eredmeny.Ijtipus )
                                    select ijtipus.Megnevezes ).First( ),
                        Egyesulet = indulo.Egyesulet,
                    } );
                }
            }
        }

        public InduloAdatok( string versenyAzonosito, int csapat ) {
            Indulok = new List<InduloAdat>( );


            // cache-eljuk az indulokat
            var indulok = Model.Data.Data.Indulok._indulok.ToList();

            foreach( var versenyeredmenyek in Model.Data.Data.Eredmenyek._versenyEredmenyek.Where( eredmeny => eredmeny.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                foreach( var eredmeny in versenyeredmenyek.Eredmenyek._eredmenyek.Where( eredmeny => eredmeny.Megjelent.Equals( true ) && eredmeny.Csapat.Equals( csapat ) ).OrderBy(eredmeny => eredmeny.Indulo) ) {
                    var indulo = (from indulo1 in indulok
                                  where indulo1.Nev.Equals(eredmeny.Indulo)
                                  select indulo1).First();
                    indulok.Remove( indulo );

                    Indulok.Add( new InduloAdat {
                        Nev = eredmeny.Indulo,
                        Sorszam = eredmeny.Sorszam,
                        Kor = eredmeny.Kor,
                        Csapat = eredmeny.Csapat,
                        Ijtipus = ( from ijtipus in Model.Data.Data.Ijtipusok._ijtipusok
                                    where ijtipus.Azonosito.Equals( eredmeny.Ijtipus )
                                    select ijtipus.Megnevezes ).First( ),
                        Egyesulet = indulo.Egyesulet,
                    } );
                }
            }
        }
    }
}
