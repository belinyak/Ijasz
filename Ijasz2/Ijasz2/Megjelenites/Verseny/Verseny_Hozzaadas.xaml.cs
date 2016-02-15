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

namespace Ijasz2.Megjelenites.Verseny {
    /// <summary>
    /// Interaction logic for Verseny_Hozzaadas.xaml
    /// </summary>
    public partial class Verseny_Hozzaadas : Window {
        public Verseny_Hozzaadas( ) {
            InitializeComponent( );
            InitializeContent( );
        }

        private void InitializeContent( ) {
            dtDatum.SelectedDate = DateTime.Now;
            cbVersenysorozat.ItemsSource = Model.Data.Data.Versenysorozatok._versenysorozatok;
        }

        private bool IsValid( ) {
            try {
                dtDatum.SelectedDate.ToString( );
            } catch(Exception) {
                return false;
            }
            try {
                Convert.ToInt32( txtLovesek.Text );
            } catch(Exception) {
                return false;
            }
            try {
                Convert.ToInt32( txtAllomasok.Text );
            } catch(Exception) {
                return false;
            }
            return true;
        }

        private void BtnRendben_OnClick( object sender, RoutedEventArgs e ) {
            if( IsValid( ) == false ) {
                return;
            }

            var verseny = new Model.Verseny.Verseny {
                Azonosito = txtAzonosito.Text,
                Megnevezes = txtMegnevezes.Text,
                Datum = dtDatum.SelectedDate.ToString(),
                Versenysorozat = cbVersenysorozat.Text,
                Osszes = Convert.ToInt32(txtLovesek.Text),
                Allomasok = Convert.ToInt32(txtAllomasok.Text),
                DuplaBeirolap = chDupla.IsChecked != null && chDupla.IsChecked.Value
            };

            Model.Data.Data.Versenyek.Add( verseny );
            Close( );
        }
    }
}
