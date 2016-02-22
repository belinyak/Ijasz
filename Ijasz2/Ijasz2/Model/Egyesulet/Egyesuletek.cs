﻿using System.Collections.ObjectModel;
using System.Linq;

namespace Ijasz2.Model.Egyesulet {
    public class Egyesuletek {
        public ObservableCollection<Egyesulet> _egyesuletek;

        /// <summary> |
        /// model add
        /// adatbazis add
        /// </summary>
        /// <param name="egyesulet"></param>
        public void Add( Egyesulet egyesulet ) {
            _egyesuletek.Add( egyesulet );
            Adatbazis.Egyesulet.Egyesulet.Add( egyesulet );
        }

        /// <summary> |
        /// csak akkor torolheto, ha tagokszama 0 |
        /// model torles |
        /// adatbazis torles |
        /// </summary>
        /// <param name="egyesulet"></param>
        public void Remove( Egyesulet egyesulet ) {
            if( egyesulet.TagokSzama.Equals( 0 ) ) {
                _egyesuletek.Remove(
                        _egyesuletek.Single(
                            s => s.Azonosito.Equals( egyesulet.Azonosito ) ) );
                Adatbazis.Egyesulet.Egyesulet.Remove( egyesulet.Azonosito );
            }
        }

        /// <summary> |
        /// model update |
        /// adatbazis update |
        /// </summary>
        /// <param name="_egyesulet"></param>
        public void Update( Egyesulet _egyesulet ) {
            foreach( Egyesulet egyesulet in _egyesuletek ) {
                if( egyesulet.Azonosito.Equals( _egyesulet.Azonosito ) ) {
                    egyesulet.Cim = _egyesulet.Cim;
                    egyesulet.Vezeto = _egyesulet.Vezeto;
                    egyesulet.Telefon1 = _egyesulet.Telefon1;
                    egyesulet.Telefon2 = _egyesulet.Telefon2;
                    egyesulet.Email1 = _egyesulet.Email1;
                    egyesulet.Email2 = _egyesulet.Email2;
                    egyesulet.Listazando = _egyesulet.Listazando;
                    egyesulet.TagokSzama = _egyesulet.TagokSzama;
                    Adatbazis.Egyesulet.Egyesulet.Update( egyesulet );
                }
            }
        }

        /// <summary> |
        /// adatok betoltese adatbazisbol |
        /// </summary>
        public void Load( ) {
            _egyesuletek = Adatbazis.Egyesulet.Egyesulet.Load( );
        }
    }
}
