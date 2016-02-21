using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Ijasz2.Model.Versenysorozat {
    public class Versenysorozatok {
        public ObservableCollection<Versenysorozat> _versenysorozatok;

        /// <summary>
        /// hozzaadas
        /// </summary>
        /// <param name="versenysorozat"></param>
        public void Add( Versenysorozat versenysorozat ) {
            _versenysorozatok.Add( versenysorozat );
            Adatbazis.Versenysorozat.Versenysorozat.Add(versenysorozat);
        }

        /// <summary>
        /// torles
        /// </summary>
        /// <param name="azonosito"></param>
        public void Remove( string azonosito ) {
            _versenysorozatok.Remove(
                    _versenysorozatok.Single(
                        s => s.Azonosito.Equals( azonosito ) ) );
            Adatbazis.Versenysorozat.Versenysorozat.Remove(azonosito);
        }

        /// <summary>
        /// egyesével kell settelni!
        /// </summary>
        /// <param name="ujVersenysorozat"></param>
        public void Update( Versenysorozat ujVersenysorozat ) {
            foreach( var versenysorozat in _versenysorozatok ) {
                if( versenysorozat.Azonosito.Equals( ujVersenysorozat.Azonosito ) ) {
                    versenysorozat.Megnevezes = ujVersenysorozat.Megnevezes;
                    Adatbazis.Versenysorozat.Versenysorozat.Update(versenysorozat);
                    return;
                }
            }
        }

        /// <summary>
        /// adatok betoltese db-bol
        /// </summary>
        public void Load( ) {
            _versenysorozatok = Adatbazis.Versenysorozat.Versenysorozat.Load( );
        }
    }
}
