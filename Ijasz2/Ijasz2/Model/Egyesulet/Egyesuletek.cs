using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Egyesulet {
    public class Egyesuletek {
        public ObservableCollection<Egyesulet> _egyesuletek;

        public void Add( Egyesulet egyesulet ) {
            _egyesuletek.Add( egyesulet );
            Adatbazis.Egyesulet.Egyesulet.Add(egyesulet);
        }

        public void Remove( Egyesulet egyesulet ) {
            if( egyesulet.TagokSzama.Equals( 0 ) ) {
                _egyesuletek.Remove(
                        _egyesuletek.Single(
                            s => s.Azonosito.Equals( egyesulet.Azonosito ) ) );
                Adatbazis.Egyesulet.Egyesulet.Remove(egyesulet.Azonosito);
            }
        }

        public void Modify( Egyesulet egyesulet ) {
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
                    Adatbazis.Egyesulet.Egyesulet.Update(egyesulet);
                }
            }
        }

        public void Load( ) {
            _egyesuletek = Adatbazis.Egyesulet.Egyesulet.Load();
        }
    }
}
