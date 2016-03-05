using System.Collections.Generic;

namespace Ijasz2.Model.Eredmeny {
    public class VersenyEredmenyek {
        public List<VersenyEredmeny> _versenyEredmenyek;

        public void Load() {
            _versenyEredmenyek = Adatbazis.Eredmeny.Eredmeny.Load();
        }
    }
}