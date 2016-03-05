using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Ijasz2.Model.Egyesulet {
    public class Egyesuletek {
        public ObservableCollection<Egyesulet> _egyesuletek;

        /// <summary>
        ///     |
        ///     model add
        ///     adatbazis add
        /// </summary>
        /// <param name="egyesulet"></param>
        public void Add(Egyesulet egyesulet) {
            _egyesuletek.Add(egyesulet);
            Adatbazis.Egyesulet.Egyesulet.Add(egyesulet);
        }

        /// <summary>
        ///     |
        ///     csak akkor torolheto, ha tagokszama 0 |
        ///     model torles |
        ///     adatbazis torles |
        /// </summary>
        /// <param name="egyesulet"></param>
        public void Remove(Egyesulet egyesulet) {
            if (egyesulet.TagokSzama.Equals(0)) {
                _egyesuletek.Remove(
                    _egyesuletek.Single(
                        s => s.Azonosito.Equals(egyesulet.Azonosito)));
                Adatbazis.Egyesulet.Egyesulet.Remove(egyesulet.Azonosito);
                return;
            }
            MessageBox.Show("Ez az egyesület nem törölhető, mivel van hozzá rendelve induló!", "Hiba",
                MessageBoxButton.OKCancel, MessageBoxImage.Information);
        }

        /// <summary>
        ///     |
        ///     model update |
        ///     adatbazis update |
        /// </summary>
        /// <param name="_egyesulet"></param>
        public void Update(Egyesulet _egyesulet) {
            foreach (var egyesulet in _egyesuletek.Where(egyesulet => egyesulet.Azonosito.Equals(_egyesulet.Azonosito))) {
                egyesulet.Cim = _egyesulet.Cim;
                egyesulet.Vezeto = _egyesulet.Vezeto;
                egyesulet.Telefon1 = _egyesulet.Telefon1;
                egyesulet.Telefon2 = _egyesulet.Telefon2;
                egyesulet.Email1 = _egyesulet.Email1;
                egyesulet.Email2 = _egyesulet.Email2;
                egyesulet.Listazando = _egyesulet.Listazando;
                egyesulet.TagokSzama = _egyesulet.TagokSzama;
                Adatbazis.Egyesulet.Egyesulet.Update(egyesulet);
            }
        }

        /// <summary>
        ///     |
        ///     adatok betoltese adatbazisbol |
        /// </summary>
        public void Load() {
            _egyesuletek = Adatbazis.Egyesulet.Egyesulet.Load();
        }

        public void TagokNoveles(string azonosito) {
            foreach (var egyesulet in _egyesuletek.Where(egyesulet => egyesulet.Azonosito.Equals(azonosito))) {
                egyesulet.TagokSzama += 1;
                Adatbazis.Egyesulet.Egyesulet.TagokNoveles(azonosito);
                return;
            }
        }

        public void TagokCsokkentes(string azonosito) {
            foreach (var egyesulet in _egyesuletek.Where(egyesulet => egyesulet.Azonosito.Equals(azonosito))) {
                egyesulet.TagokSzama -= 1;
                Adatbazis.Egyesulet.Egyesulet.TagokCsokkentes(azonosito);
                return;
            }
        }
    }
}