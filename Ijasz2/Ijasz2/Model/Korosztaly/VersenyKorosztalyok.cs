using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ijasz2.Model.Korosztaly {

    /// <summary> |
    /// verseny szintu |
    /// </summary>
    public class VersenyKorosztalyok {
        public List<VersenyKorosztaly> _versenyKorosztalyok;

        /// <summary> |
        /// uj verseny letrehozasakor |
        /// </summary>
        /// <param name="versenyKorosztaly"></param>
        public void Add( VersenyKorosztaly versenyKorosztaly ) {
            _versenyKorosztalyok.Add( versenyKorosztaly );
        }

        /// <summary> |
        /// verseny torlesekor |
        /// </summary>
        /// <param name="versenyKorosztaly"></param>
        public void Remove( VersenyKorosztaly versenyKorosztaly ) {
            _versenyKorosztalyok.Remove( versenyKorosztaly );
        }

        /// <summary> |
        /// korosztalyok betoltese adatbazisbol |
        /// </summary>
        public void Load( ) {
            _versenyKorosztalyok = Adatbazis.Korosztaly.Korosztaly.Load( );
        }

        public void Tagok( string versenyAzonosito, string korosztalyAzonosito ) {

            //from korosztaly in Model.Data.Data.Korosztalyok._versenyKorosztalyok.Where( q => q.VersenyAzonosito.Equals(versenyAzonosito)).Select(korosztaly => korosztaly.Korosztalyok)
            //from eredmeny in Model.Data.Data.Eredmenyek._versenyEredmenyek.Where( q => q.VersenyAzonosito.Equals(versenyAzonosito)).Select(eredmeny => eredmeny.Eredmenyek)
            //from indulo in Model.Data.Data.Indulok._indulok.Where(indulo => )

            foreach (var versenyEredmenyek in Model.Data.Data.Eredmenyek._versenyEredmenyek) {
                if (versenyEredmenyek.VersenyAzonosito.Equals(versenyAzonosito)) {
                    foreach (var versenyKorosztalyok in Model.Data.Data.Korosztalyok._versenyKorosztalyok) {
                        if (versenyKorosztalyok.VersenyAzonosito.Equals(korosztalyAzonosito)) {
                            var q =
                                from eredmeny in
                                    versenyEredmenyek.Eredmenyek._eredmenyek.Where(
                                        eredmeny => eredmeny.Verseny.Equals(versenyAzonosito))
                                from korosztaly in
                                    versenyKorosztalyok.Korosztalyok.Where(
                                        korosztaly => korosztaly.Azonosito.Equals(eredmeny.KorosztalyAzonosito))
                                from indulo in
                                    Model.Data.Data.Indulok._indulok.Where(indulo => indulo.Nev.Equals(eredmeny.Indulo))
                                select new {
                                    eredmeny.Indulo,
                                    korosztaly.Megnevezes,
                                };
                        }
                    }
                }
            }

        }


    }
}
