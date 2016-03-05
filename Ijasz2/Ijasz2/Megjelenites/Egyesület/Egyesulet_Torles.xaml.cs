using System;
using System.Windows;
using Ijasz2.Model.Data;
using Ijasz2.Model.Egyesulet;

namespace Ijasz2.Megjelenites.Egyesület {
    /// <summary>
    ///     Interaction logic for Egyesulet_Torles.xaml
    /// </summary>
    public partial class Egyesulet_Torles {
        private readonly Egyesulet _egyesulet;

        public Egyesulet_Torles(Egyesulet egyesulet) {
            InitializeComponent();
            _egyesulet = egyesulet;
            lblKerdes.Content += Environment.NewLine + "Azonosító: " + _egyesulet.Azonosito;
        }

        private void BtnIgen_OnClick(object sender, RoutedEventArgs e) {
            Data.Egyesuletek.Remove(_egyesulet);
            Close();
        }

        private void btnNem_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}