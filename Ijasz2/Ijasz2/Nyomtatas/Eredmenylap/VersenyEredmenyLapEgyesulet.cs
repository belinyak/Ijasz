using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using Ijasz2.Nyomtatas.Seged;

namespace Ijasz2.Nyomtatas.Eredmenylap {

    public struct Egyesulet {
        public string Nev { get; set; }
        public string Cim { get; set; }
        public int OsszPont { get; set; }
    }

    public struct Egyesuletek {
        public List<Egyesulet> egyesuletek { get; set; }

        /// <summary>
        /// | TODO adatbazis lekerdezes helyett LinQ |
        /// </summary>
        /// <param name="versenyAzonosito"></param>
        public Egyesuletek( string versenyAzonosito ) {
            egyesuletek = Adatbazis.Egyesulet.Egyesulet.EredmenyLap(versenyAzonosito);
        }
    }

    public class VersenyEredmenyLapEgyesulet {
        private VersenyAdatok versenyAdatok;
        private Egyesuletek egyesuletek;

        public VersenyEredmenyLapEgyesulet( string versenyAzonosito ) {
            versenyAdatok = new VersenyAdatok( versenyAzonosito );
            egyesuletek = new Egyesuletek( versenyAzonosito );
        }
    }
}
