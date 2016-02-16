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
        private readonly string _verseny;
        private readonly string _azonosito;

        public Korosztaly_Torles(string verseny, string azonosito ) {
            InitializeComponent( );
            _verseny = verseny;
            _azonosito = azonosito;
            lblKerdes.Content += Environment.NewLine + "Azonosító: " + _azonosito;
        }

        private void BtnIgen_OnClick(object sender, RoutedEventArgs e) {
            Model.Data.Data.Korosztalyok.Remove(_verseny, _azonosito);
            Close();
        }

        private void btnNem_Click(object sender, RoutedEventArgs e) {
            Close( );
        }
    }
}
