using System.Collections.Generic;
using System.Linq;

namespace Ijasz2.Model.Korosztaly {
    /// <summary>
    ///     |
    ///     verseny szintu |
    /// </summary>
    public class VersenyKorosztalyok {
        public List<VersenyKorosztaly> _versenyKorosztalyok;

        /// <summary>
        ///     |
        ///     uj verseny letrehozasakor |
        /// </summary>
        /// <param name="versenyKorosztaly"></param>
        public void Add(VersenyKorosztaly versenyKorosztaly) {
            _versenyKorosztalyok.Add(versenyKorosztaly);
        }

        /// <summary>
        ///     |
        ///     verseny torlesekor |
        /// </summary>
        /// <param name="versenyKorosztaly"></param>
        public void Remove(VersenyKorosztaly versenyKorosztaly) {
            _versenyKorosztalyok.Remove(versenyKorosztaly);
        }

        /// <summary>
        ///     |
        ///     korosztalyok betoltese adatbazisbol |
        /// </summary>
        public void Load() {
            _versenyKorosztalyok = Adatbazis.Korosztaly.Korosztaly.Load();
        }

        public static void Tagok(string versenyAzonosito, string korosztalyAzonosito) {
            //from korosztaly in Model.Data.Data.Korosztalyok._versenyKorosztalyok.Where( q => q.VersenyAzonosito.Equals(versenyAzonosito)).Select(korosztaly => korosztaly.Korosztalyok)
            //from eredmeny in Model.Data.Data.Eredmenyek._versenyEredmenyek.Where( q => q.VersenyAzonosito.Equals(versenyAzonosito)).Select(eredmeny => eredmeny.Eredmenyek)
            //from indulo in Model.Data.Data.Indulok._indulok.Where(indulo => )

            foreach (var q in from versenyEredmenyek in Data.Data.Eredmenyek._versenyEredmenyek where versenyEredmenyek.VersenyAzonosito.Equals(versenyAzonosito) from versenyKorosztalyok in Data.Data.Korosztalyok._versenyKorosztalyok where versenyKorosztalyok.VersenyAzonosito.Equals(korosztalyAzonosito) select (from eredmeny in
                versenyEredmenyek.Eredmenyek._eredmenyek.Where(
                    eredmeny => eredmeny.Verseny.Equals(versenyAzonosito))
                from korosztaly in
                    versenyKorosztalyok.Korosztalyok.Where(
                        korosztaly => korosztaly.Azonosito.Equals(eredmeny.KorosztalyAzonosito))
                from indulo in
                    Data.Data.Indulok._indulok.Where(indulo => indulo.Nev.Equals(eredmeny.Indulo))
                select new {
                    eredmeny.Indulo,
                    korosztaly.Megnevezes
                })) {
            }
        }

        public void NokNoveles(Korosztaly korosztaly) {
            foreach (
                var korosztaly1 in
                    _versenyKorosztalyok.Where(
                        versenyKorosztaly => versenyKorosztaly.VersenyAzonosito.Equals(korosztaly.Verseny))
                        .SelectMany(
                            versenyKorosztaly =>
                                versenyKorosztaly.Korosztalyok.Where(
                                    korosztaly1 => korosztaly1.Azonosito.Equals(korosztaly.Azonosito)))) {
                korosztaly1.InduloNok += 1;
                Adatbazis.Korosztaly.Korosztaly.NokNoveles(korosztaly);
            }
        }

        public void FerfiakNoveles(Korosztaly korosztaly) {
            foreach (
                var korosztaly1 in
                    _versenyKorosztalyok.Where(
                        versenyKorosztaly => versenyKorosztaly.VersenyAzonosito.Equals(korosztaly.Verseny))
                        .SelectMany(
                            versenyKorosztaly =>
                                versenyKorosztaly.Korosztalyok.Where(
                                    korosztaly1 => korosztaly1.Azonosito.Equals(korosztaly.Azonosito)))) {
                korosztaly1.InduloFerfiak += 1;
                Adatbazis.Korosztaly.Korosztaly.FerfiakNoveles(korosztaly);
            }
        }

        public void TagokCsokkentes(Eredmeny.Eredmeny eredmeny) {
            var nem = (from indulo in Data.Data.Indulok._indulok
                where indulo.Nev.Equals(eredmeny.Indulo)
                select indulo.Nem).First();

            foreach (
                var korosztaly in
                    _versenyKorosztalyok.Where(korosztaly => korosztaly.VersenyAzonosito.Equals(eredmeny.Verseny))
                        .SelectMany(
                            versenykorosztalyok =>
                                versenykorosztalyok.Korosztalyok.Where(
                                    korosztaly => korosztaly.Azonosito.Equals(eredmeny.KorosztalyAzonosito)))) {
                if (nem.Equals("F") || nem.Equals("f")) {
                    korosztaly.InduloFerfiak -= 1;
                    Adatbazis.Korosztaly.Korosztaly.FerfiakCsokkentes(korosztaly);
                    return;
                }
                korosztaly.InduloNok -= 1;
                Adatbazis.Korosztaly.Korosztaly.NokCsokkentes(korosztaly);
                return;
            }
        }
    }
}