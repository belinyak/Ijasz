using System.Collections.ObjectModel;

namespace Ijasz2.Model.Oklevel {
    public class Sablonok {
        public ObservableCollection<Sablon> _sablonok;

        /// <summary> |
        /// model add |
        /// adatbazis add |
        /// </summary>
        /// <param name="sablon"></param>
        public void Add( Sablon sablon ) {
            _sablonok.Add( sablon );
            Adatbazis.Oklevel.Oklevel.Add( sablon );
        }

        /// <summary> |
        /// model update |
        /// adatbazis update |
        /// TODO remove+add -al hackelt |
        /// </summary>
        /// <param name="sablon"></param>
        public void Update( Sablon sablon ) {
            foreach( var sablon1 in _sablonok ) {
                if( sablon1.Azonosito.Equals( sablon.Azonosito ) ) {
                    _sablonok.Remove( sablon1 );
                    _sablonok.Add( sablon );
                    Adatbazis.Oklevel.Oklevel.Update( sablon );
                    return;
                }
            }
        }

        /// <summary> |
        /// model torles |
        /// adatbazis torles |
        /// </summary>
        /// <param name="azonosito"></param>
        public void Remove( string azonosito ) {
            foreach( var sablon in _sablonok ) {
                if( sablon.Azonosito.Equals( azonosito ) ) {
                    _sablonok.Remove( sablon );
                    Adatbazis.Oklevel.Oklevel.Remove( azonosito );
                    return;
                }
            }
        }

        /// <summary> |
        /// betoltes adatbazisbol |
        /// </summary>
        public void Load( ) {
            _sablonok = Adatbazis.Oklevel.Oklevel.Load( );
        }
    }
}
