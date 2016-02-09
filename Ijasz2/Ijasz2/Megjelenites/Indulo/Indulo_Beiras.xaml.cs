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
    /// Interaction logic for Indulo_Beiras.xaml
    /// </summary>
    public partial class Indulo_Beiras : Window {
        public Indulo_Beiras( ) {
            InitializeComponent( );
        }

        private void btnCsapatok_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Indulo.Indulo_Csapatok( ) ).ShowDialog( );
        }
    }
}
