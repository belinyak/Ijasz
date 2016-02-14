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
    /// Interaction logic for Versenysorozat_Modositas.xaml
    /// </summary>
    public partial class Versenysorozat_Modositas : Window {
        private Model.Versenysorozat.Versenysorozat _versenysorozat;

        public Versenysorozat_Modositas( Model.Versenysorozat.Versenysorozat versenysorozat ) {
            InitializeComponent( );
            InitializeContent( versenysorozat );
        }

        private void InitializeContent( Model.Versenysorozat.Versenysorozat versenysorozat ) {
            _versenysorozat = versenysorozat;
            txtAzonosito.Text = _versenysorozat.Azonosito;
            txtMegnevezes.Text = _versenysorozat.Megnevezes;
        }
        /// <summary>
        /// nincs modositas akkor return, különben modify
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRendben_OnClick( object sender, RoutedEventArgs e ) {
            if( txtMegnevezes.Text.Equals( _versenysorozat.Megnevezes ) ) {
                Close();
                return;
            }

            Model.Data.Data.Versenysorozatok.Modify( new Model.Versenysorozat.Versenysorozat {
                Azonosito = txtAzonosito.Text,
                Megnevezes = txtMegnevezes.Text,
                VersenyekSzama = _versenysorozat.VersenyekSzama
            } );
            Close( );
        }
    }
}
