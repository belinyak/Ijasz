using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Ijasz2.Model.Versenysorozat {
    public class Versenysorozatok {
        public ObservableCollection<Versenysorozat> _versenysorozatok;

        public void Add(Versenysorozat versenysorozat) {
            _versenysorozatok.Add(versenysorozat);
        }

        public void Remove(string azonosito) {
            _versenysorozatok.Remove(
                    _versenysorozatok.Single(
                        s => s.Azonosito.Equals( azonosito  ) ));
        }

        public void Modify(string azonosito, Versenysorozat old) {
            throw new NotImplementedException();
        }

        public void Load() {
            _versenysorozatok = new ObservableCollection<Versenysorozat> {
                new Versenysorozat("vs1", "versenysorozat1", 0),
                new Versenysorozat("vs2", "versenysorozat1", 0),
                new Versenysorozat("vs3", "versenysorozat1", 0)
            };
        }
    }
}
