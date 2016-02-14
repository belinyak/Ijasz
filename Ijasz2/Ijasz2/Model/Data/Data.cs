using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ijasz2.Model.Versenysorozat;

namespace Ijasz2.Model.Data {
    public class Data {
        public static Model.Versenysorozat.Versenysorozatok Versenysorozatok;

        public Data() {
            Versenysorozatok = new Versenysorozatok();
            Versenysorozatok.Load();
        }
    }
}
