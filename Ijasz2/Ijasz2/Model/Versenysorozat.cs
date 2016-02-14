using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Ijasz2.Annotations;

namespace Ijasz2.Model {
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
            _azonosito = azonosito;
            _megnevezes = megnevezes;
            _versenyekszama = versenyekszama;
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
