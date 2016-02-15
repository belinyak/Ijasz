using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Verseny {
    public class Verseny : INotifyPropertyChanged {
        private string _azonosito;
        private string _megnevezes;
        private string _datum;
        private string _versenysorozat;
        private int _osszes;
        private int _allomasok;
        private int _indulok;
        private bool _lezarva;
        private bool _duplabeirolap;

        public string Azonosito {
            get { return _azonosito; }
            set {
                _azonosito = value;
                OnPropertyChanged( "Azonosito" );
            }
        }
        public string Megnevezes {
            get { return _megnevezes; }
            set {
                _megnevezes = value;
                OnPropertyChanged( "Megnevezes" );
            }
        }
        public string Datum {
            get { return _datum; }
            set {
                _datum = value;
                OnPropertyChanged( "Datum" );
            }
        }
        public string Versenysorozat {
            get { return _versenysorozat; }
            set {
                _versenysorozat = value;
                OnPropertyChanged( "Versenysorozatc" );
            }
        }
        public int Osszes {
            get { return _osszes; }
            set {
                _osszes = value;
                OnPropertyChanged( "Osszes" );
            }
        }
        public int Allomasok {
            get { return _allomasok; }
            set {
                _allomasok = value; 
                OnPropertyChanged( "Allomasok" );
            }
        }
        public int Indulok {
            get { return _indulok; }
            set {
                _indulok = value;
                OnPropertyChanged( "Indulok" );
            }
        }
        public bool Lezarva {
            get { return _lezarva; }
            set {
                _lezarva = value; 
                OnPropertyChanged( "Lezarva" );
            }
        }
        public bool DuplaBeirolap {
            get { return _duplabeirolap; }
            set {
                _duplabeirolap = value; 
                OnPropertyChanged( "DuplaBeirolap" );
            }
        }

        public Verseny() {
        }

        public Verseny(string megnevezes, string azonosito) {
            _megnevezes = megnevezes;
            _azonosito = azonosito;
        }

        public Verseny(string azonosito, string megnevezes, string datum, string versenysorozat, int osszes, int allomasok, int indulok, bool lezarva, bool duplabeirolap) {
            _azonosito = azonosito;
            _megnevezes = megnevezes;
            _datum = datum;
            _versenysorozat = versenysorozat;
            _osszes = osszes;
            _allomasok = allomasok;
            _indulok = indulok;
            _lezarva = lezarva;
            _duplabeirolap = duplabeirolap;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged( string propertyName ) {
            if( PropertyChanged != null ) {
                PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }
    }
}
