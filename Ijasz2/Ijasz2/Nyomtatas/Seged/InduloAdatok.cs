using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Ijasz2.Nyomtatas.Seged {

    public class InduloAdat {
        public string Nev { get; set; }
        public int Sorszam { get; set; }
        public int Kor { get; set; }
        public string Egyesulet { get; set; }
        public int Csapat { get; set; }
        public string Ijtipus { get; set; }
    }

    public class InduloAdatok {
        public List<InduloAdat> Indulok { get; set; }

        public InduloAdatok( ) {
        }

        public InduloAdatok( string versenyAzonosito, bool nemMegjelentNyomtat = false ) {
            Indulok = new List<InduloAdat>( );

            // cache-eljuk az indulokat
            var indulok = Model.Data.Data.Indulok._indulok;

            foreach( var versenyeredmenyek in Model.Data.Data.Eredmenyek._versenyEredmenyek.Where( eredmeny => eredmeny.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                foreach( var eredmeny in versenyeredmenyek.Eredmenyek._eredmenyek.Where( eredmeny => eredmeny.Megjelent.Equals( !nemMegjelentNyomtat ) ) ) {
                    var indulo = (from indulo1 in indulok
                                  where indulo1.Nev.Equals(eredmeny.Indulo)
                                  select indulo1).First();
                    indulok.Remove( indulo );

                    Indulok.Add( new InduloAdat {
                        Nev = eredmeny.Indulo,
                        Sorszam = eredmeny.Sorszam,
                        Kor = eredmeny.Kor,
                        Csapat = eredmeny.Csapat,
                        Ijtipus = eredmeny.Ijtipus,
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
                foreach( var eredmeny in versenyeredmenyek.Eredmenyek._eredmenyek.Where( eredmeny => eredmeny.Megjelent.Equals( true ) && eredmeny.Csapat.Equals( csapat ) ) ) {
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
