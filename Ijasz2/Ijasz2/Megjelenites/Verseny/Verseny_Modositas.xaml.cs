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

namespace Ijasz2.Megjelenites.Verseny {
    /// <summary>
    /// Interaction logic for Verseny_Modositas.xaml
    /// </summary>
    public partial class Verseny_Modositas : Window {
        private Model.Verseny.Verseny _verseny;

        public Verseny_Modositas( Model.Verseny.Verseny verseny ) {
            _verseny = verseny;
            InitializeComponent( );
        }

        private void InitializeContent(Model.Verseny.Verseny verseny) {
        }

        private void BtnRendben_OnClick(object sender, RoutedEventArgs e) {
            throw new NotImplementedException();
        }
    }
}
