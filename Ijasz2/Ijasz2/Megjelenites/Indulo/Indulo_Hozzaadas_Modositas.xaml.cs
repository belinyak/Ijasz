using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Ijasz2.Megjelenites.Egyesület;
using Ijasz2.Model.Data;

namespace Ijasz2.Megjelenites.Indulo {
    /// <summary>
    ///     Interaction logic for Indulo_Hozzaadas_Modositas.xaml
    /// </summary>
    public partial class Indulo_Hozzaadas_Modositas {
        private readonly Model.Indulo.Indulo _indulo;

        private void BtnRendben_OnClick(object sender, RoutedEventArgs e) {
            if (IsValid() == false) {
                return;
            }

            var Indulo = new Model.Indulo.Indulo {
                Nev = txtNev.Text,
                Nem = txtNem.Text,
                SzuletesiDatum = dtSzuletes.Text,
                Engedely = txtEngedely.Text,
                Egyesulet = cbEgyesulet.Text,
                Eredmenyek = Convert.ToInt32(txtEredmenyek.Text)
            };

            // modositas
            if (_indulo != null) {
                Data.Indulok.Update(Indulo);
            }
            //hozzaadas
            else {
                Data.Indulok.Add(Indulo);
            }
            Close();
        }

        private void btnUjEgyesulet_Click(object sender, RoutedEventArgs e) {
            (new Egyesulet_Hozzaadas_Modositas()).ShowDialog();
        }

        private void BtnEgysuletClear_OnClick(object sender, RoutedEventArgs e) {
            cbEgyesulet.SelectedIndex = -1;
        }

        #region Hozzaadas

        public Indulo_Hozzaadas_Modositas() {
            InitializeComponent();
            InitializeContent();
        }

        private void InitializeContent() {
            Title += " hozzáadás";
            cbEgyesulet.ItemsSource = Data.Egyesuletek._egyesuletek;
            txtEredmenyek.Text = "0";
            txtEredmenyek.IsEnabled = false;
        }

        #endregion

        #region Modositas

        public Indulo_Hozzaadas_Modositas(Model.Indulo.Indulo indulo) {
            _indulo = indulo;
            InitializeComponent();
            InitializeContent(_indulo);
        }

        private void InitializeContent(Model.Indulo.Indulo indulo) {
            Title += " módosítás";
            txtNev.Text = indulo.Nev;
            txtNem.Text = indulo.Nem;

            txtNev.IsEnabled = false;
            txtEredmenyek.Text = indulo.Eredmenyek.ToString();
            txtEredmenyek.IsEnabled = false;

            // TODO convert???
            dtSzuletes.Text = indulo.SzuletesiDatum;
            txtEngedely.Text = indulo.Engedely;
            cbEgyesulet.ItemsSource = Data.Egyesuletek._egyesuletek;
            cbEgyesulet.Text = indulo.Egyesulet;
            txtEredmenyek.IsEnabled = false;
        }

        private bool IsValid() {
            var valid = true;

            dtSzuletes.ClearValue(Border.BorderBrushProperty);
            txtNev.ClearValue(Border.BorderBrushProperty);
            txtNem.ClearValue(Border.BorderBrushProperty);

            if (dtSzuletes.SelectedDate == null) {
                dtSzuletes.BorderBrush = new SolidColorBrush(Colors.Red);
                valid = false;
            }
            else if (dtSzuletes.SelectedDate.Value.Year.Equals(DateTime.Now.Year)) {
                dtSzuletes.BorderBrush = new SolidColorBrush(Colors.Red);
                valid = false;
            }

            if (txtNev.Text.Length > 30 || txtNev.Text.Length <= 0) {
                txtNev.BorderBrush = new SolidColorBrush(Colors.Red);
                valid = false;
            }

            if (txtNem.Text != "n" && txtNem.Text != "N" && txtNem.Text != "f" && txtNem.Text != "F") {
                txtNem.BorderBrush = new SolidColorBrush(Colors.Red);
                valid = false;
            }
            return valid;
        }

        #endregion
    }
}