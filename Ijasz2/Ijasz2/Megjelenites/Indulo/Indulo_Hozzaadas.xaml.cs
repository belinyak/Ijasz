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
    /// Interaction logic for Indulo_Hozzaadas.xaml
    /// </summary>
    public partial class Indulo_Hozzaadas : Window {
        public Indulo_Hozzaadas( ) {
            InitializeComponent( );
        }

        private void btnUjEgyesulet_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Egyesület.Egyesulet_Hozzaadas_Modositas( ) ).ShowDialog( );
        }
    }
}
