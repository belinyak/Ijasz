using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Model.Oklevel {
    public class SablonMezo {
        private int _x;
        private int _y;
        private int _hossz;
        private string _formatum;
        private int _betumeret;
        private string _betutipus;
        private string _igazitas;

        public int X {
            get { return _x; }
            set {
                _x = value;
            }
        }
        public int Y {
            get { return _y; }
            set {
                _y = value;
            }
        }
        public int Hossz {
            get { return _hossz; }
            set {
                _hossz = value;
            }
        }
        public string Formatum {
            get { return _formatum; }
            set {
                _formatum = value;
            }
        }
        public int BetuMeret {
            get { return _betumeret; }
            set {
                _betumeret = value;
            }
        }
        public string Betutipus {
            get { return _betutipus; }
            set {
                _betutipus = value;
            }
        }
        public string Igazitas {
            get { return _igazitas; }
            set {
                _igazitas = value;
            }
        }
    }
}
