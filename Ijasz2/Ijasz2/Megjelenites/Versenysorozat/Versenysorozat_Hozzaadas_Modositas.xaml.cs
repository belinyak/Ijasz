using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Ijasz2.Model.Data;

namespace Ijasz2.Megjelenites.Versenysorozat {
    /// <summary>
    ///     Interaction logic for Versenysorozat_Hozzaadas_Modositas.xaml
    /// </summary>
    public partial class Versenysorozat_Hozzaadas_Modositas {
        private Model.Versenysorozat.Versenysorozat _versenysorozat;

        private bool IsValid( ) {
            var valid = true;
            txtAzonosito.ClearValue( Border.BorderBrushProperty );
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

            var versenysorozat = new Model.Versenysorozat.Versenysorozat {
                Azonosito = txtAzonosito.Text,
                Megnevezes = txtMegnevezes.Text,
                VersenyekSzama = 0
            };

            // hozzaadas
            if( _versenysorozat == null ) {
                Data.Versenysorozatok.Add( versenysorozat );
            }
            // modositas
            else {
                Data.Versenysorozatok.Update( versenysorozat );
            }
            Close( );
        }

        #region Hozzaadas

        public Versenysorozat_Hozzaadas_Modositas( ) {
            InitializeComponent( );
            InitializeContent( );
        }

        private void InitializeContent( ) {
            Title += " hozzáadás";
        }

        #endregion

        #region Modositas

        public Versenysorozat_Hozzaadas_Modositas( Model.Versenysorozat.Versenysorozat versenysorozat ) {
            _versenysorozat = versenysorozat;
            InitializeComponent( );
            InitializeContent( _versenysorozat );
        }

        private void InitializeContent( Model.Versenysorozat.Versenysorozat versenysorozat ) {
            Title += " módosítás";
            _versenysorozat = versenysorozat;
            txtAzonosito.Text = _versenysorozat.Azonosito;
            txtMegnevezes.Text = _versenysorozat.Megnevezes;
            txtAzonosito.IsEnabled = false;
        }

        #endregion
    }
}