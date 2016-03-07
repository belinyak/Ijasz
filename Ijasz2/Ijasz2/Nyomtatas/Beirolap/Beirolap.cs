using System.Windows;
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
            document.InsertParagraph();
            document.InsertParagraph();
            document.InsertParagraph();
            document.InsertParagraph();
            document.InsertParagraph();
            Seged.Seged.BeirolapAlairasTablazas(document);
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
