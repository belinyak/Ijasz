using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Korosztaly {
    public class Korosztalyok {
        public ObservableCollection<ObservableCollection<Korosztaly>> _korosztalyok;

        /// <summary>
        /// versenyhez tartozo korosztalyok
        /// </summary>
        /// <param name="korosztalyok"></param>
        public void Add( ObservableCollection<Korosztaly> korosztalyok ) {
            _korosztalyok.Add( korosztalyok );
        }

        /// <summary>
        /// szimpla korosztaly versenyhez tartozó korosztályokhoz adása
        /// </summary>
        /// <param name="korosztaly"></param>
        public void Add( Korosztaly korosztaly ) {
            foreach( var versenykorosztalyok in _korosztalyok ) {
                if( versenykorosztalyok[0].Verseny.Equals( korosztaly.Verseny ) ) {
                    versenykorosztalyok.Add( korosztaly );
                }
            }
        }

        /// <summary>
        /// szimpla korosztaly torlese verseny korosztalyok közül
        /// </summary>
        /// <param name="verseny"></param>
        /// <param name="azonosito"></param>
        public void Remove( string verseny, string azonosito ) {
            foreach( var versenykorosztalyok in _korosztalyok ) {
                if( versenykorosztalyok[0].Verseny.Equals( verseny ) ) {
                    foreach( var korosztaly in versenykorosztalyok ) {
                        if( korosztaly.Azonosito.Equals( azonosito ) ) {
                            versenykorosztalyok.Remove( korosztaly );
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
            /// versenyhez tartozo korosztalyok torlese
            /// </summary>
            /// <param name="verseny"></param>
        public void Remove( string verseny ) {
            foreach( var versenykorosztalyok in _korosztalyok ) {
                if( versenykorosztalyok[0].Verseny.Equals( verseny ) ) {
                    _korosztalyok.Remove( versenykorosztalyok );
                    return;
                }
            }
        }

        public void Modify(Korosztaly korosztaly) {
            foreach (var versenykorosztalyok in _korosztalyok) {
                if (versenykorosztalyok[0].Verseny.Equals(korosztaly.Verseny)) {
                    foreach (var korosztaly1 in versenykorosztalyok) {
                        if (korosztaly1.Azonosito.Equals(korosztaly.Azonosito)) {
                            korosztaly1.Megnevezes = korosztaly.Megnevezes;
                            korosztaly1.AlsoHatar = korosztaly.AlsoHatar;
                            korosztaly1.FelsoHatar = korosztaly.FelsoHatar;
                            korosztaly1.Nokre = korosztaly.Nokre;
                            korosztaly1.Ferfiakra = korosztaly.Ferfiakra;
                            korosztaly1.InduloNok = korosztaly.InduloNok;
                            korosztaly1.InduloFerfiak = korosztaly.InduloFerfiak;
                            korosztaly1.Egyben = korosztaly.Egyben;
                        }
                    }
                }
            }
        }


        public void Load() {
            _korosztalyok = new ObservableCollection<ObservableCollection<Korosztaly>>();
            ObservableCollection < Korosztaly > versenyKorosztalyok = new ObservableCollection<Korosztaly>();

            Korosztaly k10 = new Korosztaly {
                Verseny = "ve1", Azonosito = "K10",
                Megnevezes = "0-10",
                AlsoHatar = 1, FelsoHatar = 9,
                Ferfiakra = true, Nokre = true, Egyben = false,
                InduloFerfiak = 0, InduloNok = 0
            };
            versenyKorosztalyok.Add(k10);

            Korosztaly k14 = new Korosztaly {
                Verseny = "ve1",
                Azonosito = "K14",
                Megnevezes = "10-14",
                AlsoHatar = 10,
                FelsoHatar = 13,
                Ferfiakra = true,
                Nokre = true,
                Egyben = false,
                InduloFerfiak = 0,
                InduloNok = 0
            };
            versenyKorosztalyok.Add( k14 );


            _korosztalyok.Add(versenyKorosztalyok);
            /*
                "('" + _verseny.Azonosito + "', 'K10', '0-10', 1, 9, 1, 1, 0, 0,0)," +
            */
        }
    }
}
