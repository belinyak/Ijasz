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
    /// Interaction logic for Korosztaly_Torles.xaml
    /// </summary>
    public partial class Korosztaly_Torles : Window {
        private readonly Model.Korosztaly.Korosztaly _korosztaly;


        public Korosztaly_Torles( Model.Korosztaly.Korosztaly korosztaly ) {
            InitializeComponent( );
            _korosztaly = korosztaly;
            lblKerdes.Content += Environment.NewLine + "Azonosító: " + _korosztaly.Azonosito;
        }

        private void BtnIgen_OnClick( object sender, RoutedEventArgs e ) {
            foreach( var versenyKorosztaly in Model.Data.Data.Korosztalyok._versenyKorosztalyok ) {
                if( versenyKorosztaly.VersenyAzonosito.Equals( _korosztaly.Verseny ) ) {
                    versenyKorosztaly.Korosztalyok.Remove( _korosztaly );
                    break;
                }
            }
            Close( );
        }

        private void btnNem_Click( object sender, RoutedEventArgs e ) {
            Close( );
        }
    }
}
