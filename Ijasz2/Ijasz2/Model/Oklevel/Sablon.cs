using System.ComponentModel;

namespace Ijasz2.Model.Oklevel {
    /// <summary>
    ///     mivel csak az azonosito, tipus van kirakva, igy csak arra kell notify
    /// </summary>
    public class Sablon : INotifyPropertyChanged {
        private string _azonosito;
        private string _tipus;

        public string Azonosito {
            get { return _azonosito; }
            set {
                _azonosito = value;
                OnPropertyChanged("Azonosito");
            }
        }

        public string Tipus {
            get { return _tipus; }
            set {
                _tipus = value;
                OnPropertyChanged("Tipus");
            }
        }

        public SablonMezo Verseny { get; set; }
        public SablonMezo Versenysorozat { get; set; }
        public SablonMezo Helyezes { get; set; }
        public SablonMezo Indulo { get; set; }
        public SablonMezo Egyesulet { get; set; }
        public SablonMezo Ijtipus { get; set; }
        public SablonMezo Korosztaly { get; set; }
        public SablonMezo InduloNem { get; set; }
        public SablonMezo Datum { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}