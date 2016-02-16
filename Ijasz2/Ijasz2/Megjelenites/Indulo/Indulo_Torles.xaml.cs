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
    /// Interaction logic for Indulo_Torles.xaml
    /// </summary>
    public partial class Indulo_Torles : Window {
        private readonly Model.Indulo.Indulo _indulo;
        public Indulo_Torles( Model.Indulo.Indulo indulo ) {
            InitializeComponent( );
            _indulo = indulo;
            lblKerdes.Content += Environment.NewLine + "Név: " + _indulo.Nev;
        }

        private void BtnIgen_OnClick(object sender, RoutedEventArgs e) {
            Model.Data.Data.Indulok.Remove(_indulo);
            Close();
        }

        private void btnNem_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
