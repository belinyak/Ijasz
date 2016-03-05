using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Ijasz2.Model.Data;
using Ijasz2.Model.Egyesulet;

namespace Ijasz2.Megjelenites.Egyesület {
    /// <summary>
    ///     Interaction logic for Egyesulet_Hozzaadas_Modositas.xaml
    /// </summary>
    public partial class Egyesulet_Hozzaadas_Modositas {
        private readonly Egyesulet _egyesulet;

        private bool IsValid() {
            var valid = true;
            txtNev.ClearValue(Border.BorderBrushProperty);

            if (txtNev.Text.Length == 0) {
                txtNev.BorderBrush = new SolidColorBrush(Colors.Red);
                valid = false;
            }
            return valid;
        }

        private void BtnRendben_OnClick(object sender, RoutedEventArgs e) {
            if (IsValid() == false) {
                return;
            }

            var Egyesulet = new Egyesulet {
                Azonosito = txtNev.Text,
                Cim = txtCim.Text,
                Vezeto = txtVezeto.Text,
                Telefon1 = txtTelefon0.Text,
                Telefon2 = txtTelefon1.Text,
                Email1 = txtEmail0.Text,
                Email2 = txtEmail1.Text,
                Listazando = chLista.IsChecked == true,
                TagokSzama = 0
            };

            // hozzaadas
            if (_egyesulet == null) {
                Data.Egyesuletek.Add(Egyesulet);
            }
            // modositas
            else {
                Egyesulet.TagokSzama = _egyesulet.TagokSzama;
                Data.Egyesuletek.Update(Egyesulet);
            }
            Close();
        }

        #region Hozzaadas

        public Egyesulet_Hozzaadas_Modositas() {
            InitializeComponent();
            InitializeContent();
        }

        private void InitializeContent() {
            Title += " hozzáadás";
        }

        #endregion

        #region Modositas

        public Egyesulet_Hozzaadas_Modositas(Egyesulet egyesulet) {
            _egyesulet = egyesulet;
            InitializeComponent();
            InitializeContent(_egyesulet);
        }

        private void InitializeContent(Egyesulet egyesulet) {
            Title += " módosítás";
            txtNev.Text = egyesulet.Azonosito;
            txtNev.IsEnabled = false;
            txtCim.Text = egyesulet.Cim;
            txtVezeto.Text = egyesulet.Vezeto;
            txtTelefon0.Text = egyesulet.Telefon1;
            txtTelefon1.Text = egyesulet.Telefon2;
            txtEmail0.Text = egyesulet.Email1;
            txtEmail1.Text = egyesulet.Email2;
            chLista.IsChecked = egyesulet.Listazando;
        }

        #endregion
    }
}