using System.Drawing;
using System.Windows;
using Ijasz2.Model.Eredmeny;
using Ijasz2.Nyomtatas.Seged;
using Novacode;
using VerticalAlignment = Novacode.VerticalAlignment;

namespace Ijasz2.Nyomtatas.Beirolap {
    class Beirolap {
        private VersenyAdatok versenyAdatok { get; }
        private InduloAdat induloAdat { get; }
        private DocX document { get; set; }
        public Beirolap( Eredmeny eredmeny ) {
            versenyAdatok = new VersenyAdatok( eredmeny.Verseny );
            induloAdat = new InduloAdat( eredmeny );
        }

        private string CreateDoc( ) {
            var fileName = Seged.Seged.CreateFileName(versenyAdatok.VersenysorozatAzonosito, versenyAdatok.Azonosito,
                StartlistaTipus.BeiroLap.ToString());

            document = DocX.Create( fileName );
            document.MarginBottom = 10;
            document.AddHeaders( );

            #region Cimbekezdes
            var titleFormat = new Formatting {Size = 10D, Position = 1, Spacing = 5, Bold = true};
            var header = document.Headers.odd;
            var title = header.InsertParagraph();

            title.Append( Feliratok.HeadLineBeirolap );
            title.Alignment = Alignment.center;
            titleFormat.Size = 10D;
            title.AppendLine( Feliratok.Tulajdonos );
            title.AppendLine( );
            title.Bold( );
            titleFormat.Position = 12;
            #endregion

            VersenyTablazat( );
            InduloTablazat( );
            EredmenyTablazat( );
            AlairasTablazat( );

            try { document.Save( ); } catch( System.Exception ) { MessageBox.Show( "A dokumentum meg van nyitva!", "Nevezési lista", MessageBoxButton.OK, MessageBoxImage.Error ); }
            return fileName;
        }
        public void Print( ) {
            Seged.Seged.Print( CreateDoc( ) );
        }
        public void Open( ) {
            Seged.Seged.Open( CreateDoc( ) );
        }

        private void AlairasTablazat( ) {
            document.AddFooters( );
            var footer = document.Footers.odd;
            var table = footer.InsertTable(3, 2);
            table.Alignment = Alignment.center;
            table.AutoFit = AutoFit.ColumnWidth;
            foreach( var row in table.Rows ) {
                row.Cells[0].Width = 150;
                row.Cells[1].Width = 150;
                row.Cells[0].Paragraphs[0].Alignment = Alignment.center;
                row.Cells[1].Paragraphs[0].Alignment = Alignment.center;
            }
            table.Rows[1].Height = 25;
            table.Rows[1].Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            table.Rows[1].Cells[1].VerticalAlignment = VerticalAlignment.Bottom;

            const string pontok = "...................................";
            const string beiroAlairas = "Beíró aláírása";
            const string induloAlairas = "Versenyző aláírása";

            table.Rows[0].Cells[0].Paragraphs[0].Append( pontok );
            table.Rows[0].Cells[1].Paragraphs[0].Append( pontok );
            table.Rows[1].Cells[0].Paragraphs[0].Append( beiroAlairas );
            table.Rows[1].Cells[1].Paragraphs[0].Append( induloAlairas );

            Border b = new Border(Novacode.BorderStyle.Tcbs_none, BorderSize.seven, 0, Color.Beige);
            table.SetBorder( TableBorderType.InsideH, b );
            table.SetBorder( TableBorderType.InsideV, b );
            table.SetBorder( TableBorderType.Bottom, b );
            table.SetBorder( TableBorderType.Top, b );
            table.SetBorder( TableBorderType.Left, b );
            table.SetBorder( TableBorderType.Right, b );
        }
        private void InduloTablazat( ) {
            var table = document.AddTable(4, 2);
            table.Alignment = Alignment.left;

            table.Rows[0].Cells[0].Paragraphs[0].Append( Feliratok.Sorszam );
            table.Rows[0].Cells[0].Paragraphs[0].Append( induloAdat.Sorszam.ToString( ) ).FontSize( 14 ).Bold( );
            table.Rows[1].Cells[0].Paragraphs[0].Append( Feliratok.Nev );
            table.Rows[1].Cells[0].Paragraphs[0].Append( induloAdat.Nev ).FontSize( 14 ).Bold( );
            table.Rows[2].Cells[0].Paragraphs[0].Append( Feliratok.Egyesulet );
            table.Rows[2].Cells[0].Paragraphs[0].Append( induloAdat.Egyesulet ).Bold( );
            table.Rows[3].Cells[0].Paragraphs[0].Append( Feliratok.Ijtipus );
            table.Rows[3].Cells[0].Paragraphs[0].Append( induloAdat.Ijtipus ).Bold( );

            table.Rows[0].Cells[1].Paragraphs[0].Append( Feliratok.Csapat );
            table.Rows[0].Cells[1].Paragraphs[0].Append( induloAdat.Csapat.ToString( ) ).Bold( );
            table.Rows[1].Cells[1].Paragraphs[0].Append( Feliratok.Kor );
            table.Rows[1].Cells[1].Paragraphs[0].Append( induloAdat.Kor.ToString( ) ).Bold( );
            table.Rows[2].Cells[1].Paragraphs[0].Append( Feliratok.Korosztaly );
            table.Rows[2].Cells[1].Paragraphs[0].Append( induloAdat.KorosztalyMegnevezes ).Bold( );
            if( !string.IsNullOrEmpty( induloAdat.Engedely ) ) {
                table.Rows[3].Cells[1].Paragraphs[0].Append( Feliratok.Engedely );
                table.Rows[4].Cells[1].Paragraphs[0].Append( induloAdat.Engedely ).Bold( );
            }
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
        private void VersenyTablazat( ) {
            var table = document.AddTable(2, 2);
            table.Alignment = Alignment.left;
            table.Rows[0].Cells[0].Paragraphs[0].Append( Feliratok.VersenyMegnevezes );
            table.Rows[0].Cells[0].Paragraphs[0].Append( string.IsNullOrEmpty( versenyAdatok.Megnevezes ) ? versenyAdatok.Azonosito : versenyAdatok.Megnevezes ).Bold( );

            if( !string.IsNullOrEmpty( versenyAdatok.VersenysorozatAzonosito ) ) {
                table.Rows[0].Cells[1].Paragraphs[0].Append( Feliratok.VersenySorozat );
                table.Rows[0].Cells[1].Paragraphs[0].Append( string.IsNullOrEmpty( versenyAdatok.VersenysorozatMegnevezes ) ? versenyAdatok.VersenysorozatAzonosito : versenyAdatok.VersenysorozatMegnevezes ).Bold( );
            }

            table.Rows[1].Cells[0].Paragraphs[0].Append( Feliratok.VersenyDatum );
            table.Rows[1].Cells[0].Paragraphs[0].Append( versenyAdatok.Datum ).Bold( );

            table.Rows[1].Cells[1].Paragraphs[0].Append( Feliratok.OsszesPont );
            table.Rows[1].Cells[1].Paragraphs[0].Append( ( versenyAdatok.OsszesPont * 10 ).ToString( ) ).Bold( );

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
        private void EredmenyTablazat( ) {
            var table = document.AddTable(versenyAdatok.AllomasokSzama + 3, 8);
            table.Alignment = Alignment.center;

            table.Rows[0].Cells[0].Paragraphs[0].Append( "Sorszám" ).Bold( );
            table.Rows[0].Cells[1].Paragraphs[0].Append( "Lőállás" ).Bold( );
            table.Rows[0].Cells[2].Paragraphs[0].Append( "10 pont" ).Bold( );
            table.Rows[0].Cells[3].Paragraphs[0].Append( "8 pont" ).Bold( );
            table.Rows[0].Cells[4].Paragraphs[0].Append( "5 pont" ).Bold( );
            table.Rows[0].Cells[5].Paragraphs[0].Append( "Mellé" ).Bold( );
            table.Rows[0].Cells[6].Paragraphs[0].Append( "Összesen" ).Bold( );
            table.Rows[0].Cells[7].Paragraphs[0].Append( "Göngyölt" ).Bold( );

            for( var i = 1; i < versenyAdatok.AllomasokSzama; i++ ) {
                table.Rows[i].Cells[0].Paragraphs[0].Append( i.ToString( ) );
            }

            table.Rows[versenyAdatok.AllomasokSzama + 1].Cells[1].Paragraphs[0].Append( "Össz db" ).Bold( );
            table.Rows[versenyAdatok.AllomasokSzama + 2].Cells[1].Paragraphs[0].Append( "Össz pont" ).Bold( );
            document.InsertTable( table );
            document.InsertParagraph( );

            #region Formazas
            table.AutoFit = AutoFit.Contents;
            #endregion
        }
    }

}
