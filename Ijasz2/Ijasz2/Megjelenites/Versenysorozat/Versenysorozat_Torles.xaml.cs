using System;
using System.Windows;
using Ijasz2.Model.Data;

namespace Ijasz2.Megjelenites.Versenysorozat {
    /// <summary>
    ///     Interaction logic for Versenysorozat_Torles.xaml
    /// </summary>
    public partial class Versenysorozat_Torles {
        private readonly string _azonosito;

        public Versenysorozat_Torles(string azonosito) {
            InitializeComponent();
            _azonosito = azonosito;
            lblKerdes.Content += Environment.NewLine + "Azonosító: " + _azonosito;
        }

        private void BtnNem_OnClick(object sender, RoutedEventArgs e) {
            Close();
        }

        private void BtnIgen_OnClick(object sender, RoutedEventArgs e) {
            Data.Versenysorozatok.Remove(_azonosito);
            Close();
        }
    }
}