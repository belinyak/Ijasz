using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using Ijasz2.Nyomtatas.Seged;
using Novacode;

namespace Ijasz2.Nyomtatas.Eredmenylap {

    #region Structs

    public struct Egyesulet {
        public string Nev { get; set; }
        public string Cim { get; set; }
        public int OsszPont { get; set; }
    }

    public struct Egyesuletek {
        public List<Egyesulet> egyesuletek { get; set; }

        /// <summary>
        /// | TODO adatbazis lekerdezes helyett LinQ |
        /// </summary>
        /// <param name="versenyAzonosito"></param>
        public Egyesuletek( string versenyAzonosito ) {
            egyesuletek = Adatbazis.Egyesulet.Egyesulet.EredmenyLap( versenyAzonosito );
        }
    }

    #endregion

    public class VersenyEredmenyLapEgyesulet {
        private VersenyAdatok versenyAdatok;
        private Egyesuletek egyesuletek;
        private DocX document;

        public VersenyEredmenyLapEgyesulet( string versenyAzonosito ) {
            versenyAdatok = new VersenyAdatok( versenyAzonosito, DokumentumTipus.Eredmenylap.Verseny.Egyesulet );
            egyesuletek = new Egyesuletek( versenyAzonosito );
        }
        private string CreateDoc( ) {
            var fileName = Seged.Seged.CreateFileName( versenyAdatok.VersenysorozatAzonosito, versenyAdatok.Azonosito,
                DokumentumTipus.Eredmenylap.Verseny.Egyesulet );

            document = DocX.Create( fileName );
            document.AddHeaders( );
            Seged.Seged.OldalSzamozas( document );

            var header = document.Headers.odd;
            AddHeader( header );
            VersenyAdatokTablazat( header );
            AdatTablazat( );

            try { document.Save( ); } catch( Exception ) {
                MessageBox.Show( "A dokumentum meg van nyitva!", "Verseny Egyesület Eredménylap", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            return fileName;
        }
        private void AdatTablazat( ) {
            Table table = document.AddTable(1, 4);
            table.Alignment = Alignment.center;

            table.Rows[0].Cells[0].Paragraphs[0].Append( "Sorrend" ).Bold( );
            table.Rows[0].Cells[1].Paragraphs[0].Append( "Egyesület neve" ).Bold( );
            table.Rows[0].Cells[2].Paragraphs[0].Append( "Egyesület címe" ).Bold( );
            table.Rows[0].Cells[3].Paragraphs[0].Append( "ÖsszPont" ).Bold( );

            int index = 1;
            foreach( var egyesulet in egyesuletek.egyesuletek ) {
                table.InsertRow( );
                table.Rows[table.Rows.Count - 1].Cells[0].Paragraphs[0].Append( index + "." );
                table.Rows[table.Rows.Count - 1].Cells[1].Paragraphs[0].Append( egyesulet.Nev );
                table.Rows[table.Rows.Count - 1].Cells[2].Paragraphs[0].Append( egyesulet.Cim );
                table.Rows[table.Rows.Count - 1].Cells[3].Paragraphs[0].Append( egyesulet.OsszPont.ToString( ) );
                index++;
            }

            AdatTablazatFormazas( table );

            document.InsertTable( table );
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
        private void AddHeader( Header header ) {
            var titleFormat = new Formatting();
            titleFormat.Size = 14D;
            titleFormat.Position = 1;
            titleFormat.Spacing = 5;
            titleFormat.Bold = true;

            var title = header.InsertParagraph();

            title.Append( Feliratok.HeadLine.Eredmenylap );
            title.AppendLine( Feliratok.HeadLine.EredmenyLapEgyesulet );

            title.Alignment = Alignment.center;

            titleFormat.Size = 10D;
            title.AppendLine( Feliratok.Tulajdonos );
            title.Bold( );
            titleFormat.Position = 12;
            title.AppendLine( );
        }

        private void AdatTablazatFormazas( Table table ) {
            Border b = new Border(Novacode.BorderStyle.Tcbs_none, BorderSize.seven, 0, Color.Blue);
            Border c = new Border(Novacode.BorderStyle.Tcbs_single, BorderSize.seven, 0, Color.Black);

            table.SetBorder( TableBorderType.InsideH, b );
            table.SetBorder( TableBorderType.InsideV, b );
            table.SetBorder( TableBorderType.Bottom, b );
            table.SetBorder( TableBorderType.Top, b );
            table.SetBorder( TableBorderType.Left, b );
            table.SetBorder( TableBorderType.Right, b );

            for( int i = 0; i < 4; i++ ) {
                table.Rows[0].Cells[i].SetBorder( TableCellBorderType.Bottom, c );
            }

            table.AutoFit = AutoFit.ColumnWidth;
            foreach( Row row in table.Rows ) {
                row.Cells[0].Width = 100;
                row.Cells[1].Width = 250;
                row.Cells[2].Width = 250;
                row.Cells[3].Width = 100;
            }

            foreach( Row row in table.Rows ) {
                row.Height = 20;
            }
        }

        public void Print( ) {
            Seged.Seged.Print( CreateDoc( ) );
        }
        public void Open( ) {
            Seged.Seged.Open( CreateDoc( ) );
        }
    }
}
