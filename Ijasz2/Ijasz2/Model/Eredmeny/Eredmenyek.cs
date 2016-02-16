using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Eredmeny {
    public class Eredmenyek {
        public ObservableCollection<ObservableCollection<Eredmeny> > _eredmenyek;

        public void Add( ObservableCollection<Eredmeny> versenyEredmenyek ) {
            _eredmenyek.Add( versenyEredmenyek );
        }

        public void Add( Eredmeny eredmeny ) {
            foreach( var versenyeredmeny in _eredmenyek ) {
                if( versenyeredmeny[0].Verseny.Equals( eredmeny.Verseny ) ) {
                    versenyeredmeny.Add( eredmeny );
                    return;
                }
            }

            throw new Exception( "nincs verseny!!!!" );
        }

        public void Remove( Eredmeny eredmeny ) {
            foreach( var versenyeredmenyek in _eredmenyek ) {
                if( versenyeredmenyek[0].Verseny.Equals( eredmeny.Verseny ) ) {
                    versenyeredmenyek.Remove( eredmeny );
                    return;
                }
            }
        }

        public void Modify( Eredmeny eredmeny ) {
            foreach( var versenyeredmeny in _eredmenyek ) {
                if( versenyeredmeny[0].Verseny.Equals( eredmeny.Verseny ) ) {
                    for( int i = 0; i < versenyeredmeny.Count; i++ ) {
                        if( ( versenyeredmeny[i].Verseny.Equals( eredmeny.Verseny ) ) &&
                            ( versenyeredmeny[i].Indulo.Equals( eredmeny.Indulo ) ) ) {
                            versenyeredmeny[i].Sorszam = eredmeny.Sorszam;
                            versenyeredmeny[i].Ijtipus = eredmeny.Ijtipus;
                            versenyeredmeny[i].Csapat = eredmeny.Csapat;
                            versenyeredmeny[i].Talalat10 = eredmeny.Talalat10;
                            versenyeredmeny[i].Talalat8 = eredmeny.Talalat8;
                            versenyeredmeny[i].Talalat5 = eredmeny.Talalat5;
                            versenyeredmeny[i].Melle = eredmeny.Melle;
                            versenyeredmeny[i].OsszPont = eredmeny.OsszPont;
                            versenyeredmeny[i].Szazalek = eredmeny.OsszPont;
                            versenyeredmeny[i].Megjelent = eredmeny.Megjelent;
                            versenyeredmeny[i].KorosztalyModositott = eredmeny.KorosztalyModositott;
                            versenyeredmeny[i].KorosztalyAzonosito = eredmeny.KorosztalyAzonosito;
                        }
                    }
                }
            }
        }

        public void Load( ) {
            _eredmenyek = new ObservableCollection<ObservableCollection<Eredmeny>>( );
            ObservableCollection<Eredmeny> e1 = new ObservableCollection<Eredmeny>();
            e1.Add( new Eredmeny {
                Verseny = "ve1",
                Indulo = "belinyak"
            } );
            _eredmenyek.Add( e1 );
        }
    }
}
