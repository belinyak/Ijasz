using Ijasz2.Model.Eredmeny;
using Ijasz2.Nyomtatas.Seged;

namespace Ijasz2.Nyomtatas.Beirolap {
    class Beirolap {
        private VersenyAdatok _versenyAdatok;
        private InduloAdat _induloAdat;
        public Beirolap( Eredmeny eredmeny ) {
            _versenyAdatok = new VersenyAdatok( eredmeny.Verseny );
            _induloAdat = new InduloAdat( eredmeny );

        }

        private string CreateDoc( ) {
            return null;
        }

        public void Print( ) {
            Seged.Seged.Print( CreateDoc( ) );
        }

        public void Open( ) {
            Seged.Seged.Open( CreateDoc( ) );
        }
    }

}
