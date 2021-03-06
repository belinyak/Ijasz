﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Ijasz2.Model.Ijtipus {
    public class Ijtipusok {
        public ObservableCollection<Ijtipus> _ijtipusok;

        /// <summary>
        ///     |
        ///     hozzaadas modellhez |
        ///     hozzaadas adatbazishoz |
        /// </summary>
        /// <param name="ijtipus"></param>
        public void Add(Ijtipus ijtipus) {
            _ijtipusok.Add(ijtipus);
            Adatbazis.Ijtipus.Ijtipus.Add(ijtipus);
        }

        /// <summary>
        ///     |
        ///     figyelni kell, hogy csak akkor torolheto, ha eredmenyek 0 |
        ///     torles modelbol |
        ///     torles adatbazisbol |
        /// </summary>
        /// <param name="ijtipus"></param>
        public void Remove(Ijtipus ijtipus) {
            if (ijtipus.Eredmenyek.Equals(0)) {
                _ijtipusok.Remove(
                    _ijtipusok.Single(
                        s => s.Azonosito.Equals(ijtipus.Azonosito)));
                Adatbazis.Ijtipus.Ijtipus.Remove(ijtipus.Azonosito);
            }
            else {
                MessageBox.Show("Ez az íjtípus nem törölhető, mivel van hozzá rendelve eredmény!", "Hiba",
                    MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
        }

        /// <summary>
        ///     |
        ///     TODO itt kell-e módosítani az eredményt? |
        ///     model update |
        ///     adatbazis update |
        /// </summary>
        /// <param name="ijtipus"></param>
        public void Update(Ijtipus ijtipus) {
            foreach (var it in _ijtipusok.Where(it => it.Azonosito.Equals(ijtipus.Azonosito))) {
                it.Megnevezes = ijtipus.Megnevezes;
                it.Sorszam = ijtipus.Sorszam;
                it.Eredmenyek = ijtipus.Eredmenyek;
                Adatbazis.Ijtipus.Ijtipus.Update(ijtipus);
            }
        }

        /// <summary>
        ///     |
        ///     betoltes db-bol |
        /// </summary>
        public void Load() {
            _ijtipusok = Adatbazis.Ijtipus.Ijtipus.Load();
        }

        public void EredmenyekNoveles(string azonosito) {
            foreach (var ijtipus in _ijtipusok.Where(ijtipus => ijtipus.Azonosito.Equals(azonosito))) {
                ijtipus.Eredmenyek += 1;
                Adatbazis.Ijtipus.Ijtipus.EredmenyekNoveles(azonosito);
            }
        }

        public void EredmenyekCsokkentes(string azonosito) {
            foreach (var ijtipus in _ijtipusok.Where(ijtipus => ijtipus.Azonosito.Equals(azonosito))) {
                ijtipus.Eredmenyek -= 1;
                Adatbazis.Ijtipus.Ijtipus.EredmenyekCsokkentes(azonosito);
            }
        }
    }
}