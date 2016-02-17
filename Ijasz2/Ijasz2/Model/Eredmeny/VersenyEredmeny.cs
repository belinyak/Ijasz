using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Eredmeny {
    public class VersenyEredmeny {
        public Eredmenyek Eredmenyek { get; set; }
        public string VersenyAzonosito { get; set; }


        public VersenyEredmeny(string versenyAzonosito) {
            VersenyAzonosito = versenyAzonosito;
            Eredmenyek = new Eredmenyek {_eredmenyek = new ObservableCollection<Eredmeny>()};
        }
    }
}
