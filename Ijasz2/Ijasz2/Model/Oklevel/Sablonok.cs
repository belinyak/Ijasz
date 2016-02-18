using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Oklevel {
    public class Sablonok {
        public ObservableCollection<Sablon> _sablonok;

        public void Add( Sablon sablon ) {
            _sablonok.Add( sablon );
        }

        public void Modify( Sablon sablon ) {
            foreach (var sablon1 in _sablonok) {
                if (sablon1.Azonosito.Equals(sablon.Azonosito)) {
                    _sablonok.Remove(sablon1);
                    _sablonok.Add(sablon);
                    return;
                }
            }
        }

        public void Remove( Sablon sablon ) {
            _sablonok.Remove( sablon );
        }

        public void Remove( string  azonosito) {
            foreach (var sablon in _sablonok) {
                if (sablon.Azonosito.Equals(azonosito)) {
                    _sablonok.Remove(sablon);
                    return;
                }
            }
        }

        public void Load( ) {
            _sablonok = new ObservableCollection<Sablon>();

            Model.Data.Data.Sablonok.Add(new Sablon {
                Azonosito = "test",
                Tipus = "Verseny",
                Verseny = new SablonMezo( ) {
                    X = 10,
                    Y = 20
                }
            });
        }
    }
}
