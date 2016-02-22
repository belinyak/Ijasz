using System.Collections.Generic;

namespace Ijasz2.Model.Korosztaly {

    /// <summary> |
    /// verseny szintu |
    /// </summary>
    public class VersenyKorosztalyok {
        public  List<VersenyKorosztaly> _versenyKorosztalyok;

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
    }
}
