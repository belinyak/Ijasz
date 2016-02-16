using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ijasz2.Model.Ijtipus;
using Ijasz2.Model.Korosztaly;
using Ijasz2.Model.Verseny;
using Ijasz2.Model.Versenysorozat;

namespace Ijasz2.Model.Data {
    public class Data {
        public static Model.Versenysorozat.Versenysorozatok Versenysorozatok;
        public static Model.Verseny.Versenyek Versenyek;
        public static Model.Korosztaly.Korosztalyok Korosztalyok;
        public static Model.Ijtipus.Ijtipusok Ijtipusok;

        public Data() {
            Versenysorozatok = new Versenysorozatok();
            Versenyek = new Versenyek();
            Korosztalyok = new Korosztalyok();
            Ijtipusok = new Ijtipusok();

            Versenyek.Load();
            Versenysorozatok.Load();
            Korosztalyok.Load();
            Ijtipusok.Load();
        }
    }
}
