using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Ijasz2.Model.Indulo {
    public class Indulok {
        public ObservableCollection<Indulo> _indulok;

        /// <summary>
        ///     |
        ///     modelhez adas |
        ///     adatbazishoz adas |
        ///     egyesulet tagok novelese |
        /// </summary>
        /// <param name="indulo"></param>
        public void Add( Indulo indulo ) {
            _indulok.Add( indulo );
            Adatbazis.Indulo.Indulo.Add( indulo );
            if( !string.IsNullOrEmpty( indulo.Egyesulet ) ) {
                Data.Data.Egyesuletek.TagokNoveles( indulo.Egyesulet );
            }
        }

        /// <summary>
        /// | eredmenyek == 0 check |
        /// model torles |
        /// adatbazis torles |
        /// egyesulet tagok csokkentese | 
        /// TODO msg???? |
        /// </summary>
        /// <param name="indulo"></param>
        public void Remove( Indulo indulo ) {
            foreach( var indulo1 in _indulok.Where( indulo1 => indulo1.Nev.Equals( indulo.Nev ) ) ) {
                if( indulo1.Eredmenyek.Equals( 0 ) ) {
                    _indulok.Remove( indulo1 );
                    Adatbazis.Indulo.Indulo.Remove( indulo.Nev );
                    if( !string.IsNullOrEmpty( indulo.Egyesulet ) ) {
                        Data.Data.Egyesuletek.TagokCsokkentes( indulo.Egyesulet );
                    }
                    return;
                }
                MessageBox.Show( "Ez az induló nem törölhető, mivel van hozzá rendelve eredmény!", "Hiba", MessageBoxButton.OKCancel, MessageBoxImage.Information );
            }
        }

        /// <summary>
        /// | TODO utánanézni, hogy mit lehet mosositani |
        /// model update |
        /// adatbazis update |
        /// egyesuletek update | 
        /// </summary>
        /// <param name="indulo"></param>
        public void Update( Indulo indulo ) {
            foreach( var it in _indulok.Where( it => it.Nev.Equals( indulo.Nev ) ) ) {
                // ha van egyesulet és nem ugyanaz mint eddig, akkor uj egyesulet novel
                if( !string.IsNullOrEmpty( indulo.Egyesulet ) && !indulo.Egyesulet.Equals( it.Egyesulet ) ) {
                    Data.Data.Egyesuletek.TagokNoveles( indulo.Egyesulet );
                    // ha eddig volt egyesulet, akkor azt csokkenteni
                    if( !string.IsNullOrEmpty( it.Egyesulet ) ) {
                        Data.Data.Egyesuletek.TagokCsokkentes( it.Egyesulet );
                    }
                }
                // ha nincs egyesulet, de eddig volt
                else if( string.IsNullOrEmpty( indulo.Egyesulet ) && !string.IsNullOrEmpty( it.Egyesulet ) ) {
                    Data.Data.Egyesuletek.TagokCsokkentes( it.Egyesulet );
                }

                it.Nem = indulo.Nem;
                it.SzuletesiDatum = indulo.SzuletesiDatum;
                it.Engedely = indulo.Engedely;
                it.Egyesulet = indulo.Egyesulet;
                it.Eredmenyek = indulo.Eredmenyek;
                Adatbazis.Indulo.Indulo.Update( indulo );
                return;
            }
        }

        /// <summary>
        ///     adatbazis betoltes
        /// </summary>
        public void Load( ) {
            _indulok = Adatbazis.Indulo.Indulo.Load( );
        }

        public Indulo Get( string azonosito ) {
            var value = new Indulo();
            foreach( var indulo in _indulok.Where( indulo => indulo.Nev.Equals( azonosito ) ) ) {
                value = indulo;
                return value;
            }
            return value;
        }

        /// <summary>
        ///     indulo beirasakor novelni az eredmenyt
        /// </summary>
        /// <param name="azonosito"></param>
        public void EredmenyNoveles( string azonosito ) {
            foreach( var indulo1 in _indulok.Where( indulo1 => indulo1.Nev.Equals( azonosito ) ) ) {
                indulo1.Eredmenyek += 1;
                Adatbazis.Indulo.Indulo.EredmenyekNoveles( azonosito );
                return;
            }
        }

        /// <summary>
        ///     indulo beirasakor novelni az eredmenyt
        /// </summary>
        /// <param name="azonosito"></param>
        public void EredmenyCsokkentes( string azonosito ) {
            foreach( var indulo1 in _indulok.Where( indulo1 => indulo1.Nev.Equals( azonosito ) ) ) {
                indulo1.Eredmenyek -= 1;
                Adatbazis.Indulo.Indulo.EredmenyekCsokkentes( azonosito );
                return;
            }
        }
    }
}