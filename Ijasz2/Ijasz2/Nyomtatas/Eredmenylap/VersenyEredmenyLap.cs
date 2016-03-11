using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using Ijasz2.Nyomtatas.Seged;
using Novacode;

namespace Ijasz2.Nyomtatas.Eredmenylap {

    struct Eredmenyek {
        public List<InduloAdat> nok { get; set; }
        public List<InduloAdat> ferfiak { get; set; }
        public List<InduloAdat> egyben { get; set; }

        public bool isEmpty( ) {
            return nok.Count.Equals( 0 ) && ferfiak.Count.Equals( 0 ) && egyben.Count.Equals( 0 );
        }

        public Eredmenyek( string versenyAzonosito, string ijtipusAzonosito, string korosztalyAzonosito, bool korosztalyEgyben ) {
            nok = new List<InduloAdat>( );
            ferfiak = new List<InduloAdat>( );
            egyben = new List<InduloAdat>( );

            foreach( var versenyeredmenyek in Model.Data.Data.Eredmenyek._versenyEredmenyek.Where( eredmeny => eredmeny.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                var osszesInduloAdat = (from indulo1 in Model.Data.Data.Indulok._indulok
                                        join eredmeny in versenyeredmenyek.Eredmenyek._eredmenyek on indulo1.Nev equals
                                eredmeny.Indulo
                                        where eredmeny.Ijtipus.Equals(ijtipusAzonosito)
                                  && eredmeny.KorosztalyAzonosito.Equals(korosztalyAzonosito)

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
                    egyben = osszesInduloAdat;
                }
                else {
                    foreach( var induloAdat in osszesInduloAdat ) {
                        if( induloAdat.Nem.ToLower( ).Equals( "n" ) ) {
                            nok.Add( induloAdat );
                        }
                        else {
                            ferfiak.Add( induloAdat );
                        }
                    }
                }
            }

            nok = nok.OrderByDescending( adat => adat.OsszPont ).ToList( );
            ferfiak = ferfiak.OrderByDescending( adat => adat.OsszPont ).ToList( );
            egyben = egyben.OrderByDescending( adat => adat.OsszPont ).ToList( );

        }
    }

    struct Korosztaly {
        public string azonosito { get; set; }
        public string megnevezes { get; set; }
        public bool egyben { get; set; }
        public Eredmenyek eredmenyek { get; set; }
    }

    struct Korosztalyok {
        public List<Korosztaly> korosztalyok;

        public Korosztalyok( string versenyAzonosito, string ijtipusAzonosito ) {
            korosztalyok = new List<Korosztaly>( );

            foreach( var versenyKorosztaly in Model.Data.Data.Korosztalyok._versenyKorosztalyok.Where( korosztaly => korosztaly.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                foreach( var korosztaly in versenyKorosztaly.Korosztalyok ) {
                    korosztalyok.Add( new Korosztaly {
                        azonosito = korosztaly.Azonosito,
                        megnevezes = korosztaly.Megnevezes,
                        egyben = korosztaly.Egyben,
                        eredmenyek = new Eredmenyek( versenyAzonosito, ijtipusAzonosito, korosztaly.Azonosito, korosztaly.Egyben )
                    } );
                }
            }
        }
    }

    struct Ijtipus {
        public string azonosito { get; set; }
        public string megnevezes { get; set; }
        public Korosztalyok korosztalyok { get; set; }
    }

    struct Ijtipusok {
        public List<Ijtipus> _ijtipusok { get; set; }

        /// <summary>
        /// csak azok az ijtipusok, amelyekhez van eredmeny a versenyen
        /// </summary>
        /// <param name="versenyAzonosito"></param>
        public Ijtipusok( string versenyAzonosito ) {
            _ijtipusok = new List<Ijtipus>( );

            foreach( var versenyeredmenyek in Model.Data.Data.Eredmenyek._versenyEredmenyek.Where( eredmeny => eredmeny.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                _ijtipusok = ( from ijtipus in Model.Data.Data.Ijtipusok._ijtipusok
                               join eredmeny in versenyeredmenyek.Eredmenyek._eredmenyek on ijtipus.Azonosito equals
                              eredmeny.Ijtipus
                               select new Ijtipus {
                                   azonosito = ijtipus.Azonosito,
                                   megnevezes = ijtipus.Megnevezes,
                                   korosztalyok = new Korosztalyok( versenyAzonosito, ijtipus.Azonosito )
                               } ).GroupBy( ijtipus => ijtipus.azonosito ).Select( grouping => grouping.First( ) ).ToList( );
            }
        }
    }

    public class VersenyEredmenyLap {
        private VersenyAdatok versenyAdatok;
        private Ijtipusok ijtipusok;
        private DocX document { get; set; }

        public VersenyEredmenyLap( string dokumentumTipus, string versenyAzonosito ) {
            versenyAdatok = new VersenyAdatok( versenyAzonosito );
            ijtipusok = new Ijtipusok( versenyAzonosito );
        }

        private string CreateDoc( ) {
            var fileName = Seged.Seged.CreateFileName(versenyAdatok.VersenysorozatAzonosito, versenyAdatok.Azonosito,
                DokumentumTipus.Eredmenylap.Verseny.Teljes);

            document = DocX.Create( fileName );
            document.AddHeaders( );
            Seged.Seged.OldalSzamozas( document );

            var header = document.Headers.odd;
            AddHeader( header );
            EredmenylapVersenyTeljesHeaderTablazat( header );

            foreach( var ijtipus in ijtipusok._ijtipusok ) {
                Table table ;
                foreach( var korosztaly in ijtipus.korosztalyok.korosztalyok ) {
                    if( !korosztaly.eredmenyek.isEmpty( ) ) {
                        var korosztalyParagraph = document.InsertParagraph();
                        korosztalyParagraph.Append( "Íjtípus: " );
                        korosztalyParagraph.Append( ijtipus.megnevezes ).Bold( );
                        korosztalyParagraph.AppendLine( "    Korosztály: " );
                        korosztalyParagraph.Append( korosztaly.megnevezes ).Bold( );

                        if( !korosztaly.eredmenyek.nok.Count.Equals( 0 ) ) {
                            var nokParagraph = document.InsertParagraph();
                            nokParagraph.Append( "      Nők: " ).Bold( );

                            int helyezes = 0;
                            foreach( var eredmeny in korosztaly.eredmenyek.nok ) {
                                helyezes++;
                                table = document.AddTable( 1, 7 );
                                table.Rows[0].Cells[1].Paragraphs[0].Append( ( helyezes ) + "." );
                                table.Rows[0].Cells[2].Paragraphs[0].Append( eredmeny.Sorszam.ToString( ) );
                                table.Rows[0].Cells[3].Paragraphs[0].Append( eredmeny.Nev );
                                table.Rows[0].Cells[4].Paragraphs[0].Append( eredmeny.Egyesulet );
                                table.Rows[0].Cells[5].Paragraphs[0].Append( eredmeny.OsszPont.ToString( ) + " pont" );
                                table.Rows[0].Cells[6].Paragraphs[0].Append( eredmeny.Szazalek.ToString( ) + "%" );
                                EredmenyLapVersenyTeljesTablazatFormazas( table );
                                document.InsertTable( table );
                            }
                        }
                        if( !korosztaly.eredmenyek.ferfiak.Count.Equals( 0 ) ) {
                            var nokParagraph = document.InsertParagraph();
                            nokParagraph.Append( "      Férfiak: " ).Bold( );

                            int helyezes = 0;
                            foreach( var eredmeny in korosztaly.eredmenyek.ferfiak ) {
                                helyezes++;
                                table = document.AddTable( 1, 7 );
                                table.Rows[0].Cells[1].Paragraphs[0].Append( ( helyezes ) + "." );
                                table.Rows[0].Cells[2].Paragraphs[0].Append( eredmeny.Sorszam.ToString( ) );
                                table.Rows[0].Cells[3].Paragraphs[0].Append( eredmeny.Nev );
                                table.Rows[0].Cells[4].Paragraphs[0].Append( eredmeny.Egyesulet );
                                table.Rows[0].Cells[5].Paragraphs[0].Append( eredmeny.OsszPont.ToString( ) + " pont" );
                                table.Rows[0].Cells[6].Paragraphs[0].Append( eredmeny.Szazalek.ToString( ) + "%" );
                                EredmenyLapVersenyTeljesTablazatFormazas( table );
                                document.InsertTable( table );
                            }
                        }
                        if( !korosztaly.eredmenyek.egyben.Count.Equals( 0 ) ) {
                            var nokParagraph = document.InsertParagraph();
                            nokParagraph.Append( "      Egyben: " ).Bold( );

                            int helyezes = 0;
                            foreach( var eredmeny in korosztaly.eredmenyek.egyben ) {
                                helyezes++;
                                table = document.AddTable( 1, 7 );
                                table.Rows[0].Cells[1].Paragraphs[0].Append( ( helyezes ) + "." );
                                table.Rows[0].Cells[2].Paragraphs[0].Append( eredmeny.Sorszam.ToString( ) );
                                table.Rows[0].Cells[3].Paragraphs[0].Append( eredmeny.Nev );
                                table.Rows[0].Cells[4].Paragraphs[0].Append( eredmeny.Egyesulet );
                                table.Rows[0].Cells[5].Paragraphs[0].Append( eredmeny.OsszPont.ToString( ) + " pont" );
                                table.Rows[0].Cells[6].Paragraphs[0].Append( eredmeny.Szazalek.ToString( ) + "%" );
                                EredmenyLapVersenyTeljesTablazatFormazas( table );
                                document.InsertTable( table );
                            }
                        }
                    }
                }
            }
            try { document.Save( ); } catch( Exception ) {
                MessageBox.Show( "A dokumentum meg van nyitva!", "Verseny Teljes Eredménylap", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            return fileName;
        }
        public void Print( ) {
            Seged.Seged.Print( CreateDoc( ) );
        }
        public void Open( ) {
            Seged.Seged.Open( CreateDoc( ) );
        }

        private void AddHeader( Header header ) {
            var titleFormat = new Formatting();
            titleFormat.Size = 14D;
            titleFormat.Position = 1;
            titleFormat.Spacing = 5;
            titleFormat.Bold = true;

            var title = header.InsertParagraph();
            title.Append( Feliratok.HeadLineEredmenylap );
            title.AppendLine( Feliratok.EredmenyLapTeljes );
            title.Alignment = Alignment.center;

            titleFormat.Size = 10D;
            title.AppendLine( Feliratok.Tulajdonos );
            title.Bold( );
            titleFormat.Position = 12;
            title.AppendLine( );
        }
        private void EredmenylapVersenyTeljesHeaderTablazat( Header header ) {
            var table = document.AddTable(3, 2);
            table.Alignment = Alignment.left;
            table.Rows[0].Cells[0].Paragraphs[0].Append( Feliratok.VersenyMegnevezes );
            table.Rows[0].Cells[0].Paragraphs[0].Append( string.IsNullOrEmpty( versenyAdatok.Megnevezes ) ? versenyAdatok.Azonosito : versenyAdatok.Megnevezes ).Bold( );

            table.Rows[1].Cells[0].Paragraphs[0].Append( Feliratok.VersenyDatum );
            table.Rows[1].Cells[0].Paragraphs[0].Append( versenyAdatok.Datum ).Bold( );

            if( !string.IsNullOrEmpty( versenyAdatok.VersenysorozatAzonosito ) ) {
                table.Rows[2].Cells[0].Paragraphs[0].Append( Feliratok.VersenySorozat );
                table.Rows[2].Cells[0].Paragraphs[0].Append( string.IsNullOrEmpty( versenyAdatok.VersenysorozatMegnevezes ) ? versenyAdatok.VersenysorozatAzonosito : versenyAdatok.VersenysorozatMegnevezes ).Bold( );
            }

            table.Rows[0].Cells[1].Paragraphs[0].Append( Feliratok.OsszesPont );
            table.Rows[0].Cells[1].Paragraphs[0].Append( ( versenyAdatok.OsszesPont * 10 ).ToString( ) ).Bold( );

            table.Rows[1].Cells[1].Paragraphs[0].Append( Feliratok.VersenyIndulokSzama );
            table.Rows[1].Cells[1].Paragraphs[0].Append( versenyAdatok.IndulokSzama.ToString( ) ).Bold( );

            table.AutoFit = AutoFit.Contents;

            var b = new Border(Novacode.BorderStyle.Tcbs_none, BorderSize.seven, 0, Color.AliceBlue);
            table.SetBorder( TableBorderType.InsideH, b );
            table.SetBorder( TableBorderType.InsideV, b );
            table.SetBorder( TableBorderType.Bottom, b );
            table.SetBorder( TableBorderType.Top, b );
            table.SetBorder( TableBorderType.Left, b );
            table.SetBorder( TableBorderType.Right, b );
            header.InsertTable( table );
        }
        private static void EredmenyLapVersenyTeljesTablazatFormazas( Table table ) {
            table.AutoFit = AutoFit.Contents;
            table.AutoFit = AutoFit.ColumnWidth;
            foreach( Row row in table.Rows ) {
                row.Cells[0].Width = 30;
                row.Cells[1].Width = 50;
                row.Cells[2].Width = 50;
                row.Cells[3].Width = 200;
                row.Cells[4].Width = 200;
                row.Cells[5].Width = 70;
                row.Cells[6].Width = 70;
            }

            Border c = new Border(Novacode.BorderStyle.Tcbs_none, BorderSize.seven, 0, Color.Black);
            Border d = new Border(Novacode.BorderStyle.Tcbs_single, BorderSize.five, 0, Color.Black);
            table.SetBorder( TableBorderType.InsideH, d );
            table.SetBorder( TableBorderType.InsideV, c );
            table.SetBorder( TableBorderType.Bottom, c );
            table.SetBorder( TableBorderType.Top, c );
            table.SetBorder( TableBorderType.Left, c );
            table.SetBorder( TableBorderType.Right, c );

        }
    }
}
