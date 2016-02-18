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

namespace Ijasz2.Megjelenites.Oklevel {
    /// <summary>
    /// Interaction logic for Sablon_Torles.xaml
    /// </summary>
    public partial class Sablon_Torles : Window {
        private readonly string _azonosito;
        public Sablon_Torles( string azonosito ) {
            InitializeComponent( );
            _azonosito = azonosito;
            lblKerdes.Content += Environment.NewLine + "Azonosító: " + _azonosito;
        }

        private void BtnIgen_OnClick(object sender, RoutedEventArgs e) {
            Model.Data.Data.Sablonok.Remove(_azonosito);
            Close();
        }

        private void btnNem_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
