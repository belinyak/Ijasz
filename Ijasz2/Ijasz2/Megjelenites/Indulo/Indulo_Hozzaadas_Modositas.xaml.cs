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

namespace Ijasz2.Megjelenites.Indulo {
    /// <summary>
    /// Interaction logic for Indulo_Hozzaadas_Modositas.xaml
    /// </summary>
    public partial class Indulo_Hozzaadas_Modositas : Window {
        private readonly Model.Indulo.Indulo _indulo;
        #region Hozzaadas
        public Indulo_Hozzaadas_Modositas( ) {
            InitializeComponent( );
            InitializeContent( );
        }

        private void InitializeContent( ) {
            Title += " hozzáadás";
            cbEgyesulet.ItemsSource = Model.Data.Data.Egyesuletek._egyesuletek;
            txtEredmenyek.Text = "0";
            txtEredmenyek.IsEnabled = false;

        }
        #endregion

        #region Modositas
        public Indulo_Hozzaadas_Modositas( Model.Indulo.Indulo indulo ) {
            _indulo = indulo;
            InitializeComponent( );
            InitializeContent( _indulo );

        }

        private void InitializeContent( Model.Indulo.Indulo indulo ) {
            Title += " módosítás";
            txtNev.Text = indulo.Nev;
            txtNem.Text = indulo.Nem;

            txtNev.IsEnabled = false;
            txtEredmenyek.Text = indulo.Eredmenyek.ToString( );
            txtEredmenyek.IsEnabled = false;

            // TODO convert???
            dtSzuletes.Text = indulo.SzuletesiDatum;
            txtEngedely.Text = indulo.Engedely;
            cbEgyesulet.ItemsSource = Model.Data.Data.Egyesuletek._egyesuletek;
            cbEgyesulet.Text = indulo.Egyesulet;
            txtEredmenyek.IsEnabled = false;
        }

        private bool IsValid( ) {
            bool valid = true;

            dtSzuletes.ClearValue( Border.BorderBrushProperty );
            txtNev.ClearValue( Border.BorderBrushProperty );
            txtNem.ClearValue( Border.BorderBrushProperty );

            if( dtSzuletes.SelectedDate == null ) {
                dtSzuletes.BorderBrush = new SolidColorBrush( Colors.Red );
                valid = false;
            }
            else if( dtSzuletes.SelectedDate.Value.Year.Equals( DateTime.Now.Year ) ) {
                dtSzuletes.BorderBrush = new SolidColorBrush( Colors.Red );
                valid = false;
            }

            if( txtNev.Text.Length > 30 || txtNev.Text.Length <= 0 ) {
                txtNev.BorderBrush = new SolidColorBrush( Colors.Red );
                valid = false;
            }

            if( txtNem.Text != "n" && txtNem.Text != "N" && txtNem.Text != "f" && txtNem.Text != "F" ) {
                txtNem.BorderBrush = new SolidColorBrush( Colors.Red );
                valid = false;
            }
            return valid;
        }
        #endregion

        private void BtnRendben_OnClick( object sender, RoutedEventArgs e ) {
            if( IsValid( ) == false ) {
                return;
            }

            var Indulo = new Model.Indulo.Indulo {
                Nev = txtNev.Text,
                Nem = txtNem.Text,
                SzuletesiDatum = dtSzuletes.Text,
                Engedely = txtEngedely.Text,
                Egyesulet = cbEgyesulet.Text,
                Eredmenyek = Convert.ToInt32(txtEredmenyek.Text)
            };

            // modositas
            if( _indulo != null ) {
                Model.Data.Data.Indulok.Update( Indulo );
            }
            //hozzaadas
            else {
                Model.Data.Data.Indulok.Add( Indulo );
            }
            Close( );
        }

        private void btnUjEgyesulet_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Egyesület.Egyesulet_Hozzaadas_Modositas( ) ).ShowDialog( );
        }
    }
}
