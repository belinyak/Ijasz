using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using Ijasz2.Model.Data;
using Ijasz2.Nyomtatas.Seged;
using Novacode;

namespace Ijasz2.Nyomtatas.Eredmenylap {
    public class VersenyEredmenyLap {
        private VersenyAdatok versenyAdatok { get; set; }
        private Ijtipusok ijtipusok { get; set; }
        private string dokumentumTipus { get; set; }
        private DocX document { get; set; }

        public VersenyEredmenyLap( string dokumentumtipus, string versenyAzonosito ) {
            dokumentumTipus = dokumentumtipus;
            versenyAdatok = new VersenyAdatok( versenyAzonosito, dokumentumTipus );
            ijtipusok = new Ijtipusok( versenyAzonosito, dokumentumTipus );
        }

        private string CreateDoc( ) {
              var fileName = Seged.Seged.CreateFileName( versenyAdatok.VersenysorozatAzonosito, versenyAdatok.Azonosito,
                    dokumentumTipus );

                document = DocX.Create( fileName );
                document.AddHeaders( );
                Seged.Seged.OldalSzamozas( document );

                var header = document.Headers.odd;
                AddHeader( header );
                VersenyAdatokTablazat( header );

                foreach( var ijtipus in ijtipusok._ijtipusok ) {
                    Table table ;
                    foreach( var korosztaly in ijtipus.korosztalyok.korosztalyok ) {
                        if( !korosztaly.eredmenyek.IsEmpty( ) ) {
                            var korosztalyParagraph = document.InsertParagraph();
                            korosztalyParagraph.Append( "Íjtípus: " );
                            korosztalyParagraph.Append( ijtipus.megnevezes ).Bold( );
                            korosztalyParagraph.AppendLine( "    Korosztály: " );
                            korosztalyParagraph.Append( korosztaly.megnevezes ).Bold( );

                            if( !korosztaly.eredmenyek.Nok.Count.Equals( 0 ) ) {
                                var nokParagraph = document.InsertParagraph();
                                nokParagraph.Append( "      Nők: " ).Bold( );

                                int helyezes = 0;
                                foreach( var eredmeny in korosztaly.eredmenyek.Nok ) {
                                    helyezes++;
                                    table = document.AddTable( 1, 7 );
                                    table.Rows[0].Cells[1].Paragraphs[0].Append( ( helyezes ) + "." );
                                    table.Rows[0].Cells[2].Paragraphs[0].Append( eredmeny.Sorszam.ToString( ) );
                                    table.Rows[0].Cells[3].Paragraphs[0].Append( eredmeny.Nev );
                                    table.Rows[0].Cells[4].Paragraphs[0].Append( eredmeny.Egyesulet );
                                    table.Rows[0].Cells[5].Paragraphs[0].Append( eredmeny.OsszPont.ToString( ) + " pont" );
                                    table.Rows[0].Cells[6].Paragraphs[0].Append( eredmeny.Szazalek.ToString( ) + "%" );
                                    TablazatFormazas( table );
                                    document.InsertTable( table );
                                }
                            }
                            if( !korosztaly.eredmenyek.Ferfiak.Count.Equals( 0 ) ) {
                                var nokParagraph = document.InsertParagraph();
                                nokParagraph.Append( "      Férfiak: " ).Bold( );

                                int helyezes = 0;
                                foreach( var eredmeny in korosztaly.eredmenyek.Ferfiak ) {
                                    helyezes++;
                                    table = document.AddTable( 1, 7 );
                                    table.Rows[0].Cells[1].Paragraphs[0].Append( ( helyezes ) + "." );
                                    table.Rows[0].Cells[2].Paragraphs[0].Append( eredmeny.Sorszam.ToString( ) );
                                    table.Rows[0].Cells[3].Paragraphs[0].Append( eredmeny.Nev );
                                    table.Rows[0].Cells[4].Paragraphs[0].Append( eredmeny.Egyesulet );
                                    table.Rows[0].Cells[5].Paragraphs[0].Append( eredmeny.OsszPont.ToString( ) + " pont" );
                                    table.Rows[0].Cells[6].Paragraphs[0].Append( eredmeny.Szazalek.ToString( ) + "%" );
                                    TablazatFormazas( table );
                                    document.InsertTable( table );
                                }
                            }
                            if( !korosztaly.eredmenyek.Egyben.Count.Equals( 0 ) ) {
                                var nokParagraph = document.InsertParagraph();
                                nokParagraph.Append( "      Egyben: " ).Bold( );

                                int helyezes = 0;
                                foreach( var eredmeny in korosztaly.eredmenyek.Egyben ) {
                                    helyezes++;
                                    table = document.AddTable( 1, 7 );
                                    table.Rows[0].Cells[1].Paragraphs[0].Append( ( helyezes ) + "." );
                                    table.Rows[0].Cells[2].Paragraphs[0].Append( eredmeny.Sorszam.ToString( ) );
                                    table.Rows[0].Cells[3].Paragraphs[0].Append( eredmeny.Nev );
                                    table.Rows[0].Cells[4].Paragraphs[0].Append( eredmeny.Egyesulet );
                                    table.Rows[0].Cells[5].Paragraphs[0].Append( eredmeny.OsszPont.ToString( ) + " pont" );
                                    table.Rows[0].Cells[6].Paragraphs[0].Append( eredmeny.Szazalek.ToString( ) + "%" );
                                    TablazatFormazas( table );
                                    document.InsertTable( table );
                                }
                            }
                        }
                    }
                }
                try { document.Save( ); } catch( Exception ) {
                    MessageBox.Show( "A dokumentum meg van nyitva!", "Verseny Teljes Eredménylap", MessageBoxButton.OK, MessageBoxImage.Error );
                }
                return fileName;
            }
        public void Print( ) {
            Seged.Seged.Print( CreateDoc( ) );
        }
        public void Open( ) {
            Seged.Seged.Open( CreateDoc( ) );
        }

        private void AddHeader( Header header ) {
            var titleFormat = new Formatting();
            titleFormat.Size = 14D;
            titleFormat.Position = 1;
            titleFormat.Spacing = 5;
            titleFormat.Bold = true;

            var title = header.InsertParagraph();

            if( dokumentumTipus.Equals(DokumentumTipus.Eredmenylap.Verseny.MISZ) ) {
                title.Append( Feliratok.HeadLine.Eredmenylap );
                title.AppendLine( Feliratok.HeadLine.EredmenyLapMISZ );
            }
            else {
                title.Append( Feliratok.HeadLine.Eredmenylap );
                title.AppendLine( Feliratok.HeadLine.EredmenyLapTeljes );
            }

            title.Alignment = Alignment.center;

            titleFormat.Size = 10D;
            title.AppendLine( Feliratok.Tulajdonos );
            title.Bold( );
            titleFormat.Position = 12;
            title.AppendLine( );
        }
        private void VersenyAdatokTablazat( Header header ) {
            var table = document.AddTable(3, 2);
            table.Alignment = Alignment.left;
            table.Rows[0].Cells[0].Paragraphs[0].Append( Feliratok.Verseny.Megnevezes );
            table.Rows[0].Cells[0].Paragraphs[0].Append( string.IsNullOrEmpty( versenyAdatok.Megnevezes ) ? versenyAdatok.Azonosito : versenyAdatok.Megnevezes ).Bold( );

            table.Rows[1].Cells[0].Paragraphs[0].Append( Feliratok.Verseny.Datum );
            table.Rows[1].Cells[0].Paragraphs[0].Append( versenyAdatok.Datum ).Bold( );

            if( !string.IsNullOrEmpty( versenyAdatok.VersenysorozatAzonosito ) ) {
                table.Rows[2].Cells[0].Paragraphs[0].Append( Feliratok.Versenysorozat.Megnevezes );
                table.Rows[2].Cells[0].Paragraphs[0].Append( string.IsNullOrEmpty( versenyAdatok.VersenysorozatMegnevezes ) ? versenyAdatok.VersenysorozatAzonosito : versenyAdatok.VersenysorozatMegnevezes ).Bold( );
            }

            table.Rows[0].Cells[1].Paragraphs[0].Append( Feliratok.Verseny.OsszesPont );
            table.Rows[0].Cells[1].Paragraphs[0].Append( ( versenyAdatok.OsszesPont * 10 ).ToString( ) ).Bold( );

            table.Rows[1].Cells[1].Paragraphs[0].Append( Feliratok.Verseny.IndulokSzama );
            table.Rows[1].Cells[1].Paragraphs[0].Append( versenyAdatok.IndulokSzama.ToString( ) ).Bold( );

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
        private static void TablazatFormazas( Table table ) {
            table.AutoFit = AutoFit.Contents;
            table.AutoFit = AutoFit.ColumnWidth;
            foreach( Row row in table.Rows ) {
                row.Cells[0].Width = 30;
                row.Cells[1].Width = 50;
                row.Cells[2].Width = 50;
                row.Cells[3].Width = 200;
                row.Cells[4].Width = 200;
                row.Cells[5].Width = 70;
                row.Cells[6].Width = 70;
            }

            Border c = new Border(Novacode.BorderStyle.Tcbs_none, BorderSize.seven, 0, Color.Black);
            Border d = new Border(Novacode.BorderStyle.Tcbs_single, BorderSize.five, 0, Color.Black);
            table.SetBorder( TableBorderType.InsideH, d );
            table.SetBorder( TableBorderType.InsideV, c );
            table.SetBorder( TableBorderType.Bottom, c );
            table.SetBorder( TableBorderType.Top, c );
            table.SetBorder( TableBorderType.Left, c );
            table.SetBorder( TableBorderType.Right, c );

        }
    }
}
