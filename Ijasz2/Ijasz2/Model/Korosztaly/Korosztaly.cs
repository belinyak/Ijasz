﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Korosztaly {
    public class Korosztaly : INotifyPropertyChanged {
        private string _verseny;
        private string _azonosito;
        private string _megnevezes;
        private int _alsohatar;
        private int _felsohatar;
        private bool _nokre;
        private bool _ferfiakra;
        private int _indulonok;
        private int _induloferfiak;
        private bool _egyben;

        public string Verseny {
            get { return _verseny; }
            set {
                _verseny = value;
                OnPropertyChanged( "Verseny" );
            }
        }
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
        public int AlsoHatar {
            get { return _alsohatar; }
            set {
                _alsohatar = value;
                OnPropertyChanged( "AlsoHatar" );
            }
        }
        public int FelsoHatar {
            get { return _felsohatar; }
            set {
                _felsohatar = value;
                OnPropertyChanged( "FelsoHatar" );
            }
        }
        public bool Nokre {
            get { return _nokre; }
            set {
                _nokre = value;
                OnPropertyChanged( "Nokre" );
            }
        }
        public bool Ferfiakra {
            get { return _ferfiakra; }
            set {
                _ferfiakra = value;
                OnPropertyChanged( "Ferfiakra" );
            }
        }
        public int InduloNok {
            get { return _indulonok; }
            set {
                _indulonok = value;
                OnPropertyChanged( "InduloNok" );
            }
        }
        public int InduloFerfiak {
            get { return _induloferfiak; }
            set {
                _induloferfiak = value;
                OnPropertyChanged( "InduloFerfiak" );

            }
        }
        public bool Egyben {
            get { return _egyben; }
            set {
                _egyben = value;
                OnPropertyChanged( "Egyben" );
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
