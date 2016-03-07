using System;
using System.Windows;
using Ijasz2.Model.Data;
using Ijasz2.Model.Eredmeny;
using Ijasz2.Nyomtatas.Seged;
using Novacode;

namespace Ijasz2.Nyomtatas.Beirolap {
    class Beirolap {
        private VersenyAdatok _versenyAdatok;
        private InduloAdat _induloAdat;
        public Beirolap( Eredmeny eredmeny ) {
            _versenyAdatok = new VersenyAdatok( eredmeny.Verseny );
            _induloAdat = new InduloAdat( eredmeny );
        }

        private string CreateDoc( ) {
            var fileName = Seged.Seged.CreateFileName(_versenyAdatok.VersenysorozatAzonosito, _versenyAdatok.Azonosito,
                StartlistaTipus.BeiroLap);

            var document = DocX.Create(fileName);
            document.MarginBottom = 10;
            document.AddHeaders( );

            #region Cimbekezdes
            var titleFormat = new Formatting( );
            titleFormat.Size = 10D;
            titleFormat.Position = 1;
            titleFormat.Spacing = 5;
            titleFormat.Bold = true;

            var header = document.Headers.odd;

            Paragraph title = header.InsertParagraph();
            title.Append( Seged.Feliratok.HeadLineBeirolap );
            title.Alignment = Alignment.center;
            titleFormat.Size = 10D;
            title.AppendLine( Seged.Feliratok.Tulajdonos );
            title.AppendLine( );
            title.Bold( );
            titleFormat.Position = 12;
            #endregion

            Seged.Seged.BeirolapHeaderTablazat( document, _versenyAdatok );
            Seged.Seged.BeirolapInduloTablazat( document, _induloAdat );

            #region Adatok
            var table = document.AddTable(_versenyAdatok.AllomasokSzama + 3, 8);
            table.Alignment = Alignment.center;

            table.Rows[0].Cells[0].Paragraphs[0].Append( "Sorszám" ).Bold( );
            table.Rows[0].Cells[1].Paragraphs[0].Append( "Lőállás" ).Bold( );
            table.Rows[0].Cells[2].Paragraphs[0].Append( "10 pont" ).Bold( );
            table.Rows[0].Cells[3].Paragraphs[0].Append( "8 pont" ).Bold( );
            table.Rows[0].Cells[4].Paragraphs[0].Append( "5 pont" ).Bold( );
            table.Rows[0].Cells[5].Paragraphs[0].Append( "Mellé" ).Bold( );
            table.Rows[0].Cells[6].Paragraphs[0].Append( "Összesen" ).Bold( );
            table.Rows[0].Cells[7].Paragraphs[0].Append( "Göngyölt" ).Bold( );

            for( var i = 1; i < _versenyAdatok.AllomasokSzama; i++ ) {
                table.Rows[i].Cells[0].Paragraphs[0].Append( i.ToString( ) );
            }

            table.Rows[_versenyAdatok.AllomasokSzama + 1].Cells[1].Paragraphs[0].Append( "Össz db" ).Bold( );
            table.Rows[_versenyAdatok.AllomasokSzama + 2].Cells[1].Paragraphs[0].Append( "Össz pont" ).Bold( );
            document.InsertTable( table );
            document.InsertParagraph();
            Seged.Seged.BeirolapAdatTablazatFormazas(table);
            #endregion


            Seged.Seged.BeirolapAlairasTablazat( document );
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
