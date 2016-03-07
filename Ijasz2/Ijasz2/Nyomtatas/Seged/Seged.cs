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
