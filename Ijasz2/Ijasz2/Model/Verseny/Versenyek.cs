using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ijasz2.Model.Eredmeny;
using Ijasz2.Model.Korosztaly;

namespace Ijasz2.Model.Verseny {
    public class Versenyek {
        public ObservableCollection<Verseny> _versenyek;

        /// <summary>
        /// TODO itt kellene default korosztalyokat felvenni
        /// TODO itt kell az eredmenyeket letrehozni
        /// </summary>
        /// <param name="verseny"></param>
        public void Add( Verseny verseny ) {
            _versenyek.Add( verseny );
            Adatbazis.Verseny.Verseny.Add(verseny);

            VersenyEredmeny versenyEredmeny = new VersenyEredmeny(verseny.Azonosito);
            if (Data.Data.Eredmenyek == null) {
                Data.Data.Eredmenyek = new VersenyEredmenyek {_versenyEredmenyek = new List<VersenyEredmeny>()};
            }
            Data.Data.Eredmenyek._versenyEredmenyek.Add(versenyEredmeny);


            VersenyKorosztaly versenyKorosztaly = new VersenyKorosztaly(verseny.Azonosito);

            versenyKorosztaly.Korosztalyok.Add( new Korosztaly.Korosztaly {
                Verseny = verseny.Azonosito,
                Azonosito = "k10" + verseny.Azonosito,
                AlsoHatar = 9,
                FelsoHatar = 20
            } );

            if( Data.Data.Korosztalyok == null ) {
                Data.Data.Korosztalyok = new VersenyKorosztalyok {_versenyKorosztalyok = new List<VersenyKorosztaly>()};
            }
            Data.Data.Korosztalyok._versenyKorosztalyok.Add( versenyKorosztaly );
        }

        /// <summary>
        /// torleskor a versenyhez tartozo korosztalyokat is torolni kell
        /// </summary>
        /// <param name="azonosito"></param>
        public void Remove( string azonosito ) {
            _versenyek.Remove( _versenyek.Single( s => s.Azonosito.Equals( azonosito ) ) );
            Adatbazis.Verseny.Verseny.Remove(azonosito);

            foreach( var versenyKorosztaly in Data.Data.Korosztalyok._versenyKorosztalyok ) {
                if( versenyKorosztaly.VersenyAzonosito.Equals( azonosito ) ) {
                    Data.Data.Korosztalyok._versenyKorosztalyok.Remove( versenyKorosztaly );
                    return;
                }
            }
        }

        /// <summary>
        /// Egyesével kell módosítani a mezőket, hogy a nem szettelt mezők, pl:indulokszama ne 0-zódjon ki
        /// </summary>
        /// <param name="ujVerseny"></param>
        public void Modify( Verseny ujVerseny ) {
            for( var i = 0; i < _versenyek.Count; i++ ) {
                if( _versenyek[i].Azonosito.Equals( ujVerseny.Azonosito ) ) {
                    _versenyek[i].Megnevezes = ujVerseny.Megnevezes;
                    _versenyek[i].Datum = ujVerseny.Datum;
                    _versenyek[i].Versenysorozat = ujVerseny.Versenysorozat;
                    _versenyek[i].Osszes = ujVerseny.Osszes;
                    _versenyek[i].Allomasok = ujVerseny.Allomasok;
                    _versenyek[i].DuplaBeirolap = ujVerseny.DuplaBeirolap;
                    Adatbazis.Verseny.Verseny.Update(ujVerseny);
                    return;
                }
            }
        }

        /// <summary>
        /// adatok db-ből
        /// </summary>
        public void Load( ) {
            _versenyek = Adatbazis.Verseny.Verseny.Load();

            //_versenyek = new ObservableCollection<Verseny>( );

            //Data.Data.Versenyek.Add( new Verseny { Azonosito = "ve1", Megnevezes = "verseny1" } );
            //Data.Data.Versenyek.Add( new Verseny { Azonosito = "ve2", Megnevezes = "verseny2" } );
            //Data.Data.Versenyek.Add( new Verseny { Azonosito = "ve3", Megnevezes = "verseny3" } );
            //Data.Data.Versenyek.Add( new Verseny { Azonosito = "ve4", Megnevezes = "verseny4" } );
        }
    }
}
