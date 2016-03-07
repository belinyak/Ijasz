using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Ijasz2.Nyomtatas.Seged;
using Novacode;

namespace Ijasz2.Nyomtatas.Startlista {
    public class Csapat {
        public int Azonosito { get; set; }
        public InduloAdatok InduloAdatok { get; set; }
    }

    public class Csapatok {
        public List<Csapat> csapatok { get; set; }

        public Csapatok( string versenyAzonosito ) {
            csapatok = new List<Csapat>( );
            foreach( var versenyeredmenyek in Model.Data.Data.Eredmenyek._versenyEredmenyek.Where( eredmeny => eredmeny.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                foreach( var csapatazonosito in versenyeredmenyek.Eredmenyek._eredmenyek.GroupBy( eredmeny => eredmeny.Csapat ).Select( grouping => grouping.Key ) ) {
                    csapatok.Add( new Csapat {
                        Azonosito = csapatazonosito,
                        InduloAdatok = new InduloAdatok( versenyAzonosito, csapatazonosito )
                    } );
                }
            }
        }
    }

    public class CsapatLista {
        public VersenyAdatok versenyAdatok { get; set; }
        public Csapatok csapatok { get; set; }

        public CsapatLista( string versenyAzonosito ) {
            versenyAdatok = new VersenyAdatok( versenyAzonosito );
            csapatok = new Csapatok( versenyAzonosito );
        }

        private string CreateDoc( ) {
            string fileName = Seged.Seged.CreateFileName(versenyAdatok.VersenysorozatAzonosito, versenyAdatok.Azonosito, StartlistaTipus.CsapatLista);
            var document = DocX.Create(fileName);
            document.AddHeaders( );
            Seged.Seged.OldalSzamozas( document );
            #region Címbekezdés
            var titleFormat = new Formatting();
            titleFormat.Size = 14D;
            titleFormat.Position = 1;
            titleFormat.Spacing = 5;
            titleFormat.Bold = true;

            Header header = document.Headers.odd;

            Paragraph title = header.InsertParagraph();
            title.Append( Seged.Feliratok.HeadLineCsapatlista );
            title.Alignment = Alignment.center;

            titleFormat.Size = 10D;
            title.AppendLine( Seged.Feliratok.Tulajdonos );
            title.AppendLine( );
            title.Bold( );
            titleFormat.Position = 12;
            #endregion

            Seged.Seged.CsapatlistaHeaderTablazat(document,versenyAdatok);           

            foreach( var csapat in csapatok.csapatok ) {
                Table table = document.AddTable( csapat.InduloAdatok.Indulok.Count + 1 , 6 );
                table.Alignment = Alignment.center;

                table.Rows[0].Cells[0].Paragraphs[0].Append( "Csapat" ).Bold( );
                table.Rows[0].Cells[1].Paragraphs[0].Append( "Sorszám" ).Bold( );
                table.Rows[0].Cells[2].Paragraphs[0].Append( "Név" ).Bold( );
                table.Rows[0].Cells[3].Paragraphs[0].Append( "Íjtípus" ).Bold( );
                table.Rows[0].Cells[4].Paragraphs[0].Append( "Kor" ).Bold( );
                table.Rows[0].Cells[5].Paragraphs[0].Append( "Egyesület" ).Bold( );

                var rowIndex = 1;
                foreach( var indulo in csapat.InduloAdatok.Indulok ) {
                    table.Rows[rowIndex].Cells[0].Paragraphs[0].Append( indulo.Csapat.ToString( ) );
                    table.Rows[rowIndex].Cells[1].Paragraphs[0].Append( indulo.Sorszam.ToString( ) );
                    table.Rows[rowIndex].Cells[2].Paragraphs[0].Append( indulo.Nev );
                    table.Rows[rowIndex].Cells[3].Paragraphs[0].Append( indulo.Ijtipus );
                    table.Rows[rowIndex].Cells[4].Paragraphs[0].Append( indulo.Kor.ToString( ) );
                    table.Rows[rowIndex].Cells[5].Paragraphs[0].Append( indulo.Egyesulet );
                    rowIndex++;
                }
                Seged.Seged.CsapatlistaTablazatFormazas( table );
                document.InsertTable( table );
                if( csapat != csapatok.csapatok.Last( ) ) {
                    document.InsertSectionPageBreak( );
                }
            }
            try {
                document.Save( );
            } catch( System.Exception ) {
                MessageBox.Show( "A dokumentum meg van nyitva!", "Csapatlista", MessageBoxButton.OK, MessageBoxImage.Error );
            }

            return fileName;
        }

        public void Print( ) {
            Seged.Seged.Print( CreateDoc( ) );
        }

        public void Open( ) {
            Seged.Seged.Open( CreateDoc( ) );
        }
    }
}
