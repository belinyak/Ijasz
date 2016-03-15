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

        public VersenysorozatEredmenyLap( string versenysorozatAzonosito ) {
            Versenysorozat = ( from vs in Model.Data.Data.Versenysorozatok._versenysorozatok
                               where vs.Azonosito.Equals( versenysorozatAzonosito )
                               select vs ).First( );
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


            try { Document.Save( ); } catch( Exception ) {
                MessageBox.Show( "A dokumentum meg van nyitva!", "Versenysorozat Teljes Eredménylap", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            return fileName;
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
            table.Rows[0].Cells[0].Paragraphs[0].Append( string.IsNullOrEmpty( Versenysorozat.Megnevezes) ? Versenysorozat.Azonosito : Versenysorozat.Megnevezes ).Bold( );

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
