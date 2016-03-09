using System.ComponentModel;

namespace Ijasz2.Model.Versenysorozat {
    public class Versenysorozat : INotifyPropertyChanged{
        private string _azonosito;
        private string _megnevezes;
        private int _versenyekszama;

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

        public int VersenyekSzama {
            get { return _versenyekszama; }
            set {
                _versenyekszama = value;
                OnPropertyChanged( "VersenyekSzama" );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged( string propertyName ) {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}