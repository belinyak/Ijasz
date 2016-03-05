using System;
using System.Linq;
using System.Windows;
using Ijasz2.Model.Data;

namespace Ijasz2.Megjelenites.Eredmeny {
    /// <summary>
    ///     Interaction logic for Eredmeny_Torles.xaml
    /// </summary>
    public partial class Eredmeny_Torles {
        private readonly Model.Eredmeny.Eredmeny _eredmeny;

        public Eredmeny_Torles(Model.Eredmeny.Eredmeny eredmeny) {
            InitializeComponent();
            _eredmeny = eredmeny;
            lblKerdes.Content += Environment.NewLine + "Név: " + _eredmeny.Indulo;
        }

        private void BtnIgen_OnClick(object sender, RoutedEventArgs e) {
            foreach (var versenyEredmeny in Data.Eredmenyek._versenyEredmenyek.Where(versenyEredmeny => versenyEredmeny.VersenyAzonosito.Equals(_eredmeny.Verseny))) {
                versenyEredmeny.Eredmenyek.Remove(_eredmeny);
                Close();
                return;
            }
        }

        private void btnNem_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}