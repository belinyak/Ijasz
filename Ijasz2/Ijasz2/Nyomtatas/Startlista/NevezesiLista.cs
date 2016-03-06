using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ijasz2.Nyomtatas.Startlista {
    class NevezesiLista {
        private readonly string _versenyAzonosito;

        public NevezesiLista(string versenyAzonosito) {
            _versenyAzonosito = versenyAzonosito;
            Nyomtat(versenyAzonosito);
        }

        private static string Nyomtat(string versenyAzonosito) {
            return "";
        }
    }
}
