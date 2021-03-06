﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ijasz2.Model.Eredmeny;
using Ijasz2.Model.Korosztaly;

namespace Ijasz2.Model.Verseny {
    public class Versenyek {
        public ObservableCollection<Verseny> _versenyek;

        /// <summary>
        ///     |
        ///     model hozzaadas |
        ///     adatbazishoz hozzaadas |
        ///     versenyeredmenyek model hozzaadas |
        ///     versenysorozat versenyek novelese |
        ///     TODO versenyeredmenyek adatbazis hozzaadas |
        ///     default korosztalyok model hozzaadas |
        ///     default korosztalyok adatbazis hozzaadas |
        /// </summary>
        /// <param name="verseny"></param>
        public void Add(Verseny verseny) {
            _versenyek.Add(verseny);
            Adatbazis.Verseny.Verseny.Add(verseny);

            // versenysorozat eredmeny novelese
            if (!string.IsNullOrEmpty(verseny.Versenysorozat)) {
                Data.Data.Versenysorozatok.VersenyekNovel(verseny.Versenysorozat);
            }

            // eredmenyek letrehozasa
            var versenyEredmeny = new VersenyEredmeny(verseny.Azonosito);
            Data.Data.Eredmenyek._versenyEredmenyek.Add(versenyEredmeny);

            // korosztalyok letrehozasa
            var versenyKorosztaly = new VersenyKorosztaly(verseny.Azonosito);

            #region Default Korosztalyok

            versenyKorosztaly.Korosztalyok.Add(new Korosztaly.Korosztaly {
                Verseny = verseny.Azonosito,
                Azonosito = "K10",
                Megnevezes = "0-10",
                AlsoHatar = 1,
                FelsoHatar = 9,
                Nokre = true,
                Ferfiakra = true,
                InduloFerfiak = 0,
                InduloNok = 0,
                Egyben = false
            });
            versenyKorosztaly.Korosztalyok.Add(new Korosztaly.Korosztaly {
                Verseny = verseny.Azonosito,
                Azonosito = "K14",
                Megnevezes = "10-14",
                AlsoHatar = 10,
                FelsoHatar = 14,
                Nokre = true,
                Ferfiakra = true,
                InduloFerfiak = 0,
                InduloNok = 0,
                Egyben = false
            });

            versenyKorosztaly.Korosztalyok.Add(new Korosztaly.Korosztaly {
                Verseny = verseny.Azonosito,
                Azonosito = "K18",
                Megnevezes = "14-18",
                AlsoHatar = 14,
                FelsoHatar = 17,
                Nokre = true,
                Ferfiakra = true,
                InduloFerfiak = 0,
                InduloNok = 0,
                Egyben = false
            });
            versenyKorosztaly.Korosztalyok.Add(new Korosztaly.Korosztaly {
                Verseny = verseny.Azonosito,
                Azonosito = "K50",
                Megnevezes = "18-50",
                AlsoHatar = 18,
                FelsoHatar = 49,
                Nokre = true,
                Ferfiakra = true,
                InduloFerfiak = 0,
                InduloNok = 0,
                Egyben = false
            });
            versenyKorosztaly.Korosztalyok.Add(new Korosztaly.Korosztaly {
                Verseny = verseny.Azonosito,
                Azonosito = "K100",
                Megnevezes = "50-100",
                AlsoHatar = 50,
                FelsoHatar = 99,
                Nokre = true,
                Ferfiakra = true,
                InduloFerfiak = 0,
                InduloNok = 0,
                Egyben = false
            });

            #endregion

            Data.Data.Korosztalyok = new VersenyKorosztalyok {_versenyKorosztalyok = new List<VersenyKorosztaly>()};
            Data.Data.Korosztalyok.Add(versenyKorosztaly);

            foreach (var korosztaly in versenyKorosztaly.Korosztalyok) {
                Adatbazis.Korosztaly.Korosztaly.Add(korosztaly);
            }
        }

        /// <summary>
        ///     |
        ///     model torles |
        ///     model adatbazis torles |
        ///     versenyhez tartozo korosztalyok model torlese |
        ///     TODO versenyhez tartozo korosztalyok adatbazis torlese |
        /// </summary>
        /// <param name="azonosito"></param>
        public void Remove(string azonosito) {
            // versenysorozat eredmenyek csokkentese
            foreach (var verseny in _versenyek.Where(verseny => (verseny.Azonosito.Equals(azonosito)) &&
                                                                !string.IsNullOrEmpty(verseny.Versenysorozat))) {
                Data.Data.Versenysorozatok.VersenyekCsokkent(verseny.Versenysorozat);
            }

            _versenyek.Remove(_versenyek.Single(s => s.Azonosito.Equals(azonosito)));
            Adatbazis.Verseny.Verseny.Remove(azonosito);

            foreach (var versenyKorosztaly in Data.Data.Korosztalyok._versenyKorosztalyok.Where(versenyKorosztaly => versenyKorosztaly.VersenyAzonosito.Equals(azonosito))) {
                Data.Data.Korosztalyok.Remove(versenyKorosztaly);
                return;
            }
        }

        /// <summary>
        ///     |
        ///     indulok szamat nem set-teli |
        ///     model update |
        ///     adatbazis update |
        /// </summary>
        /// <param name="ujVerseny"></param>
        public void Update(Verseny ujVerseny) {
            foreach (var verseny in _versenyek.Where(verseny => verseny.Azonosito.Equals(ujVerseny.Azonosito))) {
                VersenyekSzamaSeged(verseny.Versenysorozat, ujVerseny.Versenysorozat);

                verseny.Megnevezes = ujVerseny.Megnevezes;
                verseny.Datum = ujVerseny.Datum;
                verseny.Versenysorozat = ujVerseny.Versenysorozat;
                verseny.Osszes = ujVerseny.Osszes;
                verseny.Allomasok = ujVerseny.Allomasok;
                verseny.DuplaBeirolap = ujVerseny.DuplaBeirolap;
                Adatbazis.Verseny.Verseny.Update(ujVerseny);
                return;
            }
        }

        /// <summary>
        ///     |
        ///     1) meg kell nezni, hogy modosult-e a versenysorozat, ha igen akkor  |
        ///     2) ha a regi null az uj nem null, akkor novel |
        ///     3) ha a regi nem null az uj null, akkor csokkent |
        ///     4) ha egyik sem null akkor novel csokkent |
        /// </summary>
        /// <param name="regiVersenysorozat"></param>
        /// <param name="ujVersenysorozat"></param>
        private static void VersenyekSzamaSeged(string regiVersenysorozat, string ujVersenysorozat) {
            // 2)
            if (regiVersenysorozat != null && ((string.IsNullOrEmpty(regiVersenysorozat) ||
                                                (!string.IsNullOrEmpty(ujVersenysorozat))) &&
                                               (!regiVersenysorozat.Equals(ujVersenysorozat)))) {
                Data.Data.Versenysorozatok.VersenyekNovel(ujVersenysorozat);
            }
            // 3)
            else if (regiVersenysorozat != null && ((!string.IsNullOrEmpty(regiVersenysorozat) ||
                                                     (string.IsNullOrEmpty(ujVersenysorozat))) &&
                                                    (!regiVersenysorozat.Equals(ujVersenysorozat)))) {
                Data.Data.Versenysorozatok.VersenyekCsokkent(regiVersenysorozat);
            }
            // 4)
            else if (regiVersenysorozat != null && ((!string.IsNullOrEmpty(regiVersenysorozat) ||
                                                     (!string.IsNullOrEmpty(ujVersenysorozat))) &&
                                                    (!regiVersenysorozat.Equals(ujVersenysorozat)))) {
                Data.Data.Versenysorozatok.VersenyekCsokkent(regiVersenysorozat);
                Data.Data.Versenysorozatok.VersenyekNovel(ujVersenysorozat);
            }
        }

        /// <summary>
        /// | adatbazis betoltes |
        /// </summary>
        public void Load() {
            _versenyek = Adatbazis.Verseny.Verseny.Load();

        }

        public void IndulokNoveles(string azonosito) {
            foreach (var verseny in _versenyek.Where(verseny => verseny.Azonosito.Equals(azonosito))) {
                verseny.Indulok += 1;
                Adatbazis.Verseny.Verseny.IndulokNoveles(azonosito);
                return;
            }
        }

        public void IndulokCsokkentes(string azonosito) {
            foreach (var verseny in _versenyek.Where(verseny => verseny.Azonosito.Equals(azonosito))) {
                verseny.Indulok -= 1;
                Adatbazis.Verseny.Verseny.IndulokCsokkentes(azonosito);
                return;
            }
        }
    }
}