using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
      public string Nev;
      public string Nem;
      public string SzuletesiDatum;
      public string Engedely;
      public string Egyesulet;
      public int Eredmenyek;
*/
namespace Ijasz2.Model.Indulo {
    public class Indulo : INotifyPropertyChanged {
        private string _nev;
        private string _nem;
        private string _szuletesidatum;
        private string _engedely;
        private string _egyesulet;
        private int _eredmenyek;

        public string Nev {
            get { return _nev; }
            set {
                _nev = value;
                OnPropertyChanged( "Nev" );
            }
        }
        public string Nem {
            get { return _nem; }
            set { _nem = value; }
        }
        public string SzuletesiDatum {
            get { return _szuletesidatum; }
            set {
                _szuletesidatum = value;
                OnPropertyChanged( "SzuletesiDatum" );
            }
        }
        public string Engedely {
            get { return _engedely; }
            set {
                _engedely = value;
                OnPropertyChanged( "Engedely" );
            }
        }
        public string Egyesulet {
            get { return _egyesulet; }
            set {
                _egyesulet = value;
                OnPropertyChanged( "Egyesulet" );
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
