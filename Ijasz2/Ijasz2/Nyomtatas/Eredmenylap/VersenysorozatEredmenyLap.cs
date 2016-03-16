using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Ijasz2.Nyomtatas.Seged;
using Novacode;

namespace Ijasz2.Nyomtatas.Eredmenylap {

    public class VersenysorozatEredmenyLap {
        private DocX Document { get; set; }
        //todo adatok
        private Model.Versenysorozat.Versenysorozat Versenysorozat { get; set; }
        private Ijtipusok ijtipusok { get; set; }

        public VersenysorozatEredmenyLap( string versenysorozatAzonosito ) {
            Versenysorozat = ( from vs in Model.Data.Data.Versenysorozatok._versenysorozatok
                               where vs.Azonosito.Equals( versenysorozatAzonosito )
                               select vs ).First( );
            ijtipusok = new Ijtipusok( versenysorozatAzonosito, DokumentumTipus.Eredmenylap.VersenySorozat.Teljes );
        }

        private string CreateDoc( ) {
            var fileName = Seged.Seged.CreateFileName(Versenysorozat.Azonosito, null,
                DokumentumTipus.Eredmenylap.VersenySorozat.Teljes);

            Document = DocX.Create( fileName );
            Document.AddHeaders( );
            Seged.Seged.OldalSzamozas( Document );

            var header = Document.Headers.odd;
            AddHeader( header );
            VersenySorozatAdatokTablazat( header );

            Table table;
            foreach( var ijtipus in ijtipusok._ijtipusok ) {
                foreach( var korosztaly in ijtipus.korosztalyok.korosztalyok ) {
                    if( korosztaly.eredmenyek.IsEmpty( ) == false ) {
                        Paragraph paragraph = Document.InsertParagraph();
                        paragraph.Append( "Íjtípus: " );
                        paragraph.Append( ijtipus.azonosito ).Bold( );
                        paragraph.AppendLine( "    Korosztály: " );
                        paragraph.Append( korosztaly.megnevezes ).Bold( );

                        if( korosztaly.eredmenyek.Nok.Count != 0 ) {
                            Paragraph paragraph2 = Document.InsertParagraph();
                            paragraph2.Append( "       Nők:" ).Bold( );
                            int index = 0;
                            foreach( var induloAdat in korosztaly.eredmenyek.Nok ) {
                                table = Document.AddTable( 1, 7 );
                                table.Rows[0].Cells[1].Paragraphs[0].Append( index + 1 + "." );
                                table.Rows[0].Cells[2].Paragraphs[0].Append( induloAdat.Nev );
                                table.Rows[0].Cells[3].Paragraphs[0].Append( induloAdat.Kor.ToString( ) );
                                table.Rows[0].Cells[4].Paragraphs[0].Append( induloAdat.Egyesulet );
                                table.Rows[0].Cells[5].Paragraphs[0].Append( induloAdat.Szazalek.ToString( ) + " %" );
                                table.Rows[0].Cells[6].Paragraphs[0].Append( induloAdat.OsszPont.ToString( ) + " pont" );
                                TablazatFormazas( table );
                                Document.InsertTable( table );
                                index++;
                            }
                        }
                        if( korosztaly.eredmenyek.Ferfiak.Count != 0 ) {
                            Paragraph paragraph2 = Document.InsertParagraph();
                            paragraph2.Append( "       Férfiak:" ).Bold( );
                            int index = 0;
                            foreach( var induloAdat in korosztaly.eredmenyek.Ferfiak ) {
                                table = Document.AddTable( 1, 7 );
                                table.Rows[0].Cells[1].Paragraphs[0].Append( index + 1 + "." );
                                table.Rows[0].Cells[2].Paragraphs[0].Append( induloAdat.Nev );
                                table.Rows[0].Cells[3].Paragraphs[0].Append( induloAdat.Kor.ToString( ) );
                                table.Rows[0].Cells[4].Paragraphs[0].Append( induloAdat.Egyesulet );
                                table.Rows[0].Cells[5].Paragraphs[0].Append( induloAdat.Szazalek.ToString( ) + " %" );
                                table.Rows[0].Cells[6].Paragraphs[0].Append( induloAdat.OsszPont.ToString( ) + " pont" );
                                TablazatFormazas( table );
                                Document.InsertTable( table );
                                index++;
                            }
                        }
                        if( korosztaly.eredmenyek.Egyben.Count != 0 ) {
                            Paragraph paragraph2 = Document.InsertParagraph();
                            paragraph2.Append( "       Egyben:" ).Bold( );
                            int index = 0;
                            foreach( var induloAdat in korosztaly.eredmenyek.Egyben ) {
                                table = Document.AddTable( 1, 7 );
                                table.Rows[0].Cells[1].Paragraphs[0].Append( index + 1 + "." );
                                table.Rows[0].Cells[2].Paragraphs[0].Append( induloAdat.Nev );
                                table.Rows[0].Cells[3].Paragraphs[0].Append( induloAdat.Kor.ToString( ) );
                                table.Rows[0].Cells[4].Paragraphs[0].Append( induloAdat.Egyesulet );
                                table.Rows[0].Cells[5].Paragraphs[0].Append( induloAdat.Szazalek.ToString( ) + " %" );
                                table.Rows[0].Cells[6].Paragraphs[0].Append( induloAdat.OsszPont.ToString( ) + " pont" );
                                TablazatFormazas( table );
                                Document.InsertTable( table );
                                index++;
                            }
                        }
                    }
                }
            }


            try { Document.Save( ); } catch( Exception ) {
                MessageBox.Show( "A dokumentum meg van nyitva!", "Versenysorozat Teljes Eredménylap", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            return fileName;
        }

        private void TablazatFormazas( Table table ) {
            table.AutoFit = AutoFit.ColumnWidth;
            for( int i = 0; i < table.Rows.Count; i++ ) {
                table.Rows[i].Cells[0].Width = 30;
                table.Rows[i].Cells[1].Width = 50;
                table.Rows[i].Cells[2].Width = 200;
                table.Rows[i].Cells[3].Width = 50;
                table.Rows[i].Cells[4].Width = 200;
                table.Rows[i].Cells[5].Width = 70;
                table.Rows[i].Cells[6].Width = 70;
            }

            Border c = new Border(Novacode.BorderStyle.Tcbs_none,BorderSize.seven, 0, Color.Black);
            Border d = new Border(Novacode.BorderStyle.Tcbs_single,BorderSize.five, 0, Color.Black);

            //table.SetBorder( TableBorderType.InsideH, d );
            //table.SetBorder( TableBorderType.InsideV, c );
            //table.SetBorder( TableBorderType.Bottom, c );
            //table.SetBorder( TableBorderType.Top, c );
            //table.SetBorder( TableBorderType.Left, c );
            //table.SetBorder( TableBorderType.Right, c );
        }

        private void AddHeader( Header header ) {
            var titleFormat = new Formatting();
            titleFormat.Size = 14D;
            titleFormat.Position = 1;
            titleFormat.Spacing = 5;
            titleFormat.Bold = true;

            var title = header.InsertParagraph();

            title.Append( Feliratok.HeadLine.Eredmenylap );
            title.AppendLine( Feliratok.HeadLine.EredmenyLapTeljes );

            title.Alignment = Alignment.center;

            titleFormat.Size = 10D;
            title.AppendLine( Feliratok.Tulajdonos );
            title.Bold( );
            titleFormat.Position = 12;
            title.AppendLine( );
        }
        private void VersenySorozatAdatokTablazat( Header header ) {
            var table = Document.AddTable(1, 2);
            table.Alignment = Alignment.left;
            table.Rows[0].Cells[0].Paragraphs[0].Append( Feliratok.Versenysorozat.Megnevezes );
            table.Rows[0].Cells[0].Paragraphs[0].Append( string.IsNullOrEmpty( Versenysorozat.Megnevezes ) ? Versenysorozat.Azonosito : Versenysorozat.Megnevezes ).Bold( );

            table.AutoFit = AutoFit.Contents;

            var b = new Border(Novacode.BorderStyle.Tcbs_none, BorderSize.seven, 0, Color.AliceBlue);
            table.SetBorder( TableBorderType.InsideH, b );
            table.SetBorder( TableBorderType.InsideV, b );
            table.SetBorder( TableBorderType.Bottom, b );
            table.SetBorder( TableBorderType.Top, b );
            table.SetBorder( TableBorderType.Left, b );
            table.SetBorder( TableBorderType.Right, b );
            header.InsertTable( table );
        }

        public void Print( ) {
            Seged.Seged.Print( CreateDoc( ) );
        }
        public void Open( ) {
            Seged.Seged.Open( CreateDoc( ) );
        }

    }
}
