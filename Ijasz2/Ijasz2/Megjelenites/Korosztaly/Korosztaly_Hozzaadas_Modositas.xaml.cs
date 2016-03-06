using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Ijasz2.Model.Data;

namespace Ijasz2.Megjelenites.Korosztaly {
    /// <summary>
    ///     Interaction logic for Korosztaly_Hozzaadas_Modositas.xaml
    /// </summary>
    public partial class Korosztaly_Hozzaadas_Modositas {
        private readonly Model.Korosztaly.Korosztaly _korosztaly;

        private bool IsValid() {
            var valid = true;

            txtAzonosito.ClearValue(Border.BorderBrushProperty);
            txtAlso.ClearValue(Border.BorderBrushProperty);
            txtFelso.ClearValue(Border.BorderBrushProperty);

            if (txtAzonosito.Text.Length == 0 || txtAzonosito.Text.Length > 10) {
                txtAzonosito.BorderBrush = new SolidColorBrush(Colors.Red);
                valid = false;
            }

            int alsó = 0, felső = 0;
            try {
                alsó = Convert.ToInt32(txtAlso.Text);
            }
            catch {
                txtAlso.BorderBrush = new SolidColorBrush(Colors.Red);
                valid = false;
            }

            try {
                felső = Convert.ToInt32(txtFelso.Text);
            }
            catch {
                txtFelso.BorderBrush = new SolidColorBrush(Colors.Red);
                valid = false;
            }

            if ((alsó <= 0) || (felső <= alsó) || (100 < felső)) {
                txtAlso.BorderBrush = new SolidColorBrush(Colors.Red);
                txtFelso.BorderBrush = new SolidColorBrush(Colors.Red);
                valid = false;
            }
            return valid;
        }

        private void BtnRendben_OnClick(object sender, RoutedEventArgs e) {
            if (IsValid() == false) {
                return;
            }

            var Korosztaly = new Model.Korosztaly.Korosztaly {
                Azonosito = txtAzonosito.Text,
                Megnevezes = txtMegnevezes.Text,
                AlsoHatar = Convert.ToInt32(txtAlso.Text),
                FelsoHatar = Convert.ToInt32(txtFelso.Text),
                Nokre = chNok.IsChecked == true,
                Ferfiakra = chFerfiak.IsChecked == true,
                Egyben = chEgyben.IsChecked == true,
                InduloFerfiak = 0,
                InduloNok = 0,
                Verseny = _korosztaly.Verseny
            };

            // hozzaadas
            //TODO ki kell szedni a list<korosztalyt> korosztalyokba és oda rakni a remove/move 
            if (_korosztaly.Azonosito == null) {
                foreach (var versenyKorosztaly in Data.Korosztalyok._versenyKorosztalyok.Where(versenyKorosztaly => versenyKorosztaly.VersenyAzonosito.Equals(Korosztaly.Verseny))) {
                    versenyKorosztaly.Add(Korosztaly);
                    break;
                }
            }
            // modositas TODO szar helyen van !!
            //TODO ki kell szedni a list<korosztalyt> korosztalyokba és oda rakni a remove/move 
            else {
                Data.Korosztalyok.Update(Korosztaly);
            }
            Close();
        }

        #region Hozzaadas-Modositas

        public Korosztaly_Hozzaadas_Modositas(Model.Korosztaly.Korosztaly korosztaly) {
            _korosztaly = korosztaly;
            InitializeComponent();
            InitializeContent(korosztaly);
        }

        private void InitializeContent(Model.Korosztaly.Korosztaly korosztaly) {
            if (korosztaly.Azonosito == null) {
                Title += " hozzáadás";
            }
            else {
                Title += " módosítás";
                txtAzonosito.Text = korosztaly.Azonosito;
                txtAzonosito.IsEnabled = false;
                txtMegnevezes.Text = korosztaly.Megnevezes;
                txtAlso.Text = korosztaly.AlsoHatar.ToString();
                txtFelso.Text = korosztaly.FelsoHatar.ToString();
                chNok.IsChecked = korosztaly.Nokre;
                chFerfiak.IsChecked = korosztaly.Ferfiakra;
                chEgyben.IsChecked = korosztaly.Egyben;
            }
        }

        #endregion
    }
}