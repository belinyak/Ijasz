using System.Collections.Generic;
using System.Drawing;
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
                foreach( var csapatazonosito in versenyeredmenyek.Eredmenyek._eredmenyek.OrderBy(eredmeny => eredmeny.Csapat).GroupBy( eredmeny => eredmeny.Csapat ).Select( grouping => grouping.Key ) ) {
                    csapatok.Add( new Csapat {
                        Azonosito = csapatazonosito,
                        InduloAdatok = new InduloAdatok( versenyAzonosito, csapatazonosito )
                    } );
                }
            }
        }
    }

    public class CsapatLista {
        private VersenyAdatok versenyAdatok { get; set; }
        private Csapatok csapatok { get; set; }
        private DocX document { get; set; }

        public CsapatLista( string versenyAzonosito ) {
            versenyAdatok = new VersenyAdatok( versenyAzonosito );
            csapatok = new Csapatok( versenyAzonosito );
        }

        private string CreateDoc( ) {
            var fileName = Seged.Seged.CreateFileName(versenyAdatok.VersenysorozatAzonosito, versenyAdatok.Azonosito, DokumentumTipus.Startlista.CsapatLista);
            document = DocX.Create( fileName );
            document.AddHeaders( );
            Seged.Seged.OldalSzamozas( document );
            AddHeader( );
            CsapatlistaHeaderTablazat( );
            CsapatokTablazat( );

            try { document.Save( ); } catch( System.Exception ) {
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

        private void AddHeader( ) {
            var titleFormat = new Formatting();
            titleFormat.Size = 14D;
            titleFormat.Position = 1;
            titleFormat.Spacing = 5;
            titleFormat.Bold = true;

            var header = document.Headers.odd;

            var title = header.InsertParagraph();
            title.Append( Feliratok.HeadLine.Csapatlista );
            title.Alignment = Alignment.center;
            titleFormat.Size = 10D;
            title.AppendLine( Seged.Feliratok.Tulajdonos );
            title.AppendLine( );
            title.Bold( );
            titleFormat.Position = 12;
        }
        private void CsapatokTablazat( ) {
            foreach( var csapat in csapatok.csapatok ) {
                var table = document.AddTable( csapat.InduloAdatok.Indulok.Count + 1 , 6 );
                table.Alignment = Alignment.center;

                table.Rows[0].Cells[0].Paragraphs[0].Append( "Csapat" ).Bold( );
                table.Rows[0].Cells[1].Paragraphs[0].Append( "Sorszám" ).Bold( );
                table.Rows[0].Cells[2].Paragraphs[0].Append( "Név" ).Bold( );
                table.Rows[0].Cells[3].Paragraphs[0].Append( "Íjtípus" ).Bold( );
                table.Rows[0].Cells[4].Paragraphs[0].Append( "Kor" ).Bold( );
                table.Rows[0].Cells[5].Paragraphs[0].Append( "Egyesület" ).Bold( );

                var rowIndex = 1;
                foreach( var indulo in csapat.InduloAdatok.Indulok ) {
                    table.Rows[rowIndex - 1].Cells[0].Paragraphs[0].KeepWithNext( );
                    table.Rows[rowIndex - 1].Cells[1].Paragraphs[0].KeepWithNext( );
                    table.Rows[rowIndex - 1].Cells[2].Paragraphs[0].KeepWithNext( );
                    table.Rows[rowIndex - 1].Cells[3].Paragraphs[0].KeepWithNext( );
                    table.Rows[rowIndex - 1].Cells[4].Paragraphs[0].KeepWithNext( );
                    table.Rows[rowIndex - 1].Cells[5].Paragraphs[0].KeepWithNext( );

                    table.Rows[rowIndex].Cells[0].Paragraphs[0].Append( indulo.Csapat.ToString( ) );
                    table.Rows[rowIndex].Cells[1].Paragraphs[0].Append( indulo.Sorszam.ToString( ) );
                    table.Rows[rowIndex].Cells[2].Paragraphs[0].Append( indulo.Nev );
                    table.Rows[rowIndex].Cells[3].Paragraphs[0].Append( indulo.Ijtipus );
                    table.Rows[rowIndex].Cells[4].Paragraphs[0].Append( indulo.Kor.ToString( ) );
                    table.Rows[rowIndex].Cells[5].Paragraphs[0].Append( indulo.Egyesulet );

                    rowIndex++;
                }

                #region Formazas
                var b = new Border(Novacode.BorderStyle.Tcbs_none, BorderSize.seven, 0, Color.Blue);
                var c = new Border(Novacode.BorderStyle.Tcbs_single, BorderSize.seven, 0, Color.Black);

                table.SetBorder( TableBorderType.InsideH, b );
                table.SetBorder( TableBorderType.InsideV, b );
                table.SetBorder( TableBorderType.Bottom, b );
                table.SetBorder( TableBorderType.Top, b );
                table.SetBorder( TableBorderType.Left, b );
                table.SetBorder( TableBorderType.Right, b );

                for( var i = 0; i < 6; i++ ) {
                    table.Rows[0].Cells[i].SetBorder( TableCellBorderType.Bottom, c );
                }

                foreach( var row in table.Rows ) {
                    row.Cells[0].Width = 57;
                    row.Cells[1].Width = 70;
                    row.Cells[2].Width = 160;
                    row.Cells[3].Width = 160;
                    row.Cells[4].Width = 70;
                    row.Cells[5].Width = 200;
                }
                table.AutoFit = AutoFit.ColumnWidth;
                #endregion

                document.InsertTable( table );
                if( csapat != csapatok.csapatok.Last( ) ) {
                    //document.InsertSectionPageBreak( );
                }
            }
        }
        private void CsapatlistaHeaderTablazat( ) {
            var table = document.AddTable(3, 2);
            table.Alignment = Alignment.left;
            table.Rows[0].Cells[0].Paragraphs[0].Append( Feliratok.VersenyMegnevezes );
            table.Rows[0].Cells[0].Paragraphs[0].Append( string.IsNullOrEmpty( versenyAdatok.Megnevezes ) ? versenyAdatok.Azonosito : versenyAdatok.Megnevezes ).Bold( );

            table.Rows[1].Cells[0].Paragraphs[0].Append( Feliratok.VersenyDatum );
            table.Rows[1].Cells[0].Paragraphs[0].Append( versenyAdatok.Datum ).Bold( );

            if( !string.IsNullOrEmpty( versenyAdatok.VersenysorozatAzonosito ) ) {
                table.Rows[2].Cells[0].Paragraphs[0].Append( Feliratok.VersenySorozat );
                table.Rows[2].Cells[0].Paragraphs[0].Append( string.IsNullOrEmpty( versenyAdatok.VersenysorozatMegnevezes ) ? versenyAdatok.VersenysorozatAzonosito : versenyAdatok.VersenysorozatMegnevezes ).Bold( );
            }

            table.Rows[0].Cells[1].Paragraphs[0].Append( Feliratok.OsszesPont );
            table.Rows[0].Cells[1].Paragraphs[0].Append( ( versenyAdatok.OsszesPont * 10 ).ToString( ) ).Bold( );

            table.Rows[1].Cells[1].Paragraphs[0].Append( Feliratok.VersenyIndulokSzama );
            table.Rows[1].Cells[1].Paragraphs[0].Append( versenyAdatok.IndulokSzama.ToString( ) ).Bold( );

            table.AutoFit = AutoFit.Contents;

            var b = new Border(Novacode.BorderStyle.Tcbs_none, BorderSize.seven, 0, Color.AliceBlue);
            table.SetBorder( TableBorderType.InsideH, b );
            table.SetBorder( TableBorderType.InsideV, b );
            table.SetBorder( TableBorderType.Bottom, b );
            table.SetBorder( TableBorderType.Top, b );
            table.SetBorder( TableBorderType.Left, b );
            table.SetBorder( TableBorderType.Right, b );
            document.InsertTable( table );
            document.InsertParagraph( );
        }

    }
}
