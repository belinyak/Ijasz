using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Ijtipus {
    public class Ijtipus : INotifyPropertyChanged {

        private string _azonosito;
        private string _megnevezes;
        private int _sorszam;
        private int _eredmenyek;

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
        public int Sorszam {
            get { return _sorszam; }
            set {
                _sorszam = value;
                OnPropertyChanged( "Sorszam" );
            }
        }
        public int Eredmenyek {
            get { return _eredmenyek; }
            set {
                _eredmenyek = value;
                OnPropertyChanged( "Eredmenyek" );
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
