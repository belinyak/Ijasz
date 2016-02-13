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
    class Versenysorozat {

        public string Azonosito { get; set; }
        public string Megnevezes { get; set; }
        public int VersenyekSzama { get; set; }

        public Versenysorozat(string azonosito, string megnevezes, int versenyekSzama) {
            Azonosito = azonosito;
            Megnevezes = megnevezes;
            VersenyekSzama = versenyekSzama;
        }

        public override string ToString() {
            //return base.ToString();
            return "azonosito: " + Azonosito + Environment.NewLine + "megnevezes: " + Megnevezes +
                           Environment.NewLine + "versenyek szama: " + VersenyekSzama;
        }

    }
}
