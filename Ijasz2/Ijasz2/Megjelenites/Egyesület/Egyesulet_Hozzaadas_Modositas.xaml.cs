using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ijasz2.Megjelenites.Egyesület {
    /// <summary>
    /// Interaction logic for Egyesulet_Hozzaadas_Modositas.xaml
    /// </summary>
    public partial class Egyesulet_Hozzaadas_Modositas : Window {
        private readonly Model.Egyesulet.Egyesulet _egyesulet;

        #region Hozzaadas
        public Egyesulet_Hozzaadas_Modositas( ) {
            InitializeComponent( );
            InitializeContent( );
        }

        private void InitializeContent( ) {
            Title += " hozzáadás";
        }
        #endregion

        #region Modositas
        public Egyesulet_Hozzaadas_Modositas( Model.Egyesulet.Egyesulet egyesulet ) {
            _egyesulet = egyesulet;
            InitializeComponent( );
            InitializeContent( _egyesulet );
        }

        private void InitializeContent( Model.Egyesulet.Egyesulet egyesulet ) {
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

        private bool IsValid( ) {
            bool valid = true;
            txtNev.ClearValue( Border.BorderBrushProperty );

            if( txtNev.Text.Length == 0 ) {
                txtNev.BorderBrush = new SolidColorBrush( Colors.Red );
                valid = false;
            }
            return valid;
        }

        private void BtnRendben_OnClick( object sender, RoutedEventArgs e ) {
            if( IsValid( ) == false ) {
                return;
            }

            var Egyesulet = new Model.Egyesulet.Egyesulet {
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
            if( _egyesulet == null ) {
                Model.Data.Data.Egyesuletek.Add( Egyesulet );
            }
            // modositas
            else {
                Egyesulet.TagokSzama = _egyesulet.TagokSzama;
                Model.Data.Data.Egyesuletek.Update( Egyesulet );
            }
            Close( );
        }
    }
}
