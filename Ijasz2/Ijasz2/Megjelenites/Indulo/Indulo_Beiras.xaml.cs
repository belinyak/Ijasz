using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Ijasz2.Model.Data;

namespace Ijasz2.Megjelenites.Indulo {
    /// <summary>
    ///     Interaction logic for Indulo_Beiras.xaml
    /// </summary>
    public partial class Indulo_Beiras  {
        private readonly Model.Indulo.Indulo _indulo;

        public Indulo_Beiras(Model.Indulo.Indulo indulo) {
            _indulo = indulo;
            InitializeComponent();
            InitializeContent(_indulo);
        }

        private void InitializeContent(Model.Indulo.Indulo indulo) {
            var Csapatok = new ObservableCollection<int>();
            for (var i = 1; i < 46; i++) {
                Csapatok.Add(i);
            }
            cbCsapat.ItemsSource = Csapatok;

            cbIjtipus.ItemsSource = Data.Ijtipusok._ijtipusok;
            cbVerseny.ItemsSource = Data.Versenyek._versenyek;

            cbUjKorosztaly.IsEnabled = false;

            txtNev.Text = indulo.Nev;
            txtNev.IsEnabled = false;
        }

        private void btnCsapatok_Click(object sender, RoutedEventArgs e) {
            (new Indulo_Csapatok()).ShowDialog();
        }

        private void ChKorosztalyFelulir_OnClick(object sender, RoutedEventArgs e) {
            if (cbVerseny.SelectedItem == null) {
                return;
            }

            cbUjKorosztaly.IsEnabled = !(cbUjKorosztaly.IsEnabled);
        }

        private void CbVerseny_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cbVerseny.SelectedItem != null) {
                var currentVerseny = cbVerseny.SelectedItem as Model.Verseny.Verseny;
                cbUjKorosztaly.ItemsSource = null;
                foreach (var versenyKorosztaly in Data.Korosztalyok._versenyKorosztalyok.Where(versenyKorosztaly => currentVerseny != null && versenyKorosztaly.VersenyAzonosito.Equals(currentVerseny.Azonosito))) {
                    cbUjKorosztaly.ItemsSource = versenyKorosztaly.Korosztalyok;
                    return;
                }
            }
        }

        private bool IsValid() {
            var valid = true;

            cbVerseny.ClearValue(Border.BorderBrushProperty);
            cbIjtipus.ClearValue(Border.BorderBrushProperty);
            cbCsapat.ClearValue(Border.BorderBrushProperty);
            chKorosztalyFelulir.ClearValue(Border.BorderBrushProperty);
            cbUjKorosztaly.ClearValue(Border.BorderBrushProperty);

            if (cbVerseny.SelectedItem == null) {
                cbVerseny.Background = new SolidColorBrush(Colors.Red);
                valid = false;
            }

            if (cbIjtipus.SelectedItem == null) {
                cbIjtipus.Background = new SolidColorBrush(Colors.Red);
                valid = false;
            }

            if (cbCsapat.SelectedItem == null) {
                cbCsapat.Background = new SolidColorBrush(Colors.Red);
                valid = false;
            }

            if ((chKorosztalyFelulir.IsChecked == true) &&
                (cbUjKorosztaly.Text == "")) {
                cbUjKorosztaly.Background = new SolidColorBrush(Colors.Red);
                chKorosztalyFelulir.Background = new SolidColorBrush(Colors.Red);
                valid = false;
            }

            return valid;
        }

        /// <summary>
        ///     |
        ///     induló beírása |
        ///     TODO korosztaly szamolas |
        ///     TODO eredmenyek novelese |
        ///     TODO SZEBBEN, ha mar letezik akkor modositas nem add |
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRendben_OnClick(object sender, RoutedEventArgs e) {
            if (IsValid() == false) {
                return;
            }

            foreach (var versenyEredmeny in Data.Eredmenyek._versenyEredmenyek) {
                if (versenyEredmeny.VersenyAzonosito.Equals(cbVerseny.Text)) {
                    foreach (
                        var eredmeny in
                            versenyEredmeny.Eredmenyek._eredmenyek.Where(eredmeny => eredmeny.Indulo.Equals(_indulo.Nev))
                        ) {
                        versenyEredmeny.Eredmenyek.Remove(eredmeny);
                        versenyEredmeny.Eredmenyek.Add(new Model.Eredmeny.Eredmeny {
                            Verseny = versenyEredmeny.VersenyAzonosito,
                            Indulo = _indulo.Nev,
                            Ijtipus = cbIjtipus.Text,
                            Csapat = Convert.ToInt32(cbCsapat.Text),
                            Talalat10 = 0,
                            Talalat8 = 0,
                            Talalat5 = 0,
                            Melle = 0,
                            OsszPont = 0,
                            Szazalek = 0,
                            Megjelent = chMegjelent.IsChecked == true,
                            KorosztalyAzonosito = chKorosztalyFelulir.IsChecked == true ? cbUjKorosztaly.Text : ""
                        });
                        Close();
                        return;
                    }
                }
            }

            foreach (var versenyEredmeny in Data.Eredmenyek._versenyEredmenyek.Where(versenyEredmeny => versenyEredmeny.VersenyAzonosito.Equals(cbVerseny.Text))) {
                versenyEredmeny.Eredmenyek.Add(new Model.Eredmeny.Eredmeny {
                    Verseny = versenyEredmeny.VersenyAzonosito,
                    Indulo = _indulo.Nev,
                    Ijtipus = cbIjtipus.Text,
                    Csapat = Convert.ToInt32(cbCsapat.Text),
                    Talalat10 = 0,
                    Talalat8 = 0,
                    Talalat5 = 0,
                    Melle = 0,
                    OsszPont = 0,
                    Szazalek = 0,
                    Megjelent = chMegjelent.IsChecked == true,
                    KorosztalyAzonosito = chKorosztalyFelulir.IsChecked == true ? cbUjKorosztaly.Text : ""
                });
                Close();
                return;
            }
        }
    }
}