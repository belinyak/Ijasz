using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Eredmeny {
    public class Eredmeny : INotifyPropertyChanged {
        private string _verseny;
        private string _indulo;
        private int _sorszam;
        private string _ijtipus;
        private int _csapat;
        private int _talalat10;
        private int _talalat8;
        private int _talalat5;
        private int _melle;
        private int _osszpont;
        private int _szazalek;
        private bool _megjelent;
        private bool _korosztalymodositott;
        private string _korosztalyazonosito;

        public string Verseny {
            get { return _verseny; }
            set {
                _verseny = value;
                OnPropertyChanged( "Verseny" );
            }
        }
        public string Indulo {
            get { return _indulo; }
            set {
                _indulo = value;
                OnPropertyChanged( "Indulo" );
            }
        }
        public int Sorszam {
            get { return _sorszam; }
            set {
                _sorszam = value;
                OnPropertyChanged( "Sorszam" );
            }
        }
        public string Ijtipus {
            get { return _ijtipus; }
            set {
                _ijtipus = value;
                OnPropertyChanged( "Ijtipus" );
            }
        }
        public int Csapat {
            get { return _csapat; }
            set {
                _csapat = value;
                OnPropertyChanged( "Csapat" );
            }
        }
        public int Talalat10 {
            get { return _talalat10; }
            set {
                _talalat10 = value;
                OnPropertyChanged( "Talalat10" );
            }
        }
        public int Talalat8 {
            get { return _talalat8; }
            set {
                _talalat8 = value;
                OnPropertyChanged( "Talalat8" );
            }
        }
        public int Talalat5 {
            get { return _talalat5; }
            set {
                _talalat5 = value;
                OnPropertyChanged( "Talalat5" );
            }
        }
        public int Melle {
            get { return _melle; }
            set {
                _melle = value;
                OnPropertyChanged( "Melle" );
            }
        }
        public int OsszPont {
            get { return _osszpont; }
            set {
                _osszpont = value;
                OnPropertyChanged( "OsszPont" );
            }
        }
        public int Szazalek {
            get { return _szazalek; }
            set {
                _szazalek = value;
                OnPropertyChanged( "Szazalek" );
            }
        }
        public bool Megjelent {
            get { return _megjelent; }
            set {
                _megjelent = value;
                OnPropertyChanged( "Megjelent" );
            }
        }
        public bool KorosztalyModositott {
            get { return _korosztalymodositott; }
            set {
                _korosztalymodositott = value;
                OnPropertyChanged( "KorosztalyModositott" );
            }
        }
        public string KorosztalyAzonosito {
            get { return _korosztalyazonosito; }
            set {
                _korosztalyazonosito = value;
                OnPropertyChanged( "KorosztalyAzonosito" );
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
