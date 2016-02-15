using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Verseny_Modositas.xaml
    /// </summary>
    public partial class Verseny_Modositas : Window {
        private Model.Verseny.Verseny _verseny;

        public Verseny_Modositas( Model.Verseny.Verseny verseny ) {
            _verseny = verseny;
            InitializeComponent( );
            InitializeContent(_verseny);
        }

        private void InitializeContent( Model.Verseny.Verseny verseny ) {
            txtAzonosito.Text = _verseny.Azonosito;
            txtMegnevezes.Text = _verseny.Megnevezes;
            cbVersenysorozat.ItemsSource = Model.Data.Data.Versenysorozatok._versenysorozatok;

            try {
                dtDatum.SelectedDate = DateTime.Parse( _verseny.Datum );
            } catch( Exception e ) {
                // ignored
            }

            if( _verseny.Versenysorozat != null ) {
                cbVersenysorozat.Text = _verseny.Versenysorozat;
            }

            txtLovesek.Text = _verseny.Osszes.ToString();
            txtAllomasok.Text = _verseny.Allomasok.ToString();
            chDupla.IsChecked = _verseny.DuplaBeirolap;
        }

        private void BtnRendben_OnClick( object sender, RoutedEventArgs e ) {

            var verseny = new Model.Verseny.Verseny {
                Azonosito = txtAzonosito.Text,
                Megnevezes = txtMegnevezes.Text,
                Datum = dtDatum.SelectedDate.ToString(),
                Versenysorozat = cbVersenysorozat.Text,
                Osszes = Convert.ToInt32(txtLovesek.Text),
                Allomasok = Convert.ToInt32(txtAllomasok.Text),
                DuplaBeirolap = chDupla.IsChecked != null && chDupla.IsChecked.Value
            };

            Model.Data.Data.Versenyek.Modify(verseny);

            Close( );
        }
    }
}
