using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ijasz2.Model.Verseny;
using Ijasz2.Model.Versenysorozat;

namespace Ijasz2.Model.Data {
    public class Data {
        public static Model.Versenysorozat.Versenysorozatok Versenysorozatok;
        public static Model.Verseny.Versenyek Versenyek;

        public Data() {
            Versenysorozatok = new Versenysorozatok();
            Versenyek = new Versenyek();
            
            Versenyek.Load();
            Versenysorozatok.Load();
        }
    }
}
