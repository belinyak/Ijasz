using System.ComponentModel;

namespace Ijasz2.Model.Indulo {
    public class Indulo : INotifyPropertyChanged {
        private string _egyesulet;
        private string _engedely;
        private int _eredmenyek;
        private string _nem;
        private string _nev;
        private string _szuletesidatum;

        public string Nev {
            get { return _nev; }
            set {
                _nev = value;
                OnPropertyChanged("Nev");
            }
        }

        public string Nem {
            get { return _nem; }
            set {
                _nem = value;
                OnPropertyChanged("Nem");
            }
        }

        public string SzuletesiDatum {
            get { return _szuletesidatum; }
            set {
                _szuletesidatum = value;
                OnPropertyChanged("SzuletesiDatum");
            }
        }

        public string Engedely {
            get { return _engedely; }
            set {
                _engedely = value;
                OnPropertyChanged("Engedely");
            }
        }

        public string Egyesulet {
            get { return _egyesulet; }
            set {
                _egyesulet = value;
                OnPropertyChanged("Egyesulet");
            }
        }

        public int Eredmenyek {
            get { return _eredmenyek; }
            set {
                _eredmenyek = value;
                OnPropertyChanged("Eredmenyek");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}