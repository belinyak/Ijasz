using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Megjelenites.Korosztaly {
    public struct KorosztalyMessage {
        public string VersenyAzonosito { get; set; }
        public string VersenysorozatAzonosito { get; set; }
        public string KorosztalyAzonosito { get; set; }
    }

    public struct KorosztalyInfo {
        public string KorosztalyAzonosito { get; set; }
        public List<KorosztalyMessage> KorosztalyMessages { get; set; }
    }
    public class Korosztaly_Info {
        public KorosztalyInfo korosztalyInfo { get; set; }
        public Korosztaly_Info( KorosztalyInfo info ) {
            korosztalyInfo = info;
        }
    }
}
