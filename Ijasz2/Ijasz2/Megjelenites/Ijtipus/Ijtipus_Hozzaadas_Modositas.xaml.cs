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

namespace Ijasz2.Megjelenites.Ijtipus {
    /// <summary>
    /// Interaction logic for Ijtipus_Hozzaadas_Modositas.xaml
    /// </summary>
    public partial class Ijtipus_Hozzaadas_Modositas : Window {
        private readonly Model.Ijtipus.Ijtipus _ijtipus;

        #region Hozzaadas
        public Ijtipus_Hozzaadas_Modositas( ) {
            InitializeComponent( );
            InitializeContent( );
        }

        private void InitializeContent( ) {
            Title += " hozzáadás";
        }
        #endregion

        #region Modositas
        public Ijtipus_Hozzaadas_Modositas( Model.Ijtipus.Ijtipus ijtipus ) {
            _ijtipus = ijtipus;
            InitializeComponent( );
            InitializeContent( _ijtipus );
        }

        private void InitializeContent( Model.Ijtipus.Ijtipus ijtipus ) {
            Title += " módosítás";
            txtAzonosito.Text = ijtipus.Azonosito;
            txtAzonosito.IsEnabled = false;
            txtMegnevezes.Text = ijtipus.Megnevezes;
            txtListazas.Text = ijtipus.Sorszam.ToString( );
        }

        private bool IsValid( ) {
            bool valid = true;
            txtAzonosito.ClearValue( Border.BorderBrushProperty );
            txtListazas.ClearValue( Border.BorderBrushProperty );

            if( txtAzonosito.Text.Length == 0 ) {
                txtAzonosito.BorderBrush = new SolidColorBrush( Colors.Red );
                valid = false;
            }

            try {
                Convert.ToInt32( txtListazas.Text );
            } catch {
                txtListazas.BorderBrush = new SolidColorBrush( Colors.Red );
                valid = false;
            }

            return valid;
        }
        #endregion

        private void BtnRendben_OnClick( object sender, RoutedEventArgs e ) {
            if (IsValid() == false) {
                return;
            }

            var Ijtipus = new Model.Ijtipus.Ijtipus {
                Azonosito = txtAzonosito.Text,
                Megnevezes = txtMegnevezes.Text,
                Sorszam = Convert.ToInt32(txtListazas.Text),
                Eredmenyek = 0
            };
            // hozzaadas
            if( _ijtipus == null ) {
                Model.Data.Data.Ijtipusok.Add( Ijtipus );
            }
            // modositas
            else {
                Ijtipus.Eredmenyek = _ijtipus.Eredmenyek;
                Model.Data.Data.Ijtipusok.Update(Ijtipus);
            }
            Close();
        }
    }
}
