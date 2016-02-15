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

namespace Ijasz2.Megjelenites.Versenysorozat {
    /// <summary>
    /// Interaction logic for Versenysorozat_Hozzaadas_Modositas.xaml
    /// </summary>
    public partial class Versenysorozat_Hozzaadas_Modositas : Window {
        private Model.Versenysorozat.Versenysorozat _versenysorozat;

        #region Hozzaadas
        public Versenysorozat_Hozzaadas_Modositas( ) {
            InitializeComponent( );
            InitializeContent( );
        }

        private void InitializeContent( ) {
        }
        #endregion

        #region Modositas
        public Versenysorozat_Hozzaadas_Modositas( Model.Versenysorozat.Versenysorozat versenysorozat ) {
            _versenysorozat = versenysorozat;
            InitializeComponent( );
            InitializeContent( _versenysorozat );
        }

        private void InitializeContent( Model.Versenysorozat.Versenysorozat versenysorozat ) {
            _versenysorozat = versenysorozat;
            txtAzonosito.Text = _versenysorozat.Azonosito;
            txtMegnevezes.Text = _versenysorozat.Megnevezes;
            txtAzonosito.IsEnabled = false;
        }
        #endregion

        private bool IsValid( ) {
            bool valid = true;
            if( txtAzonosito.Text.Length == 0 ) {
                txtAzonosito.BorderBrush = new SolidColorBrush( Colors.Red );
                valid = false;
            }
            return valid;
        }

        private void BtnRendben_OnClick( object sender, RoutedEventArgs e ) {
            if( IsValid( ) == false ) {
                return;
            }

            // hozzaadas
            if( _versenysorozat == null ) {
                var versenysorozat = new Model.Versenysorozat.Versenysorozat {
                    Azonosito = txtAzonosito.Text,
                    Megnevezes = txtMegnevezes.Text,
                    VersenyekSzama = 0
                };
                Model.Data.Data.Versenysorozatok.Add( versenysorozat );
            }
            // modositas
            else {
                Model.Data.Data.Versenysorozatok.Modify( new Model.Versenysorozat.Versenysorozat {
                    Azonosito = txtAzonosito.Text,
                    Megnevezes = txtMegnevezes.Text,
                    VersenyekSzama = _versenysorozat.VersenyekSzama
                } );
            }
            Close( );
        }
    }
}
