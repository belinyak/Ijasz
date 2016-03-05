using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ijasz2.Model.Eredmeny {
    public class VersenyEredmenyek {
        public List<VersenyEredmeny> _versenyEredmenyek;

        /// <summary>
        /// olyat is felvenni, ahol nincs eredmeny
        /// </summary>
        public void Load( ) {
            _versenyEredmenyek = Adatbazis.Eredmeny.Eredmeny.Load( );
            foreach( var verseny in Model.Data.Data.Versenyek._versenyek ) {
                bool found = false;
                foreach( var versenyEredmeny in _versenyEredmenyek ) {
                    if( verseny.Azonosito.Equals( versenyEredmeny.VersenyAzonosito ) ) {
                        found = true;
                    }

                }
                if( !found ) {
                    _versenyEredmenyek.Add( new VersenyEredmeny {
                        Eredmenyek = new Eredmenyek {
                            _eredmenyek = new ObservableCollection<Eredmeny>( )
                        },
                        VersenyAzonosito = verseny.Azonosito
                    } );
                }
            }

        }
    }
}