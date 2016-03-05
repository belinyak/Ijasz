using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Indulo {
    public struct CsapatIndulo{
        public string Indulo { get; set; }
        public string Korosztaly { get; set; }
        public string Ijtipus { get; set; }
        public string Egyesulet { get; set; }
    }

    public class Csapat {
        public int Azonosito { get; set; }
        public int IndulokSzama { get; set; }

        public List<CsapatIndulo> CsapatIndulok { get; set; }
    }
}
