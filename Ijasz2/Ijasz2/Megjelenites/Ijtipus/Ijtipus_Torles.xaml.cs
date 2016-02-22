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

namespace Ijasz2.Megjelenites.Ijtipus {
    /// <summary>
    /// Interaction logic for Ijtipus_Torles.xaml
    /// </summary>
    public partial class Ijtipus_Torles : Window {
        private readonly Model.Ijtipus.Ijtipus _ijtipus;

        public Ijtipus_Torles( Model.Ijtipus.Ijtipus ijtipus ) {
            InitializeComponent( );
            _ijtipus = ijtipus;
            lblKerdes.Content += Environment.NewLine + "Azonosító: " + _ijtipus.Azonosito;
        }

        private void BtnIgen_OnClick_OnClick(object sender, RoutedEventArgs e) {
            Model.Data.Data.Ijtipusok.Remove(_ijtipus);
            Close();
        }

        private void BtnNem_OnClickm_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
