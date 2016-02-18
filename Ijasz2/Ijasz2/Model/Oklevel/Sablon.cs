using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Oklevel {
    /// <summary>
    /// TODO elég ennyi notify ???
    /// </summary>
    public class Sablon : INotifyPropertyChanged {
        private string _azonosito;
        private string _tipus;
        private SablonMezo _verseny;
        private SablonMezo _versenysorozat;
        private SablonMezo _helyezes;
        private SablonMezo _indulo;
        private SablonMezo _egyesulet;
        private SablonMezo _ijtipus;
        private SablonMezo _korosztaly;
        private SablonMezo _induloneme;
        private SablonMezo _datum;

        public string Azonosito {
            get { return _azonosito; }
            set {
                _azonosito = value;
                OnPropertyChanged( "Azonosito" );
            }
        }
        public string Tipus {
            get { return _tipus; }
            set {
                _tipus = value;
                OnPropertyChanged( "Tipus" );
            }
        }
        public SablonMezo Verseny {
            get { return _verseny; }
            set { _verseny = value; }
        }
        public SablonMezo Versenysorozat {
            get { return _versenysorozat; }
            set { _versenysorozat = value; }
        }
        public SablonMezo Helyezes {
            get { return _helyezes; }
            set { _helyezes = value; }
        }
        public SablonMezo Indulo {
            get { return _indulo; }
            set { _indulo = value; }
        }
        public SablonMezo Egyesulet {
            get { return _egyesulet; }
            set { _egyesulet = value; }
        }
        public SablonMezo Ijtipus {
            get { return _ijtipus; }
            set { _ijtipus = value; }
        }
        public SablonMezo Korosztaly {
            get { return _korosztaly; }
            set { _korosztaly = value; }
        }
        public SablonMezo InduloNem {
            get { return _induloneme; }
            set { _induloneme = value; }
        }
        public SablonMezo Datum {
            get { return _datum; }
            set { _datum = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged( string propertyName ) {
            if( PropertyChanged != null ) {
                PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }
    }
}
