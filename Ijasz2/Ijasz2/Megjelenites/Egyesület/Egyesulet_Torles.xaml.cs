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

namespace Ijasz2.Megjelenites.Egyesület {
    /// <summary>
    /// Interaction logic for Egyesulet_Torles.xaml
    /// </summary>
    public partial class Egyesulet_Torles : Window {
        private readonly Model.Egyesulet.Egyesulet _egyesulet;
        public Egyesulet_Torles( Model.Egyesulet.Egyesulet egyesulet ) {
            InitializeComponent( );
            _egyesulet = egyesulet;
            lblKerdes.Content += Environment.NewLine + "Azonosító: " + _egyesulet.Azonosito;
        }

        private void BtnIgen_OnClick(object sender, RoutedEventArgs e) {
            Model.Data.Data.Egyesuletek.Remove( _egyesulet );
            Close();
        }

        private void btnNem_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
