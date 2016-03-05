using System;
using System.Linq;
using System.Windows;
using Ijasz2.Model.Data;

namespace Ijasz2.Megjelenites.Korosztaly {
    /// <summary>
    ///     Interaction logic for Korosztaly_Torles.xaml
    /// </summary>
    public partial class Korosztaly_Torles{
        private readonly Model.Korosztaly.Korosztaly _korosztaly;

        public Korosztaly_Torles(Model.Korosztaly.Korosztaly korosztaly) {
            InitializeComponent();
            _korosztaly = korosztaly;
            lblKerdes.Content += Environment.NewLine + "Azonosító: " + _korosztaly.Azonosito;
        }

        private void BtnIgen_OnClick(object sender, RoutedEventArgs e) {
            foreach (var versenyKorosztaly in Data.Korosztalyok._versenyKorosztalyok.Where(versenyKorosztaly => versenyKorosztaly.VersenyAzonosito.Equals(_korosztaly.Verseny))) {
                versenyKorosztaly.Korosztalyok.Remove(_korosztaly);
                Adatbazis.Korosztaly.Korosztaly.Remove(_korosztaly);
                break;
            }
            Close();
        }

        private void btnNem_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}