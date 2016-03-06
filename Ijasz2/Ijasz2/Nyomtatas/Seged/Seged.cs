﻿using System.Diagnostics;
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
        public static string CreateFileName( string versenysorozat, string verseny, DokumentumTipus dokumentumTipus ) {
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

        public static void OldalSzamozas( DocX document ) {
            document.AddFooters( );
            var footer = document.Footers.odd;

            var footerTable = footer.InsertTable(1, 2);
            footerTable.Rows[0].Cells[1].Paragraphs[0].InsertPageNumber( PageNumberFormat.normal, 0 );
            footerTable.Rows[0].Cells[1].Paragraphs[0].Append( ". oldal" );
            footerTable.AutoFit = AutoFit.ColumnWidth;
            footerTable.Rows[0].Cells[0].Width = document.PageWidth - 220;
            footerTable.Rows[0].Cells[1].Width = 70;

            Border c = new Border(Novacode.BorderStyle.Tcbs_none, BorderSize.seven, 0, Color.Black );
            footerTable.SetBorder( TableBorderType.InsideH, c );
            footerTable.SetBorder( TableBorderType.InsideV, c );
            footerTable.SetBorder( TableBorderType.Bottom, c );
            footerTable.SetBorder( TableBorderType.Top, c );
            footerTable.SetBorder( TableBorderType.Left, c );
            footerTable.SetBorder( TableBorderType.Right, c );
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
