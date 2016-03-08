using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Nyomtatas.Seged {
    public static class DokumentumTipus {
        public static class Eredmenylap {
            public static class Verseny {
                public const string Teljes = "Teljes";
                public const string MISZ = "MISZ";
                public const string Egyesulet = "Egyesulet";
                public const string Reszletes = "Reszletes";
            }
            public static class VersenySorozat {
                public const string Teljes = "Teljes";
                public const string MISZ = "MISZ";
                public const string Egyesulet = "Egyesulet";
                public const string Reszletes = "Reszletes";
            }
        }
        public static class Startlista {
            public const string NevezesiLista = "NevezesiLista";
            public const string HianyzokLista = "HianyzokLista";
            public const string CsapatLista = "CsapatLista";
            public const string BeiroLap = "BeiroLap";
        }

        public static class Oklevel {
            public static class Verseny {
                public const string Oklevel = "Oklevel";
            }
        }
    }
}
