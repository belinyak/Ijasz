using System.Collections.ObjectModel;
using System.Linq;

namespace Ijasz2.Model.Indulo {
    public class Indulok {
        public ObservableCollection<Indulo> _indulok;

        /// <summary> |
        /// modelhez adas |
        /// adatbazishoz adas |
        /// </summary>
        /// <param name="indulo"></param>
        public void Add( Indulo indulo ) {
            _indulok.Add( indulo );
            Adatbazis.Indulo.Indulo.Add( indulo );
        }

        /// <summary> |
        /// eredmenyek == 0 check |
        /// model torles |
        /// adatbazis torles |
        /// </summary>
        /// <param name="_indulo"></param>
        public void Remove( Indulo indulo ) {
            for( int i = 0; i < _indulok.Count; i++ ) {
                if( _indulok[i].Eredmenyek.Equals( 0 ) ) {
                    _indulok.Remove( _indulok.Single( s => s.Nev.Equals( indulo.Nev ) ) );
                    Adatbazis.Indulo.Indulo.Remove( indulo.Nev );
                    return;
                }
            }
        }

        /// <summary> |
        /// TODO utánanézni, hogy mit lehet mosositani |
        /// model update |
        /// adatbazis update |
        /// </summary>
        /// <param name="indulo"></param>
        public void Update( Indulo indulo ) {
            for( int i = 0; i < _indulok.Count; i++ ) {
                if( _indulok[i].Nev.Equals( indulo.Nev ) ) {
                    _indulok[i].Nem = indulo.Nem;
                    _indulok[i].SzuletesiDatum = indulo.SzuletesiDatum;
                    _indulok[i].Engedely = indulo.Engedely;
                    _indulok[i].Egyesulet = indulo.Egyesulet;
                    _indulok[i].Eredmenyek = indulo.Eredmenyek;
                    Adatbazis.Indulo.Indulo.Update( indulo );
                }
            }
        }

        /// <summary>
        /// adatbazis betoltes
        /// </summary>
        public void Load( ) {
            _indulok = Adatbazis.Indulo.Indulo.Load( );
        }
    }
}
