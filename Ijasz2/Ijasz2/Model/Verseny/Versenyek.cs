using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Verseny {
    public class Versenyek {
        public ObservableCollection<Verseny> _versenyek;

        /// <summary>
        /// itt kellene default korosztalyokat felvenni
        /// </summary>
        /// <param name="verseny"></param>
        public void Add( Verseny verseny ) {
            _versenyek.Add( verseny );
        }

        /// <summary>
        /// torleskor a versenyhez tartozo korosztalyokat is torolni kell
        /// </summary>
        /// <param name="azonosito"></param>
        public void Remove( string azonosito ) {
            _versenyek.Remove(
        _versenyek.Single(
            s =>  s.Azonosito.Equals( azonosito )  ) );

            Data.Data.Korosztalyok.Remove(azonosito);
        }

        /// <summary>
        /// Egyesével kell módosítani a mezőket, hogy a nem szettelt mezők, pl:indulokszama ne 0-zódjon ki
        /// </summary>
        /// <param name="ujVerseny"></param>
        public void Modify( Verseny ujVerseny ) {
            for( var i = 0; i < _versenyek.Count; i++ ) {
                if( _versenyek[i].Azonosito.Equals( ujVerseny.Azonosito ) ) {
                    _versenyek[i].Megnevezes = ujVerseny.Megnevezes;
                    _versenyek[i].Datum = ujVerseny.Datum;
                    _versenyek[i].Versenysorozat = ujVerseny.Versenysorozat;
                    _versenyek[i].Osszes = ujVerseny.Osszes;
                    _versenyek[i].Allomasok = ujVerseny.Allomasok;
                    _versenyek[i].DuplaBeirolap = ujVerseny.DuplaBeirolap;
                    return;
                }
            }
        }

        /// <summary>
        /// adatok db-ből
        /// </summary>
        public void Load( ) {
            _versenyek = new ObservableCollection<Verseny> {
                new Verseny { Azonosito = "ve1", Megnevezes = "verseny1" },
                new Verseny { Azonosito = "ve2", Megnevezes = "verseny2" },
                new Verseny { Azonosito = "ve3", Megnevezes = "verseny3" },
                new Verseny { Azonosito = "ve4", Megnevezes = "verseny4" },
            };
        }
    }
}
