﻿using System.Collections.ObjectModel;

namespace Ijasz2.Model.Korosztaly {
    public class VersenyKorosztaly {
        public ObservableCollection<Korosztaly> Korosztalyok { get; set; }
        public string VersenyAzonosito { get; set; }

        public VersenyKorosztaly( ) {
        }

        public VersenyKorosztaly( string versenyAzonosito ) {
            VersenyAzonosito = versenyAzonosito;
            Korosztalyok = new ObservableCollection<Korosztaly>( );
        }
    }
}
