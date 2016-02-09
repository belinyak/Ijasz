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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ijasz2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow( ) {
            InitializeComponent( );
        }
        
        private void btnVersenysorozatHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Versenysorozat.Versenysorozat_Hozzaadas( ) ).ShowDialog( );
        }

        private void btnVersenyHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Verseny.Verseny_Hozzaadas( ) ).ShowDialog( );
        }

        private void btnKorosztalyHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Korosztaly.Korosztaly_Hozzaadas( ) ).ShowDialog( );
        }

        private void btnKorosztalyIndulok_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Korosztaly.Korosztaly_Indulok( ) ).ShowDialog( );
        }

        private void btnIjtipusHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Ijtipusok.Ijtipus_Hozzaadas( ) ).ShowDialog( );
        }

        private void btnKorosztalyTorles_Click( object sender, RoutedEventArgs e ) {

        }

        private void btnKorosztalySzamolas_Click( object sender, RoutedEventArgs e ) {

        }

        private void btnEgyesuletTorles_Click( object sender, RoutedEventArgs e ) {

        }

        private void btnEgyesuletHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Egyesület.Egyesulet_Hozzaadas( ) ).ShowDialog( );
        }

        private void btnEgyesuletHozzaadas_Click_1( object sender, RoutedEventArgs e ) {

        }

        private void btnInduloHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Indulo.Indulo_Hozzaadas( ) ).ShowDialog( );
        }

        private void btnInduloTorles_Click( object sender, RoutedEventArgs e ) {

        }

        private void btnInduloBeiras_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Indulo.Indulo_Beiras( ) ).ShowDialog( );
        }

        private void btnEredmenyLezaras_Click( object sender, RoutedEventArgs e ) {

        }

        private void btnEredmenyMegnyitas_Click( object sender, RoutedEventArgs e ) {
            //NOTE(mate): ideiglenesen
            ( new Megjelenites.Eredmeny.Eredmeny_Hozzaadas( ) ).ShowDialog( );
        }

        private void btnEredmenyTorles_Click( object sender, RoutedEventArgs e ) {

        }
    }
}
