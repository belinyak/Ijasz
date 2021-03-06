﻿using System.ComponentModel;

namespace Ijasz2.Model.Eredmeny {
    public class Eredmeny : INotifyPropertyChanged {
        private int _csapat;
        private string _ijtipus;
        private string _indulo;
        private string _korosztalyazonosito;
        private bool _korosztalymodositott;
        private bool _megjelent;
        private int _melle;
        private int _osszpont;
        private int _sorszam;
        private int _szazalek;
        private int _talalat10;
        private int _talalat5;
        private int _talalat8;
        private string _verseny;
        private int _kor;

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

        public int Kor {
            get { return _kor; }
            set {
                _kor = value;
                OnPropertyChanged( "Kor" );

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged( string propertyName ) {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}