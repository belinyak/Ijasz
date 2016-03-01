using System;
using System.Linq;
using System.Collections.ObjectModel;

namespace Ijasz2.Model.Versenysorozat {
    public class Versenysorozatok {
        public ObservableCollection<Versenysorozat> _versenysorozatok;

        /// <summary> |
        /// model hozzaadas |
        /// adatbazis hozzaadas |
        /// </summary>
        /// <param name="versenysorozat"></param>
        public void Add( Versenysorozat versenysorozat ) {
            _versenysorozatok.Add( versenysorozat );
            Adatbazis.Versenysorozat.Versenysorozat.Add( versenysorozat );
        }

        /// <summary> |
        /// model torles |
        /// adatbazis torles |
        /// </summary>
        /// <param name="azonosito"></param>
        public void Remove( string azonosito ) {
            _versenysorozatok.Remove(
                    _versenysorozatok.Single(
                        s => s.Azonosito.Equals( azonosito ) ) );
            Adatbazis.Versenysorozat.Versenysorozat.Remove( azonosito );
        }

        /// <summary> |
        /// model update |
        /// adatbazis update |
        /// </summary>
        /// <param name="ujVersenysorozat"></param>
        public void Update( Versenysorozat ujVersenysorozat ) {
            foreach( var versenysorozat in _versenysorozatok ) {
                if( versenysorozat.Azonosito.Equals( ujVersenysorozat.Azonosito ) ) {
                    versenysorozat.Megnevezes = ujVersenysorozat.Megnevezes;
                    Adatbazis.Versenysorozat.Versenysorozat.Update( versenysorozat );
                    return;
                }
            }
        }

        /// <summary> |
        /// adatok betoltese db-bol |
        /// </summary>
        public void Load( ) {
            _versenysorozatok = Adatbazis.Versenysorozat.Versenysorozat.Load( );
        }

        /// <summary> |
        /// verseny hozzaadasakor |
        /// model | adatbazis | 
        /// </summary>
        /// <param name="azonosito"></param>
        public void VersenyekNovel( string azonosito ) {
            foreach( var versenysorozat in _versenysorozatok ) {
                if( versenysorozat.Azonosito.Equals( azonosito ) ) {
                    versenysorozat.VersenyekSzama += 1;
                    Adatbazis.Versenysorozat.Versenysorozat.VersenyekNovel( azonosito );
                    return;
                }
            }
        }

        /// <summary> |
        /// verseny torlesekor |
        /// </summary>
        /// <param name="azonosito"></param>
        public void VersenyekCsokkent( string azonosito ) {
            foreach( var versenysorozat in _versenysorozatok ) {
                if( versenysorozat.Azonosito.Equals( azonosito ) ) {
                    versenysorozat.VersenyekSzama -= 1;
                    Adatbazis.Versenysorozat.Versenysorozat.VersenyekCsokkent( azonosito );
                    return;
                }
            }
        }
    }
}
