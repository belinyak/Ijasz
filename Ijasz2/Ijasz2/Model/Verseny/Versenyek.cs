using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Verseny {
    public class Versenyek {
        public ObservableCollection<Verseny> _versenyek;

        public void Add( Verseny verseny ) {
            _versenyek.Add( verseny );
        }

        public void Remove( string azonosito ) {
            _versenyek.Remove(
        _versenyek.Single(
            s => s.Azonosito.Equals( azonosito ) ) );
        }

        public void Modify( Verseny ujVerseny ) {
            for( int i = 0; i < _versenyek.Count; i++ ) {
                if( _versenyek[i].Azonosito.Equals( ujVerseny.Azonosito ) ) {
                    _versenyek[i] = ujVerseny;
                    return;
                }
            }
        }

        /// <summary>
        /// adatok db-ből
        /// </summary>
        public void Load( ) {
            _versenyek = new ObservableCollection<Verseny> {
                new Verseny("ve1", "verseny1"),
                new Verseny("ve2", "verseny2"),
                new Verseny("ve3", "verseny3"),
                new Verseny("ve4", "verseny4")
            };
        }
    }
}
