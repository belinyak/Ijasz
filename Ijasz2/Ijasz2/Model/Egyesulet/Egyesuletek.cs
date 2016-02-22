using System.Collections.ObjectModel;
using System.Linq;

namespace Ijasz2.Model.Egyesulet {
    public class Egyesuletek {
        public ObservableCollection<Egyesulet> _egyesuletek;

        /// <summary> |
        /// model add
        /// adatbazis add
        /// </summary>
        /// <param name="egyesulet"></param>
        public void Add( Egyesulet egyesulet ) {
            _egyesuletek.Add( egyesulet );
            Adatbazis.Egyesulet.Egyesulet.Add( egyesulet );
        }

        /// <summary> |
        /// csak akkor torolheto, ha tagokszama 0 |
        /// model torles |
        /// adatbazis torles |
        /// </summary>
        /// <param name="egyesulet"></param>
        public void Remove( Egyesulet egyesulet ) {
            if( egyesulet.TagokSzama.Equals( 0 ) ) {
                _egyesuletek.Remove(
                        _egyesuletek.Single(
                            s => s.Azonosito.Equals( egyesulet.Azonosito ) ) );
                Adatbazis.Egyesulet.Egyesulet.Remove( egyesulet.Azonosito );
            }
        }

        /// <summary> |
        /// model update |
        /// adatbazis update |
        /// </summary>
        /// <param name="egyesulet"></param>
        public void Update( Egyesulet egyesulet ) {
            for( int i = 0; i < _egyesuletek.Count; i++ ) {
                if( _egyesuletek[i].Azonosito.Equals( egyesulet.Azonosito ) ) {
                    _egyesuletek[i].Cim = egyesulet.Cim;
                    _egyesuletek[i].Vezeto = egyesulet.Vezeto;
                    _egyesuletek[i].Telefon1 = egyesulet.Telefon1;
                    _egyesuletek[i].Telefon2 = egyesulet.Telefon2;
                    _egyesuletek[i].Email1 = egyesulet.Email1;
                    _egyesuletek[i].Email2 = egyesulet.Email2;
                    _egyesuletek[i].Listazando = egyesulet.Listazando;
                    _egyesuletek[i].TagokSzama = egyesulet.TagokSzama;
                    Adatbazis.Egyesulet.Egyesulet.Update( egyesulet );
                }
            }
        }

        /// <summary> |
        /// adatok betoltese adatbazisbol |
        /// </summary>
        public void Load( ) {
            _egyesuletek = Adatbazis.Egyesulet.Egyesulet.Load( );
        }
    }
}
