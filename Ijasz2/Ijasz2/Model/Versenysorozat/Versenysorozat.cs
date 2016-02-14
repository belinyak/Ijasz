using System;
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
                OnPropertyChanged("Azonosito");
            }
        }
        public string Megnevezes {
            get { return _megnevezes; }
            set {
                _megnevezes = value;
                OnPropertyChanged("Megnevezes");
            }
        }
        public int VersenyekSzama {
            get { return _versenyekszama; }
            set {
                _versenyekszama = value; 
                OnPropertyChanged("VersenyekSzama");
            }
        }


        public Versenysorozat() {
        }
        public Versenysorozat(string azonosito, string megnevezes, int versenyekszama) {
            Azonosito = azonosito;
            Megnevezes = megnevezes;
            VersenyekSzama = versenyekszama;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null){
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
            
        }

        public override string ToString() {
            //return base.ToString();
            return "azonosito: " + Azonosito + Environment.NewLine + "megnevezes: " + Megnevezes +
                           Environment.NewLine + "versenyek szama: " + VersenyekSzama;
        }
    }
}
