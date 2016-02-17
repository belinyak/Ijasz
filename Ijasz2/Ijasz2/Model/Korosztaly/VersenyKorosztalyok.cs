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
            _versenyKorosztalyok = new List<VersenyKorosztaly>();

            VersenyKorosztaly versenyKorosztaly = new VersenyKorosztaly();
            versenyKorosztaly.VersenyAzonosito = "ve1";
            versenyKorosztaly.Korosztalyok = new ObservableCollection<Korosztaly>();
            versenyKorosztaly.Korosztalyok.Add( new Korosztaly {
                Verseny = "ve1",
                Azonosito = "k10",
                AlsoHatar = 10,
                FelsoHatar = 20,
            } );

            _versenyKorosztalyok.Add(versenyKorosztaly);
        }
    }
}
