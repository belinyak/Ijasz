using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Ijasz2.Model.Data;

namespace Ijasz2.Megjelenites.Ijtipus {
    /// <summary>
    ///     Interaction logic for Ijtipus_Hozzaadas_Modositas.xaml
    /// </summary>
    public partial class Ijtipus_Hozzaadas_Modositas {
        private readonly Model.Ijtipus.Ijtipus _ijtipus;

        private void BtnRendben_OnClick(object sender, RoutedEventArgs e) {
            if (IsValid() == false) {
                return;
            }

            var Ijtipus = new Model.Ijtipus.Ijtipus {
                Azonosito = txtAzonosito.Text,
                Megnevezes = txtMegnevezes.Text,
                Sorszam = Convert.ToInt32(txtListazas.Text),
                Eredmenyek = 0
            };
            // hozzaadas
            if (_ijtipus == null) {
                Data.Ijtipusok.Add(Ijtipus);
            }
            // modositas
            else {
                Ijtipus.Eredmenyek = _ijtipus.Eredmenyek;
                Data.Ijtipusok.Update(Ijtipus);
            }
            Close();
        }

        #region Hozzaadas

        public Ijtipus_Hozzaadas_Modositas() {
            InitializeComponent();
            InitializeContent();
        }

        private void InitializeContent() {
            Title += " hozzáadás";
        }

        #endregion

        #region Modositas

        public Ijtipus_Hozzaadas_Modositas(Model.Ijtipus.Ijtipus ijtipus) {
            _ijtipus = ijtipus;
            InitializeComponent();
            InitializeContent(_ijtipus);
        }

        private void InitializeContent(Model.Ijtipus.Ijtipus ijtipus) {
            Title += " módosítás";
            txtAzonosito.Text = ijtipus.Azonosito;
            txtAzonosito.IsEnabled = false;
            txtMegnevezes.Text = ijtipus.Megnevezes;
            txtListazas.Text = ijtipus.Sorszam.ToString();
        }

        private bool IsValid() {
            var valid = true;
            txtAzonosito.ClearValue(Border.BorderBrushProperty);
            txtListazas.ClearValue(Border.BorderBrushProperty);

            if (txtAzonosito.Text.Length == 0) {
                txtAzonosito.BorderBrush = new SolidColorBrush(Colors.Red);
                valid = false;
            }

            try {
                Convert.ToInt32(txtListazas.Text);
            }
            catch {
                txtListazas.BorderBrush = new SolidColorBrush(Colors.Red);
                valid = false;
            }

            return valid;
        }

        #endregion
    }
}