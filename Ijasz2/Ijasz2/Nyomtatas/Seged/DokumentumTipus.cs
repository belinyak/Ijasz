using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Nyomtatas.Seged {
    public enum StartlistaTipus {
        NevezesiLista,
        HianyzokLista,
        CsapatLista,
        BeiroLap
    }

    public enum EredmenylapTipus {
        Verseny_Teljes,
        Verseny_MISZ,
        Verseny_Egyesulet,
        Verseny_Reszletes,

        Versenysorozat_Teljes,
        Versenysorozat_MISZ,
        Versenysorozat_Egyesulet,
        Versenysorozat_Reszletes
    }
}
