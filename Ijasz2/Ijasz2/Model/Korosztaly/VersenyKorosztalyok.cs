using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Korosztaly {
    /// <summary>
    /// verseny szintű
    /// </summary>
    public class VersenyKorosztalyok {
        public  List<VersenyKorosztaly> _versenyKorosztalyok;

        /// <summary>
        /// verseny létrehozásakor
        /// </summary>
        /// <param name="versenyKorosztaly"></param>
        public void Add( VersenyKorosztaly versenyKorosztaly ) {
            _versenyKorosztalyok.Add(versenyKorosztaly);
        }

        /// <summary>
        /// verseny törlésekor
        /// </summary>
        /// <param name="versenyKorosztaly"></param>
        public void Remove( VersenyKorosztaly versenyKorosztaly ) {
            _versenyKorosztalyok.Remove(versenyKorosztaly);
        }
        /// <summary>
        /// ezt elméletileg nem szabadna használni !!!
        /// </summary>
        /// <param name="versenyKorosztaly"></param>
        public void Modify( VersenyKorosztaly versenyKorosztaly ) {
            throw new NotImplementedException( );
        }

        public void Load( ) {
            _versenyKorosztalyok = Adatbazis.Korosztaly.Korosztaly.Load();
            
        }
    }
}
