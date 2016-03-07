using System;
using System.Diagnostics;
using System.Drawing;
using Novacode;

namespace Ijasz2.Nyomtatas.Seged {
    public class Seged {

        /// <summary>
        /// TODO ha kész a mappa
        /// </summary>
        /// <param name="versenysorozat"></param>
        /// <param name="verseny"></param>
        /// <param name="dokumentumTipus"></param>
        /// <returns></returns>
        public static string CreateFileName( string versenysorozat, string verseny, StartlistaTipus dokumentumTipus ) {
            string FileName;

            FileName = dokumentumTipus + ".docx";
            return FileName;

            if( string.IsNullOrEmpty( versenysorozat ) ) {
                FileName = verseny + "\\" + dokumentumTipus + ".docx";
                return FileName;
            }
            else {
                FileName = versenysorozat + "\\" + verseny + "\\" + dokumentumTipus + ".docx";
                return FileName;
            }

        }

        /// <summary>
        /// nem mukodik az alignment ezért a string
        /// </summary>
        /// <param name="document"></param>
        public static void OldalSzamozas( DocX document ) {
            document.AddFooters( );
            var footer = document.Footers.odd;

            var footerTable = footer.InsertTable(1, 2);
            footerTable.Rows[0].Cells[1].Paragraphs[0].InsertPageNumber( PageNumberFormat.normal, 0 );
            footerTable.Rows[0].Cells[1].Paragraphs[0].Append( ". oldal" );
            footerTable.AutoFit = AutoFit.ColumnWidth;
            footerTable.Rows[0].Cells[0].Width = document.PageWidth - 100;
            footerTable.Rows[0].Cells[1].Width = 70;

            Border c = new Border(Novacode.BorderStyle.Tcbs_none, BorderSize.seven, 0, Color.Black );
            footerTable.SetBorder( TableBorderType.InsideH, c );
            footerTable.SetBorder( TableBorderType.InsideV, c );
            footerTable.SetBorder( TableBorderType.Bottom, c );
            footerTable.SetBorder( TableBorderType.Top, c );
            footerTable.SetBorder( TableBorderType.Left, c );
            footerTable.SetBorder( TableBorderType.Right, c );
        }

        public static void NevezesiListaTablazatFormazas( Table table ) {
            table.Alignment = Alignment.center;

            Border b = new Border(Novacode.BorderStyle.Tcbs_none, BorderSize.seven, 0, Color.Blue);
            Border c = new Border(Novacode.BorderStyle.Tcbs_single, BorderSize.seven, 0, Color.Black);

            table.SetBorder( TableBorderType.InsideH, b );
            table.SetBorder( TableBorderType.InsideV, b );
            table.SetBorder( TableBorderType.Bottom, b );
            table.SetBorder( TableBorderType.Top, b );
            table.SetBorder( TableBorderType.Left, b );
            table.SetBorder( TableBorderType.Right, b );

            for( int i = 0; i < 6; i++ ) {
                table.Rows[0].Cells[i].SetBorder( TableCellBorderType.Bottom, c );
            }

            foreach( Row row in table.Rows ) {
                row.Cells[0].Width = 70;
                row.Cells[1].Width = 200;
                row.Cells[2].Width = 150;
                row.Cells[3].Width = 40;
                row.Cells[4].Width = 150;
                row.Cells[5].Width = 70;
            }

            table.AutoFit = AutoFit.ColumnWidth;
        }
     
        public static void HianyzoklistaHeaderTablazat( DocX document, VersenyAdatok versenyAdatok ) {
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

            table.Rows[1].Cells[1].Paragraphs[0].Append( Feliratok.VersenyHianyzokSzama );
            table.Rows[1].Cells[1].Paragraphs[0].Append( versenyAdatok.HianyzokSzama.ToString( ) ).Bold( );

            table.AutoFit = AutoFit.Contents;

            var b = new Border(Novacode.BorderStyle.Tcbs_none, BorderSize.seven, 0, Color.Blue);
            table.SetBorder( TableBorderType.InsideH, b );
            table.SetBorder( TableBorderType.InsideV, b );
            table.SetBorder( TableBorderType.Bottom, b );
            table.SetBorder( TableBorderType.Top, b );
            table.SetBorder( TableBorderType.Left, b );
            table.SetBorder( TableBorderType.Right, b );
            document.InsertTable( table );
            document.InsertParagraph( );
        }

        public static void CsapatlistaHeaderTablazat( DocX document, VersenyAdatok versenyAdatok ) {
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

            var b = new Border(Novacode.BorderStyle.Tcbs_none, BorderSize.seven, 0, Color.Blue);
            table.SetBorder( TableBorderType.InsideH, b );
            table.SetBorder( TableBorderType.InsideV, b );
            table.SetBorder( TableBorderType.Bottom, b );
            table.SetBorder( TableBorderType.Top, b );
            table.SetBorder( TableBorderType.Left, b );
            table.SetBorder( TableBorderType.Right, b );
            document.InsertTable( table );
            document.InsertParagraph( );
        }

        public static void CsapatlistaTablazatFormazas( Table table ) {
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
        }


        public static void Print( string fileName ) {
            var info = new ProcessStartInfo(fileName.Trim()) {
                Verb = "Print",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start( info );
        }

        public static void Open( string fileName ) {
            Process.Start( fileName );
        }
    }
}
