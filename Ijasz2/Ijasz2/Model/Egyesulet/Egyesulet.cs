using System.ComponentModel;

namespace Ijasz2.Model.Egyesulet {
    public class Egyesulet : INotifyPropertyChanged {
        private string _azonosito;
        private string _cim;
        private string _vezeto;
        private string _telefon1;
        private string _telefon2;
        private string _email1;
        private string _email2;
        private bool _listazando;
        private int _tagokszama;

        public string Azonosito {
            get { return _azonosito; }
            set {
                _azonosito = value;
                OnPropertyChanged( "Azonosito" );
            }
        }
        public string Cim {
            get { return _cim; }
            set {
                _cim = value;
                OnPropertyChanged( "Cim" );
            }
        }
        public string Vezeto {
            get { return _vezeto; }
            set {
                _vezeto = value;
                OnPropertyChanged( "Vezeto" );
            }
        }
        public string Telefon1 {
            get { return _telefon1; }
            set {
                _telefon1 = value;
                OnPropertyChanged( "Telefon1" );
            }
        }
        public string Telefon2 {
            get { return _telefon2; }
            set {
                _telefon2 = value;
                OnPropertyChanged( "Telefon2" );
            }
        }
        public string Email1 {
            get { return _email1; }
            set {
                _email1 = value;
                OnPropertyChanged( "Email1" );
            }
        }
        public string Email2 {
            get { return _email2; }
            set {
                _email2 = value;
                OnPropertyChanged( "Email2" );
            }
        }
        public bool Listazando {
            get { return _listazando; }
            set {
                _listazando = value;
                OnPropertyChanged( "Listazando" );
            }
        }
        public int TagokSzama {
            get { return _tagokszama; }
            set {
                _tagokszama = value;
                OnPropertyChanged( "TagokSzama" );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged( string propertyName ) {
            if( PropertyChanged != null ) {
                PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }
    }
}
