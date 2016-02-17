using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ijasz2.Megjelenites.Korosztaly {
    /// <summary>
    /// Interaction logic for Korosztaly_Hozzaadas_Modositas.xaml
    /// </summary>
    public partial class Korosztaly_Hozzaadas_Modositas : Window {
        private Model.Korosztaly.Korosztaly _korosztaly;

        #region Hozzaadas-Modositas

        public Korosztaly_Hozzaadas_Modositas( Model.Korosztaly.Korosztaly korosztaly ) {
            _korosztaly = korosztaly;
            InitializeComponent( );
            InitializeContent( korosztaly );
        }

        private void InitializeContent( Model.Korosztaly.Korosztaly korosztaly ) {
            if( korosztaly.Azonosito == null ) {
                Title += " hozzáadás";
            }
            else {
                Title += " módosítás";
                txtAzonosito.Text = korosztaly.Azonosito;
                txtAzonosito.IsEnabled = false;
                txtMegnevezes.Text = korosztaly.Megnevezes;
                txtAlso.Text = korosztaly.AlsoHatar.ToString( );
                txtFelso.Text = korosztaly.FelsoHatar.ToString( );
                chNok.IsChecked = korosztaly.Nokre;
                chFerfiak.IsChecked = korosztaly.Ferfiakra;
                chEgyben.IsChecked = korosztaly.Egyben;
            }
        }

        #endregion

        private bool IsValid( ) {
            bool valid = true;

            txtAzonosito.ClearValue( Border.BorderBrushProperty );
            txtAlso.ClearValue( Border.BorderBrushProperty );
            txtFelso.ClearValue( Border.BorderBrushProperty );

            if( txtAzonosito.Text.Length == 0 || txtAzonosito.Text.Length > 10 ) {
                txtAzonosito.BorderBrush = new SolidColorBrush( Colors.Red );
                valid = false;
            }

            int alsó = 0, felső = 0;
            try {
                alsó = Convert.ToInt32( txtAlso.Text );
            } catch {
                txtAlso.BorderBrush = new SolidColorBrush( Colors.Red );
                valid = false;
            }

            try {
                felső = Convert.ToInt32( txtFelso.Text );
            } catch {
                txtFelso.BorderBrush = new SolidColorBrush( Colors.Red );
                valid = false;
            }

            if( ( alsó <= 0 ) || ( felső <= alsó ) || ( 100 < felső ) ) {
                txtAlso.BorderBrush = new SolidColorBrush( Colors.Red );
                txtFelso.BorderBrush = new SolidColorBrush( Colors.Red );
                valid = false;
            }
            return valid;
        }

        private void BtnRendben_OnClick( object sender, RoutedEventArgs e ) {
            if( IsValid( ) == false ) {
                return;
            }

            var Korosztaly = new Model.Korosztaly.Korosztaly {
                Azonosito = txtAzonosito.Text,
                Megnevezes = txtMegnevezes.Text,
                AlsoHatar = Convert.ToInt32(txtAlso.Text),
                FelsoHatar = Convert.ToInt32(txtFelso.Text),
                Nokre = chNok.IsChecked == true,
                Ferfiakra = chFerfiak.IsChecked == true,
                Egyben = chEgyben.IsChecked == true,
                InduloFerfiak = 0,
                InduloNok = 0,
                Verseny = _korosztaly.Verseny
            };

            // hozzaadas
            if( _korosztaly.Azonosito == null ) {
                foreach( var versenyKorosztaly in Model.Data.Data.Korosztalyok._versenyKorosztalyok ) {
                    if( versenyKorosztaly.VersenyAzonosito.Equals( Korosztaly.Verseny ) ) {
                        versenyKorosztaly.Korosztalyok.Add( Korosztaly );
                    }
                }
            }
            // modositas
            else {
                foreach( var versenyKorosztaly in Model.Data.Data.Korosztalyok._versenyKorosztalyok ) {
                    if( versenyKorosztaly.VersenyAzonosito.Equals( Korosztaly.Verseny ) ) {
                        foreach( var korosztaly in versenyKorosztaly.Korosztalyok ) {
                            if( korosztaly.Azonosito.Equals( Korosztaly.Azonosito ) ) {
                                korosztaly.Megnevezes = Korosztaly.Megnevezes;
                                korosztaly.AlsoHatar = Korosztaly.AlsoHatar;
                                korosztaly.FelsoHatar = Korosztaly.FelsoHatar;
                                korosztaly.Nokre = Korosztaly.Nokre;
                                korosztaly.Ferfiakra = Korosztaly.Ferfiakra;
                                korosztaly.InduloNok = Korosztaly.InduloNok;
                                korosztaly.InduloFerfiak = Korosztaly.InduloFerfiak;
                                korosztaly.Egyben = Korosztaly.Egyben;
                            }
                        }
                    }
                }
            }
            Close( );
        }
    }
}
