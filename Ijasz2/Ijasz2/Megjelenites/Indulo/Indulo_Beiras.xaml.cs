using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Ijasz2.Megjelenites.Indulo {
    /// <summary>
    /// Interaction logic for Indulo_Beiras.xaml
    /// </summary>
    public partial class Indulo_Beiras : Window {
        private readonly Model.Indulo.Indulo _indulo;

        public Indulo_Beiras( Model.Indulo.Indulo indulo ) {
            _indulo = indulo;
            InitializeComponent( );
            InitializeContent( _indulo );
        }

        private void InitializeContent( Model.Indulo.Indulo indulo ) {
            var Csapatok = new ObservableCollection<int>();
            for( int i = 1; i < 46; i++ ) {
                Csapatok.Add( i );
            }
            cbCsapat.ItemsSource = Csapatok;

            cbIjtipus.ItemsSource = Model.Data.Data.Ijtipusok._ijtipusok;
            cbVerseny.ItemsSource = Model.Data.Data.Versenyek._versenyek;

            cbUjKorosztaly.IsEnabled = false;

            txtNev.Text = indulo.Nev;
            txtNev.IsEnabled = false;
        }

        private void btnCsapatok_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Indulo.Indulo_Csapatok( ) ).ShowDialog( );
        }

        private void ChKorosztalyFelulir_OnClick( object sender, RoutedEventArgs e ) {
            if( cbVerseny.SelectedItem == null ) {
                return;
            }

            cbUjKorosztaly.IsEnabled = !( cbUjKorosztaly.IsEnabled );
        }

        private void CbVerseny_OnSelectionChanged( object sender, SelectionChangedEventArgs e ) {
            if( cbVerseny.SelectedItem != null ) {
                Model.Verseny.Verseny currentVerseny = cbVerseny.SelectedItem as Model.Verseny.Verseny;
                cbUjKorosztaly.ItemsSource = null;
                foreach( var versenyKorosztaly in Model.Data.Data.Korosztalyok._versenyKorosztalyok ) {
                    if( versenyKorosztaly.VersenyAzonosito.Equals( currentVerseny.Azonosito ) ) {
                        cbUjKorosztaly.ItemsSource = versenyKorosztaly.Korosztalyok;
                        return;
                    }
                }
            }
        }

        private bool IsValid( ) {
            bool valid = true;

            cbVerseny.ClearValue( Border.BorderBrushProperty );
            cbIjtipus.ClearValue( Border.BorderBrushProperty );
            cbCsapat.ClearValue( Border.BorderBrushProperty );
            chKorosztalyFelulir.ClearValue( Border.BorderBrushProperty );
            cbUjKorosztaly.ClearValue( Border.BorderBrushProperty );

            if( cbVerseny.SelectedItem == null ) {
                cbVerseny.Background = new SolidColorBrush( Colors.Red );
                valid = false;
            }

            if( cbIjtipus.SelectedItem == null ) {
                cbIjtipus.Background = new SolidColorBrush( Colors.Red );
                valid = false;
            }

            if( cbCsapat.SelectedItem == null ) {
                cbCsapat.Background = new SolidColorBrush( Colors.Red );
                valid = false;
            }

            if( ( chKorosztalyFelulir.IsChecked == true ) &&
                ( cbUjKorosztaly.Text == "" ) ) {
                cbUjKorosztaly.Background = new SolidColorBrush( Colors.Red );
                chKorosztalyFelulir.Background = new SolidColorBrush( Colors.Red );
                valid = false;
            }

            return valid;
        }

        /// <summary>
        /// induló beírása
        /// TODO korosztaly szamolas
        /// TODO eredmenyek novelese
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRendben_OnClick( object sender, RoutedEventArgs e ) {
            if( IsValid( ) == false ) {
                return;
            }

            foreach( var versenyEredmeny in Model.Data.Data.Eredmenyek._versenyEredmenyek ) {
                if( versenyEredmeny.VersenyAzonosito.Equals( cbVerseny.Text ) ) {
                    versenyEredmeny.Eredmenyek.Add( new Model.Eredmeny.Eredmeny {
                        Verseny = versenyEredmeny.VersenyAzonosito,
                        Indulo = _indulo.Nev,
                        Sorszam = 0,
                        Ijtipus = cbIjtipus.Text,
                        Csapat = Convert.ToInt32( cbCsapat.Text ),
                        Talalat10 = 0,
                        Talalat8 = 0,
                        Talalat5 = 0,
                        Melle = 0,
                        OsszPont = 0,
                        Szazalek = 0,
                        Megjelent = chMegjelent.IsChecked == true,
                        KorosztalyAzonosito = chKorosztalyFelulir.IsChecked == true ? cbUjKorosztaly.Text : ( "k10" + versenyEredmeny.VersenyAzonosito )
                    } );
                    Model.Data.Data.Indulok.EredmenyNoveles(_indulo.Nev);
                    Model.Data.Data.Ijtipusok.EredmenyekNoveles(cbIjtipus.Text);
                    Close();
                    return;
                }
            }
        }
    }
}
