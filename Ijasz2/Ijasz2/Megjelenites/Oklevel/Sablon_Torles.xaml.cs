using System;
using System.Windows;
using Ijasz2.Model.Data;

namespace Ijasz2.Megjelenites.Oklevel {
    /// <summary>
    ///     Interaction logic for Sablon_Torles.xaml
    /// </summary>
    public partial class Sablon_Torles {
        private readonly string _azonosito;

        public Sablon_Torles(string azonosito) {
            InitializeComponent();
            _azonosito = azonosito;
            lblKerdes.Content += Environment.NewLine + "Azonosító: " + _azonosito;
        }

        private void BtnIgen_OnClick(object sender, RoutedEventArgs e) {
            Data.Sablonok.Remove(_azonosito);
            Close();
        }

        private void btnNem_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}