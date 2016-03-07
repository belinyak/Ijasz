using System.Windows;
using Ijasz2.Nyomtatas.Seged;
using Novacode;
using System.Drawing;

namespace Ijasz2.Nyomtatas.Startlista {
    class HianyzokLista {
        public VersenyAdatok versenyAdatok { get; set; }
        public InduloAdatok induloAdatok { get; set; }
        public HianyzokLista( string versenyAzonosito ) {
            versenyAdatok = new VersenyAdatok( versenyAzonosito, true );
            induloAdatok = new InduloAdatok( versenyAzonosito, true );
        }

        private string CreateDoc( ) {
            string fileName = Seged.Seged.CreateFileName(versenyAdatok.VersenysorozatAzonosito, versenyAdatok.Azonosito, StartlistaTipus.HianyzokLista);
            var document = DocX.Create(fileName);
            Seged.Seged.OldalSzamozas( document );
            document.DifferentFirstPage = true;

            #region FirstPageFooter
            Footer footer = document.Footers.first;

            Table footerTable = footer.InsertTable( 1, 2 );
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
            #endregion

            #region Cimbekezdes
            var titleFormat = new Formatting( );
            titleFormat.Size = 14D;
            titleFormat.Position = 1;
            titleFormat.Spacing = 5;
            titleFormat.Bold = true;

            document.AddHeaders( );
            Header FirstPageHeader = document.Headers.first;

            Paragraph title = FirstPageHeader.InsertParagraph();
            title.Append( Seged.Feliratok.HeadLineHianyzoklista );
            title.Alignment = Alignment.center;
            titleFormat.Size = 10D;
            title.AppendLine( Seged.Feliratok.Tulajdonos );
            title.AppendLine( );
            title.Bold( );
            titleFormat.Position = 12;

            #endregion

            #region Header

            var titleFormat2 = new Formatting( );
            titleFormat2.Size = 10D;
            titleFormat2.Position = 1;

            Paragraph paragraph_1 = FirstPageHeader.InsertParagraph( Seged.Feliratok.VersenyMegnevezes, false, titleFormat2 );

            paragraph_1.Append( string.IsNullOrEmpty( versenyAdatok.Megnevezes ) ? versenyAdatok.Azonosito : versenyAdatok.Megnevezes );
            paragraph_1.Bold( );
            titleFormat2.Bold = false;
            paragraph_1.AppendLine( Feliratok.VersenyDatum );
            paragraph_1.Append( versenyAdatok.Datum );
            paragraph_1.Bold( );
            paragraph_1.Append( "\t\t" + Feliratok.OsszesPont );
            paragraph_1.Append( ( versenyAdatok.OsszesPont * 10 ).ToString( ) );
            paragraph_1.Bold( );
            paragraph_1.Append( "\t\t" + Feliratok.VersenyHianyzokSzama );
            paragraph_1.Append( versenyAdatok.IndulokSzama.ToString( ) );
            paragraph_1.Bold( );

            if( !string.IsNullOrEmpty( versenyAdatok.VersenysorozatAzonosito ) ) {
                paragraph_1.AppendLine( Feliratok.VersenySorozat );
                paragraph_1.Append( string.IsNullOrEmpty( versenyAdatok.VersenysorozatMegnevezes ) ? versenyAdatok.VersenysorozatAzonosito : versenyAdatok.VersenysorozatMegnevezes );
                paragraph_1.Bold( );
            }
            paragraph_1.AppendLine( );
            #endregion

            #region HeaderTable
            var tablazatFejlec = document.Headers.odd;

            var headerTable = document.AddTable( 1, 6 );
            headerTable.AutoFit = AutoFit.ColumnWidth;

            headerTable.Rows[0].Cells[0].Paragraphs[0].Append( "Sorszám" );
            headerTable.Rows[0].Cells[1].Paragraphs[0].Append( "Név" );
            headerTable.Rows[0].Cells[2].Paragraphs[0].Append( "Íjtípus" );
            headerTable.Rows[0].Cells[3].Paragraphs[0].Append( "Kor" );
            headerTable.Rows[0].Cells[4].Paragraphs[0].Append( "Egyesület" );
            headerTable.Rows[0].Cells[5].Paragraphs[0].Append( "Csapat" );

            Seged.Seged.NevezesiListaTablazatFormazas( headerTable );
            tablazatFejlec.InsertTable( headerTable );
            #endregion

            Table table = document.AddTable( versenyAdatok.IndulokSzama + 1, 6 );

            table.Rows[0].Cells[0].Paragraphs[0].Append( "Sorszám" );
            table.Rows[0].Cells[1].Paragraphs[0].Append( "Név" );
            table.Rows[0].Cells[2].Paragraphs[0].Append( "Íjtípus" );
            table.Rows[0].Cells[3].Paragraphs[0].Append( "Kor" );
            table.Rows[0].Cells[4].Paragraphs[0].Append( "Egyesület" );
            table.Rows[0].Cells[5].Paragraphs[0].Append( "Csapat" );
            //TODO itt baj van
            /*
            for( int i = 0; i < versenyAdatok.IndulokSzama; i++ ) {
                table.Rows[i + 1].Cells[0].Paragraphs[0].Append( induloAdatok.Indulok[i].Sorszam.ToString( ) );
                table.Rows[i + 1].Cells[1].Paragraphs[0].Append( induloAdatok.Indulok[i].Nev );
                table.Rows[i + 1].Cells[2].Paragraphs[0].Append( induloAdatok.Indulok[i].Ijtipus );
                table.Rows[i + 1].Cells[3].Paragraphs[0].Append( ( induloAdatok.Indulok[i].Kor.ToString( ) ) );
                table.Rows[i + 1].Cells[4].Paragraphs[0].Append( induloAdatok.Indulok[i].Egyesulet );
                table.Rows[i + 1].Cells[5].Paragraphs[0].Append( induloAdatok.Indulok[i].Csapat.ToString( ) );
            }
            */
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

            Seged.Seged.NevezesiListaTablazatFormazas( table );
            document.InsertTable( table );

            try { document.Save( ); } catch( System.Exception ) { MessageBox.Show( "A dokumentum meg van nyitva!", "Nevezési lista", MessageBoxButton.OK, MessageBoxImage.Error ); }
            return fileName;
        }
        public void Print( ) {
            Seged.Seged.Print( CreateDoc( ) );
        }
        public void Open( ) {
            Seged.Seged.Open( CreateDoc( ) );
        }
    }
}
