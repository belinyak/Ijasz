﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Ijasz2.Model.Versenysorozat {
    public class Versenysorozatok {
        public ObservableCollection<Versenysorozat> _versenysorozatok;

        /// <summary>
        /// hozzaadas
        /// </summary>
        /// <param name="versenysorozat"></param>
        public void Add( Versenysorozat versenysorozat ) {
            _versenysorozatok.Add( versenysorozat );
        }

        /// <summary>
        /// torles
        /// </summary>
        /// <param name="azonosito"></param>
        public void Remove( string azonosito ) {
            _versenysorozatok.Remove(
                    _versenysorozatok.Single(
                        s => s.Azonosito.Equals( azonosito ) ) );
        }

        /// <summary>
        /// egyesével kell settelni!
        /// </summary>
        /// <param name="ujVersenysorozat"></param>
        public void Modify( Versenysorozat ujVersenysorozat ) {
            foreach( var versenysorozat in _versenysorozatok ) {
                if( versenysorozat.Azonosito.Equals( ujVersenysorozat.Azonosito ) ) {
                    versenysorozat.Megnevezes = ujVersenysorozat.Megnevezes;
                    return;
                }
            }
        }

        /// <summary>
        /// adatok betoltese db-bol
        /// </summary>
        public void Load( ) {
            _versenysorozatok = new ObservableCollection<Versenysorozat> {
                new Versenysorozat { Azonosito = "vs1", Megnevezes = "versenysorozat1", VersenyekSzama = 0},
                new Versenysorozat { Azonosito = "vs2", Megnevezes = "versenysorozat2", VersenyekSzama = 0},
                new Versenysorozat { Azonosito = "vs3", Megnevezes = "versenysorozat3", VersenyekSzama = 0}
            };
        }
    }
}
