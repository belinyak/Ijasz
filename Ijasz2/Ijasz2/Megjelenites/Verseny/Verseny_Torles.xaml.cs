using System;
using System.Windows;
using Ijasz2.Model.Data;

namespace Ijasz2.Megjelenites.Verseny {
    /// <summary>
    ///     Interaction logic for Verseny_Torles.xaml
    /// </summary>
    public partial class Verseny_Torles {
        private readonly string _azonosito;

        public Verseny_Torles(string azonosito) {
            InitializeComponent();
            _azonosito = azonosito;
            lblKerdes.Content += Environment.NewLine + "Azonosító: " + _azonosito;
        }

        private void BtnIgen_OnClick(object sender, RoutedEventArgs e) {
            Data.Versenyek.Remove(_azonosito);
            Close();
        }

        private void btnNem_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}