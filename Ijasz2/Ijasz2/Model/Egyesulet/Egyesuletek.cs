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
        }

        public void Remove( Egyesulet egyesulet ) {
            if( egyesulet.TagokSzama.Equals( 0 ) ) {
                _egyesuletek.Remove(
                        _egyesuletek.Single(
                            s => s.Azonosito.Equals( egyesulet.Azonosito ) ) );
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
                }
            }
        }

        public void Load( ) {
            _egyesuletek = new ObservableCollection<Egyesulet> {
                new Egyesulet {
                    Azonosito = "egy1",
                    Cim = "cim1",
                    Vezeto = "vezeto1",
                    Telefon1 = "telefon1",
                    Telefon2 = "telefon2",
                    Email1 = "email1",
                    Email2 = "email2",
                    Listazando = true,
                    TagokSzama = 0
                },
                new Egyesulet {
                    Azonosito = "egy2",
                    Cim = "cim1",
                    Vezeto = "vezeto1",
                    Telefon1 = "telefon1",
                    Telefon2 = "telefon2",
                    Email1 = "email1",
                    Email2 = "email2",
                    Listazando = true,
                    TagokSzama = 0
                },
                new Egyesulet {
                    Azonosito = "egy3",
                    Cim = "cim1",
                    Vezeto = "vezeto1",
                    Telefon1 = "telefon1",
                    Telefon2 = "telefon2",
                    Email1 = "email1",
                    Email2 = "email2",
                    Listazando = true,
                    TagokSzama = 0
                }
            };
        }
    }
}
