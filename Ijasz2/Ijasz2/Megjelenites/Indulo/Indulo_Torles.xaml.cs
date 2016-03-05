using System;
using System.Windows;
using Ijasz2.Model.Data;

namespace Ijasz2.Megjelenites.Indulo {
    /// <summary>
    ///     Interaction logic for Indulo_Torles.xaml
    /// </summary>
    public partial class Indulo_Torles {
        private readonly Model.Indulo.Indulo _indulo;

        public Indulo_Torles(Model.Indulo.Indulo indulo) {
            InitializeComponent();
            _indulo = indulo;
            lblKerdes.Content += Environment.NewLine + "Név: " + _indulo.Nev;
        }

        private void BtnIgen_OnClick(object sender, RoutedEventArgs e) {
            Data.Indulok.Remove(_indulo);
            Close();
        }

        private void btnNem_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}