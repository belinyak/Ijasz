using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Ijtipus {
    public class Ijtipusok {
        public ObservableCollection<Ijtipus> _ijtipusok;

        public void Add(Ijtipus ijtipus) {
            _ijtipusok.Add(ijtipus);
        }

        /// <summary>
        /// figyelni kell, hogy csak akkor torolheto, ha eredmenyek 0
        /// </summary>
        /// <param name="ijtipus"></param>
        public void Remove(Ijtipus ijtipus) {
            if (ijtipus.Eredmenyek.Equals(0)) {
                _ijtipusok.Remove(
                        _ijtipusok.Single(
                            s => s.Azonosito.Equals( ijtipus.Azonosito ) ) );
            }
        }

        /// <summary>
        /// itt kell-e módosítani az eredményt??
        /// </summary>
        /// <param name="ijtipus"></param>
        public void Modify(Ijtipus ijtipus) {
            for (int i = 0; i < _ijtipusok.Count; i++) {
                if (_ijtipusok[i].Azonosito.Equals(ijtipus.Azonosito)) {
                    _ijtipusok[i].Megnevezes = ijtipus.Megnevezes;
                    _ijtipusok[i].Sorszam = ijtipus.Sorszam;
                    _ijtipusok[i].Eredmenyek = ijtipus.Eredmenyek;
                }
            }
        }

        public void Load() {
            _ijtipusok = new ObservableCollection<Ijtipus> {
                new Ijtipus {Azonosito = "it1", Megnevezes = "ijtipus1", Sorszam = 1, Eredmenyek = 0},
                new Ijtipus {Azonosito = "it2", Megnevezes = "ijtipus2", Sorszam = 2, Eredmenyek = 0},
                new Ijtipus {Azonosito = "it3", Megnevezes = "ijtipus3", Sorszam = 3, Eredmenyek = 0}
            };
        }
    }
}
