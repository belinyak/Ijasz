using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Indulo {
    public class Indulok {
        public ObservableCollection<Indulo> _indulok;

        public void Add( Indulo indulo ) {
            _indulok.Add( indulo );
        }

        /// <summary>
        /// eredmenyek == 0 check
        /// </summary>
        /// <param name="_indulo"></param>
        public void Remove( Indulo indulo ) {
            for( int i = 0; i < _indulok.Count; i++ ) {
                if(  _indulok[i].Eredmenyek.Equals(0) ) {
                    _indulok.Remove( _indulok.Single( s => s.Nev.Equals( indulo.Nev ) ) );
                    return;
                }
            }
        }

        /// <summary>
        /// TODO utánanézni, hogy mit módosíthatok
        /// </summary>
        /// <param name="indulo"></param>
        public void Modify( Indulo indulo ) {
            for( int i = 0; i < _indulok.Count; i++ ) {
                if( _indulok[i].Nev.Equals( indulo.Nev ) ) {
                    _indulok[i].Nem = indulo.Nem;
                    _indulok[i].SzuletesiDatum = indulo.SzuletesiDatum;
                    _indulok[i].Engedely = indulo.Engedely;
                    _indulok[i].Egyesulet = indulo.Egyesulet;
                    _indulok[i].Eredmenyek = indulo.Eredmenyek;
                }
            }
        }

        public void Load( ) {
            _indulok = new ObservableCollection<Indulo> {
                new Indulo {
                    Nev = "nev1",
                    Nem = "F",
                    Egyesulet = "egy1",
                    Engedely = "",
                    SzuletesiDatum = "1994.04.20",
                    Eredmenyek = 0
                },
                new Indulo {
                    Nev = "nev2",
                    Nem = "N",
                    Egyesulet = "egy1",
                    Engedely = "",
                    SzuletesiDatum = "1993.04.20",
                    Eredmenyek = 0
                },
                new Indulo {
                    Nev = "nev3",
                    Nem = "F",
                    Egyesulet = "egy1",
                    Engedely = "",
                    SzuletesiDatum = "1992.04.20",
                    Eredmenyek = 0
                },
                new Indulo {
                    Nev = "nev4",
                    Nem = "N",
                    Egyesulet = "egy1",
                    Engedely = "",
                    SzuletesiDatum = "1991.04.20",
                    Eredmenyek = 0
                }
            };
        }
    }
}
