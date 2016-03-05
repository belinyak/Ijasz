using System;
using System.Windows;
using Ijasz2.Model.Data;

namespace Ijasz2.Megjelenites.Ijtipus {
    /// <summary>
    ///     Interaction logic for Ijtipus_Torles.xaml
    /// </summary>
    public partial class Ijtipus_Torles {
        private readonly Model.Ijtipus.Ijtipus _ijtipus;

        public Ijtipus_Torles(Model.Ijtipus.Ijtipus ijtipus) {
            InitializeComponent();
            _ijtipus = ijtipus;
            lblKerdes.Content += Environment.NewLine + "Azonosító: " + _ijtipus.Azonosito;
        }

        private void BtnIgen_OnClick_OnClick(object sender, RoutedEventArgs e) {
            Data.Ijtipusok.Remove(_ijtipus);
            Close();
        }

        private void BtnNem_OnClickm_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}