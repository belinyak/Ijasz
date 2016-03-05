using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Ijasz2.Model.Indulo {
    public class Indulok {
        public ObservableCollection<Indulo> _indulok;

        /// <summary>
        ///     |
        ///     modelhez adas |
        ///     adatbazishoz adas |
        ///     egyesulet tagok novelese |
        /// </summary>
        /// <param name="indulo"></param>
        public void Add(Indulo indulo) {
            _indulok.Add(indulo);
            Adatbazis.Indulo.Indulo.Add(indulo);
            if (!string.IsNullOrEmpty(indulo.Egyesulet)) {
                Data.Data.Egyesuletek.TagokNoveles(indulo.Egyesulet);
            }
        }

        /// <summary>
        ///     |
        ///     eredmenyek == 0 check |
        ///     model torles |
        ///     adatbazis torles |
        ///     TODO msg???? |
        /// </summary>
        /// <param name="indulo"></param>
        public void Remove(Indulo indulo) {
            for (var i = 0; i < _indulok.Count; i++) {
                if (_indulok[i].Eredmenyek.Equals(0)) {
                    _indulok.Remove(_indulok.Single(s => s.Nev.Equals(indulo.Nev)));
                    Adatbazis.Indulo.Indulo.Remove(indulo.Nev);
                    if (!string.IsNullOrEmpty(indulo.Egyesulet)) {
                        Data.Data.Egyesuletek.TagokNoveles(indulo.Egyesulet);
                    }
                    return;
                }
                MessageBox.Show("Ez az induló nem törölhető, mivel van hozzá rendelve eredmény!", "Hiba",
                    MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
        }

        /// <summary>
        ///     |
        ///     TODO utánanézni, hogy mit lehet mosositani |
        ///     model update |
        ///     adatbazis update |
        /// </summary>
        /// <param name="indulo"></param>
        public void Update(Indulo indulo) {
            foreach (var it in _indulok.Where(it => it.Nev.Equals(indulo.Nev))) {
                it.Nem = indulo.Nem;
                it.SzuletesiDatum = indulo.SzuletesiDatum;
                it.Engedely = indulo.Engedely;
                it.Egyesulet = indulo.Egyesulet;
                it.Eredmenyek = indulo.Eredmenyek;
                Adatbazis.Indulo.Indulo.Update(indulo);
                return;
            }
        }

        /// <summary>
        ///     adatbazis betoltes
        /// </summary>
        public void Load() {
            _indulok = Adatbazis.Indulo.Indulo.Load();
        }

        public Indulo Get(string azonosito) {
            var value = new Indulo();
            foreach (var indulo in _indulok.Where(indulo => indulo.Nev.Equals(azonosito))) {
                value = indulo;
                return value;
            }
            return value;
        }

        /// <summary>
        ///     indulo beirasakor novelni az eredmenyt
        /// </summary>
        /// <param name="azonosito"></param>
        public void EredmenyNoveles(string azonosito) {
            foreach (var indulo1 in _indulok.Where(indulo1 => indulo1.Nev.Equals(azonosito))) {
                indulo1.Eredmenyek += 1;
                Adatbazis.Indulo.Indulo.EredmenyekNoveles(azonosito);
                return;
            }
        }

        /// <summary>
        ///     indulo beirasakor novelni az eredmenyt
        /// </summary>
        /// <param name="azonosito"></param>
        public void EredmenyCsokkentes(string azonosito) {
            foreach (var indulo1 in _indulok.Where(indulo1 => indulo1.Nev.Equals(azonosito))) {
                indulo1.Eredmenyek -= 1;
                Adatbazis.Indulo.Indulo.EredmenyekCsokkentes(azonosito);
                return;
            }
        }
    }
}