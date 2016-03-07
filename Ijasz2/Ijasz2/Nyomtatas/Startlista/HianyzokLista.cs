using System.Windows;
using Ijasz2.Nyomtatas.Seged;
using Novacode;
using System.Drawing;

namespace Ijasz2.Nyomtatas.Startlista {
    class HianyzokLista {
        private VersenyAdatok versenyAdatok { get; set; }
        private InduloAdatok induloAdatok { get; set; }
        private DocX document { get; set; }

        public HianyzokLista( string versenyAzonosito ) {
            versenyAdatok = new VersenyAdatok( versenyAzonosito );
            induloAdatok = new InduloAdatok( versenyAzonosito, true );
        }

        private string CreateDoc( ) {
            var fileName = Seged.Seged.CreateFileName(versenyAdatok.VersenysorozatAzonosito, versenyAdatok.Azonosito, StartlistaTipus.HianyzokLista);
            document = DocX.Create( fileName );
            Seged.Seged.OldalSzamozas( document );
            document.DifferentFirstPage = true;

            FirstPageFooter( );
            AddHeader( );
            HianyzoklistaHeaderTablazat( );
            HeaderTablazat( );
            HianyzokListaTablazat( );

            try { document.Save( ); } catch( System.Exception ) { MessageBox.Show( "A dokumentum meg van nyitva!", "Nevezési lista", MessageBoxButton.OK, MessageBoxImage.Error ); }
            return fileName;
        }
        public void Print( ) {
            Seged.Seged.Print( CreateDoc( ) );
        }
        public void Open( ) {
            Seged.Seged.Open( CreateDoc( ) );
        }

        private void FirstPageFooter( ) {
            var footer = document.Footers.first;

            var footerTable = footer.InsertTable( 1, 2 );
            footerTable.Rows[0].Cells[1].Paragraphs[0].Append( "1. oldal" );
            footerTable.AutoFit = AutoFit.ColumnWidth;
            footerTable.Rows[0].Cells[0].Width = document.PageWidth - 200;
            footerTable.Rows[0].Cells[1].Width = 60;

            Border c = new Border( Novacode.BorderStyle.Tcbs_none, BorderSize.seven, 0, Color.Black);
            footerTable.SetBorder( TableBorderType.InsideH, c );
            footerTable.SetBorder( TableBorderType.InsideV, c );
            footerTable.SetBorder( TableBorderType.Bottom, c );
            footerTable.SetBorder( TableBorderType.Top, c );
            footerTable.SetBorder( TableBorderType.Left, c );
            footerTable.SetBorder( TableBorderType.Right, c );
        }
        private void AddHeader( ) {
            var titleFormat = new Formatting( );
            titleFormat.Size = 14D;
            titleFormat.Position = 1;
            titleFormat.Spacing = 5;
            titleFormat.Bold = true;

            document.AddHeaders( );
            var FirstPageHeader = document.Headers.first;

            var title = FirstPageHeader.InsertParagraph();
            title.Append( Seged.Feliratok.HeadLineHianyzoklista );
            title.Alignment = Alignment.center;
            titleFormat.Size = 10D;
            title.AppendLine( Seged.Feliratok.Tulajdonos );
            title.AppendLine( );
            title.Bold( );
            titleFormat.Position = 12;
        }
        private void HianyzoklistaHeaderTablazat( ) {
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
        private void HianyzokListaTablazat( ) {

            Table table = document.AddTable( versenyAdatok.HianyzokSzama + 1, 6 );

            table.Rows[0].Cells[0].Paragraphs[0].Append( "Sorszám" );
            table.Rows[0].Cells[1].Paragraphs[0].Append( "Név" );
            table.Rows[0].Cells[2].Paragraphs[0].Append( "Íjtípus" );
            table.Rows[0].Cells[3].Paragraphs[0].Append( "Kor" );
            table.Rows[0].Cells[4].Paragraphs[0].Append( "Egyesület" );
            table.Rows[0].Cells[5].Paragraphs[0].Append( "Csapat" );

            var rowIndex = 1;
            foreach( var indulo in induloAdatok.Indulok ) {
                table.Rows[rowIndex].Cells[0].Paragraphs[0].Append( indulo.Sorszam.ToString( ) );
                table.Rows[rowIndex].Cells[1].Paragraphs[0].Append( indulo.Nev );
                table.Rows[rowIndex].Cells[2].Paragraphs[0].Append( indulo.Ijtipus );
                table.Rows[rowIndex].Cells[3].Paragraphs[0].Append( ( indulo.Kor.ToString( ) ) );
                table.Rows[rowIndex].Cells[4].Paragraphs[0].Append( indulo.Egyesulet );
                table.Rows[rowIndex].Cells[5].Paragraphs[0].Append( indulo.Csapat.ToString( ) );
                rowIndex++;
            }

            #region Formazas
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

            foreach( var row in table.Rows ) {
                row.Cells[0].Width = 70;
                row.Cells[1].Width = 200;
                row.Cells[2].Width = 150;
                row.Cells[3].Width = 40;
                row.Cells[4].Width = 150;
                row.Cells[5].Width = 70;
            }

            table.AutoFit = AutoFit.ColumnWidth;
            #endregion
            document.InsertTable( table );
        }

        private void HeaderTablazat( ) {
            var tablazatFejlec = document.Headers.odd;

            var table = document.AddTable( 1, 6 );
            table.AutoFit = AutoFit.ColumnWidth;

            table.Rows[0].Cells[0].Paragraphs[0].Append( "Sorszám" );
            table.Rows[0].Cells[1].Paragraphs[0].Append( "Név" );
            table.Rows[0].Cells[2].Paragraphs[0].Append( "Íjtípus" );
            table.Rows[0].Cells[3].Paragraphs[0].Append( "Kor" );
            table.Rows[0].Cells[4].Paragraphs[0].Append( "Egyesület" );
            table.Rows[0].Cells[5].Paragraphs[0].Append( "Csapat" );

            #region Formazas
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
            #endregion
            tablazatFejlec.InsertTable( table );
        }

    }
}
