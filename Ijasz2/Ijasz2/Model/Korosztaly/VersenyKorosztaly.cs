using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Korosztaly {
    public class VersenyKorosztaly {
        public ObservableCollection<Korosztaly> Korosztalyok { get; set; }
        public string VersenyAzonosito { get; set; }

        public VersenyKorosztaly() {
        }

        public VersenyKorosztaly(string versenyAzonosito) {
            VersenyAzonosito = versenyAzonosito;
            Korosztalyok = new ObservableCollection<Korosztaly>();
        }
    }
}
