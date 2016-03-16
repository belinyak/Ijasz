using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Ijasz2.Model.Data;
using Ijasz2.Model.Eredmeny;

namespace Ijasz2.Nyomtatas.Seged {
    internal struct Eredmenyek {
        public List<InduloAdat> Nok { get; set; }
        public List<InduloAdat> Ferfiak { get; set; }
        public List<InduloAdat> Egyben { get; set; }

        public bool IsEmpty( ) {
            return Nok.Count.Equals( 0 ) && Ferfiak.Count.Equals( 0 ) && Egyben.Count.Equals( 0 );
        }

        public Eredmenyek( string azonosito, string ijtipusAzonosito, string korosztalyAzonosito,
            bool korosztalyEgyben, string dokumentumTipus ) {
            Nok = new List<InduloAdat>( );
            Ferfiak = new List<InduloAdat>( );
            Egyben = new List<InduloAdat>( );

            switch( dokumentumTipus ) {
                case DokumentumTipus.Eredmenylap.Verseny.Teljes:
                    LoadVersenyTeljes( azonosito, ijtipusAzonosito, korosztalyAzonosito, korosztalyEgyben );
                    break;
                case DokumentumTipus.Eredmenylap.Verseny.MISZ:
                    LoadVersenyMisz( azonosito, ijtipusAzonosito, korosztalyAzonosito, korosztalyEgyben );
                    break;
                case DokumentumTipus.Eredmenylap.VersenySorozat.Teljes:
                    LoadVersenysorozatTeljes( azonosito, ijtipusAzonosito, korosztalyAzonosito, korosztalyEgyben );
                    break;
                case DokumentumTipus.Eredmenylap.VersenySorozat.MISZ:
                    //LoadVersenysorozatMisz( );
                    break;
            }

            Nok = Nok.OrderByDescending( adat => adat.OsszPont ).ToList( );
            Ferfiak = Ferfiak.OrderByDescending( adat => adat.OsszPont ).ToList( );
            Egyben = Egyben.OrderByDescending( adat => adat.OsszPont ).ToList( );
        }

        private void LoadVersenyTeljes( string versenyAzonosito, string ijtipusAzonosito, string korosztalyAzonosito,
            bool korosztalyEgyben ) {
            foreach( var versenyeredmenyek in Data.Eredmenyek._versenyEredmenyek.Where(
                            eredmeny => eredmeny.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                var osszesInduloAdat = (from indulo1 in Data.Indulok._indulok
                                        join eredmeny in versenyeredmenyek.Eredmenyek._eredmenyek on indulo1.Nev equals
                            eredmeny.Indulo
                                        where eredmeny.Ijtipus.Equals(ijtipusAzonosito)
                                                  && eredmeny.KorosztalyAzonosito.Equals(korosztalyAzonosito)
                                                  && eredmeny.Megjelent.Equals(true)
                                        select new InduloAdat {
                                            Nev = eredmeny.Indulo,
                                            Ijtipus = "nem használt",
                                            KorosztalyMegnevezes = "nem használt",
                                            Nem = indulo1.Nem,
                                            Engedely = indulo1.Engedely,
                                            OsszPont = eredmeny.OsszPont,
                                            Szazalek = eredmeny.Szazalek,
                                            Csapat = eredmeny.Csapat,
                                            Egyesulet = indulo1.Egyesulet,
                                            Kor = eredmeny.Kor,
                                            Sorszam = eredmeny.Sorszam,
                                        }).ToList();

                if( korosztalyEgyben.Equals( true ) ) {
                    Egyben = osszesInduloAdat;
                }
                else {
                    foreach( var induloAdat in osszesInduloAdat ) {
                        if( induloAdat.Nem.ToLower( ).Equals( "n" ) ) {
                            Nok.Add( induloAdat );
                        }
                        else {
                            Ferfiak.Add( induloAdat );
                        }
                    }
                }
            }
        }
        private void LoadVersenyMisz( string versenyAzonosito, string ijtipusAzonosito, string korosztalyAzonosito,
            bool korosztalyEgyben ) {
            foreach(
                  var versenyeredmenyek in
                      Data.Eredmenyek._versenyEredmenyek.Where(
                          eredmeny => eredmeny.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                var osszesInduloAdat =
                        (from indulo1 in
                            Data.Indulok._indulok.Where(indulo => !string.IsNullOrEmpty(indulo.Engedely))
                         join eredmeny in versenyeredmenyek.Eredmenyek._eredmenyek on indulo1.Nev equals
                                eredmeny.Indulo
                         where eredmeny.Ijtipus.Equals(ijtipusAzonosito)
                                  && eredmeny.KorosztalyAzonosito.Equals(korosztalyAzonosito)
                                  && eredmeny.Megjelent.Equals(true)
                         select new InduloAdat {
                             Nev = eredmeny.Indulo,
                             Ijtipus = "nem használt",
                             KorosztalyMegnevezes = "nem használt",
                             Nem = indulo1.Nem,
                             Engedely = indulo1.Engedely,
                             OsszPont = eredmeny.OsszPont,
                             Szazalek = eredmeny.Szazalek,
                             Csapat = eredmeny.Csapat,
                             Egyesulet = indulo1.Egyesulet,
                             Kor = eredmeny.Kor,
                             Sorszam = eredmeny.Sorszam,
                         }).ToList();

                if( korosztalyEgyben.Equals( true ) ) {
                    Egyben = osszesInduloAdat;
                }
                else {
                    foreach( var induloAdat in osszesInduloAdat ) {
                        if( induloAdat.Nem.ToLower( ).Equals( "n" ) ) {
                            Nok.Add( induloAdat );
                        }
                        else {
                            Ferfiak.Add( induloAdat );
                        }
                    }
                }
            }
        }
        private void LoadVersenysorozatTeljes( string versenysorozatAzonosito, string ijtipusAzonosito, string korosztalyAzonosito,
            bool korosztalyEgyben ) {
            // lekerem az osszes eredmeny-t
            List<InduloAdat> osszesInduloAdat = new List<InduloAdat>();

            // TODO erdekel-e hogy megjelent vagy nem ????
            var versenyekSzama =
                (from q in Model.Data.Data.Versenyek._versenyek
                 where q.Versenysorozat.Equals(versenysorozatAzonosito)
                 select q.Azonosito).Count();

            foreach( var verseny in Model.Data.Data.Versenyek._versenyek.Where( verseny => verseny.Versenysorozat.Equals( versenysorozatAzonosito ) ) ) {
                foreach( var versenyeredmenyek in Data.Eredmenyek._versenyEredmenyek.Where(
                                eredmeny => eredmeny.VersenyAzonosito.Equals( verseny.Azonosito ) ) ) {
                    var q = (from indulo1 in Data.Indulok._indulok
                             join eredmeny in versenyeredmenyek.Eredmenyek._eredmenyek
                                            on indulo1.Nev equals eredmeny.Indulo
                             where eredmeny.Ijtipus.Equals(ijtipusAzonosito)
                                                  && eredmeny.KorosztalyAzonosito.Equals(korosztalyAzonosito)
                                                  && eredmeny.Megjelent.Equals(true)
                             select new InduloAdat {
                                 Nev = eredmeny.Indulo,
                                 Ijtipus = "nem használt",
                                 KorosztalyMegnevezes = "nem használt",
                                 Nem = indulo1.Nem,
                                 Engedely = indulo1.Engedely,
                                 OsszPont = eredmeny.OsszPont,
                                 Szazalek = eredmeny.Szazalek,
                                 Csapat = eredmeny.Csapat,
                                 Egyesulet = indulo1.Egyesulet,
                                 Kor = eredmeny.Kor,
                                 Sorszam = eredmeny.Sorszam,
                             }).ToList();
                    osszesInduloAdat.AddRange( q );
                }
            }

            // most kell egy group by sum magic
            var test = (from indulo in osszesInduloAdat
                        group indulo by indulo.Nev
                into indulo2
                        select new InduloAdat {
                            Nev = indulo2.First().Nev,
                            Ijtipus = "nem használt",
                            KorosztalyMegnevezes = "nem használt",
                            Nem = indulo2.First().Nem,
                            Engedely = indulo2.First().Engedely,
                            OsszPont = indulo2.Sum(adat => adat.OsszPont),
                            Szazalek = indulo2.Sum(adat => adat.Szazalek)/versenyekSzama,
                            Csapat = indulo2.First().Csapat,
                            Egyesulet = indulo2.First().Egyesulet,
                            Kor = indulo2.First().Kor,
                            Sorszam = -666 // nem hasznalt
                        }).ToList();

            osszesInduloAdat = test;

            if( korosztalyEgyben.Equals( true ) ) {
                Egyben = osszesInduloAdat;
            }
            else {
                foreach( var induloAdat in osszesInduloAdat ) {
                    if( induloAdat.Nem.ToLower( ).Equals( "n" ) ) {
                        Nok.Add( induloAdat );
                    }
                    else {
                        Ferfiak.Add( induloAdat );
                    }
                }
            }
        }
        private void LoadVersenysorozatMisz( ) {

        }

    }

    internal struct Korosztaly {
        public string azonosito { get; set; }
        public string megnevezes { get; set; }
        public bool egyben { get; set; }
        public Eredmenyek eredmenyek { get; set; }
    }

    internal struct Korosztalyok {
        public List<Korosztaly> korosztalyok;

        /// <summary>
        /// | TODO itt nincs külömbség a misz-nél |
        /// azonosito lehet ve vagy vs |
        /// </summary>
        /// <param name="azonosito"></param>
        /// <param name="ijtipusAzonosito"></param>
        /// <param name="dokumentumTipus"></param>
        public Korosztalyok( string azonosito, string ijtipusAzonosito, string dokumentumTipus ) {
            korosztalyok = new List<Korosztaly>( );

            switch( dokumentumTipus ) {
                case DokumentumTipus.Eredmenylap.Verseny.Teljes:
                    LoadVersenyTeljes( azonosito, ijtipusAzonosito );
                    break;
                case DokumentumTipus.Eredmenylap.Verseny.MISZ:
                    LoadVersenyMisz( azonosito, ijtipusAzonosito );
                    break;
                case DokumentumTipus.Eredmenylap.VersenySorozat.Teljes:
                    LoadVersenySorozatTeljes( azonosito, ijtipusAzonosito );
                    break;
                case DokumentumTipus.Eredmenylap.VersenySorozat.MISZ:
                    LoadVersenySorozatMisz( azonosito, ijtipusAzonosito );
                    break;
            }
        }

        private void LoadVersenyTeljes( string versenyAzonosito, string ijtipusAzonosito ) {
            foreach( var versenyKorosztaly in Data.Korosztalyok._versenyKorosztalyok.Where(
                       korosztaly => korosztaly.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                foreach( var korosztaly in versenyKorosztaly.Korosztalyok ) {
                    korosztalyok.Add( new Korosztaly {
                        azonosito = korosztaly.Azonosito,
                        megnevezes = korosztaly.Megnevezes,
                        egyben = korosztaly.Egyben,
                        eredmenyek =
                            new Eredmenyek( versenyAzonosito, ijtipusAzonosito, korosztaly.Azonosito, korosztaly.Egyben,
                                DokumentumTipus.Eredmenylap.Verseny.Teljes )
                    } );
                }
            }
        }
        private void LoadVersenyMisz( string versenyAzonosito, string ijtipusAzonosito ) {
            foreach(
               var versenyKorosztaly in
                   Data.Korosztalyok._versenyKorosztalyok.Where(
                       korosztaly => korosztaly.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                foreach( var korosztaly in versenyKorosztaly.Korosztalyok ) {
                    korosztalyok.Add( new Korosztaly {
                        azonosito = korosztaly.Azonosito,
                        megnevezes = korosztaly.Megnevezes,
                        egyben = korosztaly.Egyben,
                        eredmenyek =
                            new Eredmenyek( versenyAzonosito, ijtipusAzonosito, korosztaly.Azonosito, korosztaly.Egyben,
                                DokumentumTipus.Eredmenylap.Verseny.MISZ )
                    } );
                }
            }
        }
        private void LoadVersenySorozatTeljes( string versenysorozatAzonosito, string ijtipusAzonosito ) {
            // eloszor kiszedem az osszeset

            List<Model.Korosztaly.Korosztaly> korosztalyList = new List<Model.Korosztaly.Korosztaly>();

            // minden a versenysorozathoz tartozo verseny minden korosztalya benne van
            foreach( var verseny in Model.Data.Data.Versenyek._versenyek.Where( verseny => verseny.Versenysorozat.Equals( versenysorozatAzonosito ) ) ) {
                foreach( var versenyKorosztaly in Model.Data.Data.Korosztalyok._versenyKorosztalyok.Where( korosztaly => korosztaly.VersenyAzonosito.Equals( verseny.Azonosito ) ) ) {
                    var z = (from q in versenyKorosztaly.Korosztalyok
                             select q).ToList();
                    korosztalyList.AddRange( z );
                }
            }


            var test = (from q in korosztalyList
                        group q by new {
                            q.AlsoHatar,
                            q.FelsoHatar,
                            q.Ferfiakra,
                            q.Nokre,
                            q.Egyben
                        }
                into q2
                        select new Korosztaly {
                            azonosito = q2.First().Azonosito,
                            megnevezes = q2.First().Megnevezes,
                            egyben = q2.First().Egyben,
                            eredmenyek =
                        new Eredmenyek(versenysorozatAzonosito, ijtipusAzonosito, q2.First().Azonosito,
                            q2.First().Egyben, DokumentumTipus.Eredmenylap.VersenySorozat.Teljes)
                        }).ToList();

            korosztalyok = test;
        }
        private void LoadVersenySorozatMisz( string versenysorozatAzonosito, string ijtipusAzonosito ) {

        }
    }

    internal struct Ijtipus {
        public string azonosito { get; set; }
        public string megnevezes { get; set; }
        public Korosztalyok korosztalyok { get; set; }
    }

    internal struct Ijtipusok {

        public List<Ijtipus> _ijtipusok { get; set; }

        /// <summary>
        /// | csak azok az ijtipusok, amelyekhez van eredmeny |
        ///  azonosito lehet verseny vagy versenysorozat |
        /// </summary>
        /// <param name="azonosito"></param>
        /// <param name="dokumentumTipus"></param>
        public Ijtipusok( string azonosito, string dokumentumTipus ) {
            _ijtipusok = new List<Ijtipus>( );

            switch( dokumentumTipus ) {
                case DokumentumTipus.Eredmenylap.Verseny.Teljes:
                    LoadVersenyTeljes( azonosito );
                    break;
                case DokumentumTipus.Eredmenylap.Verseny.MISZ:
                    LoadVersenyMisz( azonosito );
                    break;
                case DokumentumTipus.Eredmenylap.VersenySorozat.Teljes:
                    LoadVersenysorozatTeljes( azonosito );
                    break;
                    LoadVersenysorozatMisz( azonosito );
                case DokumentumTipus.Eredmenylap.VersenySorozat.MISZ:
                    break;
            }
        }

        private void LoadVersenyMisz( string versenyAzonosito ) {
            foreach( var versenyeredmenyek in Data.Eredmenyek._versenyEredmenyek.Where(
                            eredmeny => eredmeny.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                _ijtipusok = ( from ijtipus in Data.Ijtipusok._ijtipusok
                               join eredmeny in versenyeredmenyek.Eredmenyek._eredmenyek on ijtipus.Azonosito equals
                                   eredmeny.Ijtipus
                               join indulo in
                                   Data.Indulok._indulok.Where( indulo => !string.IsNullOrEmpty( indulo.Engedely ) )
                                   on eredmeny.Indulo equals indulo.Nev
                               select new Ijtipus {
                                   azonosito = ijtipus.Azonosito,
                                   megnevezes = ijtipus.Megnevezes,
                                   korosztalyok = new Korosztalyok( versenyAzonosito, ijtipus.Azonosito, DokumentumTipus.Eredmenylap.Verseny.MISZ )
                               } ).GroupBy( ijtipus => ijtipus.azonosito ).Select( grouping => grouping.First( ) ).ToList( );
            }
        }

        private void LoadVersenyTeljes( string versenyAzonosito ) {
            foreach(
                    var versenyeredmenyek in
                        Data.Eredmenyek._versenyEredmenyek.Where(
                            eredmeny => eredmeny.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                _ijtipusok = ( from ijtipus in Data.Ijtipusok._ijtipusok
                               join eredmeny in versenyeredmenyek.Eredmenyek._eredmenyek on ijtipus.Azonosito equals
                                   eredmeny.Ijtipus
                               select new Ijtipus {
                                   azonosito = ijtipus.Azonosito,
                                   megnevezes = ijtipus.Megnevezes,
                                   korosztalyok = new Korosztalyok( versenyAzonosito, ijtipus.Azonosito, DokumentumTipus.Eredmenylap.Verseny.Teljes )
                               } ).GroupBy( ijtipus => ijtipus.azonosito ).Select( grouping => grouping.First( ) ).ToList( );
            }
        }

        /// <summary>
        /// le kell kerni, az osszes ijtipust, kiszedni amelyikhez nincs eredmeny
        /// </summary>
        /// <param name="versenysorozatAzonosito"></param>
        private void LoadVersenysorozatTeljes( string versenysorozatAzonosito ) {
            // kell a versenysorozat összes versenye, azokhoz 
            // joinolni az eredmenyeket,
            // joinolni az ijtipusokat

            List<string> ijtipusokList = new List<string>();

            // vegigmegy a versenysorozat, z-be beteszi a verseny ijtipusait versenyen belül distinctbe, z-t hozzaadja ijtipusokList-hez
            foreach( var verseny in Model.Data.Data.Versenyek._versenyek.Where( verseny => verseny.Versenysorozat.Equals( versenysorozatAzonosito ) ) ) {
                foreach( var versenyeredmeny in Model.Data.Data.Eredmenyek._versenyEredmenyek.Where( eredmeny => eredmeny.VersenyAzonosito.Equals( verseny.Azonosito ) ) ) {
                    var z = (from asd in versenyeredmeny.Eredmenyek._eredmenyek
                             select asd.Ijtipus).Distinct().ToList();
                    ijtipusokList.AddRange( z );
                }
            }

            // ijtipusoklist distinctkent, tartalmazza az osszes ijtipust, ami kellhet
            _ijtipusok = ( from asd in ijtipusokList.Distinct( )
                           join ijtipus in Data.Ijtipusok._ijtipusok
                               on asd equals ijtipus.Azonosito
                           select new Ijtipus {
                               azonosito = ijtipus.Azonosito,
                               megnevezes = ijtipus.Megnevezes,
                               korosztalyok =
                                   new Korosztalyok( versenysorozatAzonosito, ijtipus.Azonosito,
                                       DokumentumTipus.Eredmenylap.VersenySorozat.Teljes )
                           } ).ToList( );
        }

        private void LoadVersenysorozatMisz( string versenysorozatAzonosito ) {

        }
    }
}
