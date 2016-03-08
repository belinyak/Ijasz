using System;
using System.Diagnostics;
using System.Drawing;
using Novacode;

namespace Ijasz2.Nyomtatas.Seged {
    public class Seged {

        /// <summary> | 
        /// mappazas kesz van |
        /// </summary>
        /// <param name="versenysorozat"></param>
        /// <param name="verseny"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string CreateFileName( string versenysorozat, string verseny, string file ) {
            var path = "";
            var dokumentumTipus = file.Contains("Verseny") ? "Eredménylapok" : "Startlisták";
            const string dokumentumok = "Dokumentumok";

            if( string.IsNullOrEmpty( versenysorozat ) ) {
                path = dokumentumok + "\\" + verseny + "\\" + dokumentumTipus;
                System.IO.Directory.CreateDirectory( dokumentumok );
                System.IO.Directory.CreateDirectory( dokumentumok + "\\" + verseny );
                System.IO.Directory.CreateDirectory( dokumentumok + "\\" + verseny + "\\" + dokumentumTipus );
            }
            else {
                path = dokumentumok + "\\" + versenysorozat + "\\" + verseny + "\\" + dokumentumTipus;
                System.IO.Directory.CreateDirectory( dokumentumok );
                System.IO.Directory.CreateDirectory( dokumentumok + "\\" + versenysorozat );
                System.IO.Directory.CreateDirectory( dokumentumok + "\\" + versenysorozat + "\\" + verseny );
                System.IO.Directory.CreateDirectory( dokumentumok + "\\" + versenysorozat + "\\" + verseny + "\\" + dokumentumTipus );
            }
            var fileName =  path + "\\" +  file + ".docx";
            return fileName;
        }

        public static void OldalSzamozas( DocX document ) {
            document.AddFooters( );
            var footer = document.Footers.odd;

            var footerTable = footer.InsertTable(1, 2);
            footerTable.Rows[0].Cells[1].Paragraphs[0].InsertPageNumber( PageNumberFormat.normal, 0 );
            footerTable.Rows[0].Cells[1].Paragraphs[0].Append( ". oldal" );
            footerTable.AutoFit = AutoFit.ColumnWidth;
            footerTable.Rows[0].Cells[0].Width = document.PageWidth;
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
