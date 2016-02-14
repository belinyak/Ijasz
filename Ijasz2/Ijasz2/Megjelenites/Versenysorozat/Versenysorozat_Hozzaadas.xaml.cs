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
    /// Interaction logic for Versenysorozat_Hozzaadas.xaml
    /// </summary>
    public partial class Versenysorozat_Hozzaadas : Window {
        public Versenysorozat_Hozzaadas( ) {
            InitializeComponent( );
        }

        private void BtnRendben_OnClick(object sender, RoutedEventArgs e) {
            var versenysorozat = new Model.Versenysorozat.Versenysorozat {
                Azonosito = txtAzonosito.Text,
                Megnevezes = txtMegnevezes.Text,
                VersenyekSzama = 0
            };
            Model.Data.Data.Versenysorozatok.Add(versenysorozat);
            Close();
        }
    }
}
