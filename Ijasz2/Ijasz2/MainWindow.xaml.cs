using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Ijasz2.Model;
using Ijasz2.Model.Data;
using Ijasz2.Model.Eredmeny;
using Ijasz2.Model.Ijtipus;
using Ijasz2.Model.Indulo;
using Ijasz2.Model.Korosztaly;
using Ijasz2.Model.Oklevel;
using Ijasz2.Model.Verseny;
using Ijasz2.Model.Versenysorozat;

namespace Ijasz2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public static Model.Data.Data Data;

        public MainWindow( ) {
            InitializeComponent( );
        }

        #region Button EventHandlers

        #region Versenysorozat
        private void BtnVersenysorozatHozzaadas_OnClick( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Versenysorozat.Versenysorozat_Hozzaadas_Modositas( ) ).ShowDialog( );
        }

        private void BtnVersenysorozatTorles_OnClick( object sender, RoutedEventArgs e ) {
            if( VersenysorozatGrid.SelectedItem == null ) {
                return;
            }
            var vs = VersenysorozatGrid.SelectedItem as Versenysorozat;

            ( new Megjelenites.Versenysorozat.Versenysorozat_Torles( vs.Azonosito ) ).ShowDialog( );
        }

        private void Versenysorozat_Modositas( object sender, MouseButtonEventArgs e ) {
            if( VersenysorozatGrid.SelectedItem == null ) {
                return;
            }
            var vs = VersenysorozatGrid.SelectedItem as Versenysorozat;

            ( new Megjelenites.Versenysorozat.Versenysorozat_Hozzaadas_Modositas( vs ) ).ShowDialog( );

        }
        #endregion

        #region Verseny
        private void btnVersenyHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Verseny.Verseny_Hozzaadas_Modositas( ) ).ShowDialog( );
        }

        private void Verseny_Modositas( object sender, MouseButtonEventArgs e ) {
            Verseny verseny = VersenyGrid.SelectedItem as Verseny;
            ( new Megjelenites.Verseny.Verseny_Hozzaadas_Modositas( verseny ) ).ShowDialog( );

        }

        private void BtnVersenyTorles_OnClick( object sender, RoutedEventArgs e ) {
            if( VersenyGrid.SelectedItem == null ) {
                return;
            }
            var ve = VersenyGrid.SelectedItem as Verseny;

            ( new Megjelenites.Verseny.Verseny_Torles( ve.Azonosito ) ).ShowDialog( );
        }
        #endregion

        #region Korosztaly
        /// <summary>
        /// versenyhez tartozo korosztalyok bindolasa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboVerseny_SelectionChanged( object sender, System.Windows.Controls.SelectionChangedEventArgs e ) {
            KorosztalyGrid.ItemsSource = null; ;
            var verseny = cboVerseny.SelectedItem as Verseny;

            if( verseny != null ) {
                foreach( var versenykorosztalyok in Model.Data.Data.Korosztalyok._versenyKorosztalyok ) {
                    if( versenykorosztalyok.VersenyAzonosito.Equals( verseny.Azonosito ) ) {
                        KorosztalyGrid.ItemsSource = versenykorosztalyok.Korosztalyok;
                        return;
                    }
                }
            }
        }

        private void Korosztaly_Modositas( object sender, MouseButtonEventArgs e ) {
            if( KorosztalyGrid.SelectedItem == null || cboVerseny.Text == "" ) {
                return;
            }
            var korosztaly = KorosztalyGrid.SelectedItem as Korosztaly;
            ( new Megjelenites.Korosztaly.Korosztaly_Hozzaadas_Modositas( korosztaly ) ).ShowDialog( );
        }

        private void btnKorosztalyHozzaadas_Click( object sender, RoutedEventArgs e ) {
            if( cboVerseny.Text == "" ) {
                return;
            }

            var korosztaly = new Korosztaly();
            korosztaly.Verseny = cboVerseny.Text;

            ( new Megjelenites.Korosztaly.Korosztaly_Hozzaadas_Modositas( korosztaly ) ).ShowDialog( );
        }

        private void btnKorosztalyIndulok_Click( object sender, RoutedEventArgs e ) {
            if( cboVerseny.Text == "" ) {
                return;
            }
            ( new Megjelenites.Korosztaly.Korosztaly_Indulok( ) ).ShowDialog( );
        }

        private void btnKorosztalyTorles_Click( object sender, RoutedEventArgs e ) {
            if( KorosztalyGrid.SelectedItem == null || cboVerseny.Text == "" ) {
                return;
            }
            var korosztaly = KorosztalyGrid.SelectedItem as Korosztaly;
            ( new Megjelenites.Korosztaly.Korosztaly_Torles( korosztaly ) ).ShowDialog( );
        }

        private void btnKorosztalySzamolas_Click( object sender, RoutedEventArgs e ) {
            throw new NotImplementedException( );
        }
        #endregion

        #region Ijtipus
        private void btnIjtipusHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Ijtipus.Ijtipus_Hozzaadas_Modositas( ) ).ShowDialog( );
        }

        private void BtnIjtipusTorles_OnClick( object sender, RoutedEventArgs e ) {
            if( IjtipusGrid.SelectedItem == null ) {
                return;
            }

            Ijtipus ijtipus = IjtipusGrid.SelectedItem as Ijtipus;
            ( new Megjelenites.Ijtipus.Ijtipus_Torles( ijtipus ) ).ShowDialog( );
        }

        private void Ijtipus_Modositas( object sender, MouseButtonEventArgs e ) {
            Model.Ijtipus.Ijtipus ijtipus = IjtipusGrid.SelectedItem as Ijtipus;
            ( new Megjelenites.Ijtipus.Ijtipus_Hozzaadas_Modositas( ijtipus ) ).ShowDialog( );

        }
        #endregion

        #region Egyesulet
        private void btnEgyesuletTorles_Click( object sender, RoutedEventArgs e ) {
            if( EgyesuletGrid.SelectedItem == null ) {
                return;
            }

            var egyesulet = EgyesuletGrid.SelectedItem as Model.Egyesulet.Egyesulet;

            ( new Megjelenites.Egyesület.Egyesulet_Torles( egyesulet ) ).ShowDialog( );
        }

        private void btnEgyesuletHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Egyesület.Egyesulet_Hozzaadas_Modositas( ) ).ShowDialog( );
        }

        private void Egyesulet_Modositas( object sender, MouseButtonEventArgs e ) {
            var egyesulet = EgyesuletGrid.SelectedItem as Model.Egyesulet.Egyesulet;

            ( new Megjelenites.Egyesület.Egyesulet_Hozzaadas_Modositas( egyesulet ) ).ShowDialog( );
        }
        #endregion

        #region Indulo
        private void Indulo_Modositas( object sender, MouseButtonEventArgs e ) {
            var Indulo = InduloGrid.SelectedItem as Indulo;

            ( new Megjelenites.Indulo.Indulo_Hozzaadas_Modositas( Indulo ) ).ShowDialog( );
        }

        private void btnInduloHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Indulo.Indulo_Hozzaadas_Modositas( ) ).ShowDialog( );
        }

        private void btnInduloTorles_Click( object sender, RoutedEventArgs e ) {
            if( InduloGrid.SelectedItem == null ) {
                return;
            }

            var Indulo = InduloGrid.SelectedItem as Indulo;

            ( new Megjelenites.Indulo.Indulo_Torles( Indulo ) ).ShowDialog( );
        }

        private void btnInduloBeiras_Click( object sender, RoutedEventArgs e ) {
            if( InduloGrid.SelectedItem == null ) {
                return;
            }

            var Indulo = InduloGrid.SelectedItem as Indulo;

            ( new Megjelenites.Indulo.Indulo_Beiras( Indulo ) ).ShowDialog( );
        }
        #endregion

        #region Eredmenyek
        private void cboEredmenyVerseny_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
            EredmenyGrid.ItemsSource = null;

            var comboBox = sender as ComboBox;
            if( comboBox != null ) {
                var verseny = comboBox.SelectedItem as Verseny;

                if( verseny != null ) {
                    foreach( var versenyEredmeny in Model.Data.Data.Eredmenyek._versenyEredmenyek ) {
                        if( versenyEredmeny.VersenyAzonosito.Equals( verseny.Azonosito ) ) {
                            EredmenyGrid.ItemsSource = versenyEredmeny.Eredmenyek._eredmenyek;
                            return;
                        }
                    }
                }
            }
        }

        private void btnEredmenyLezaras_Click( object sender, RoutedEventArgs e ) {

        }

        private void Eredmeny_Modositas( object sender, MouseButtonEventArgs e ) {
            var Eredmeny = EredmenyGrid.SelectedItem as Eredmeny;

            ( new Megjelenites.Eredmeny.Eredmeny_Hozzaadas_Modositas( Eredmeny ) ).ShowDialog( );
        }

        private void btnEredmenyMegnyitas_Click( object sender, RoutedEventArgs e ) {
            throw new NotImplementedException( );
        }

        private void btnEredmenyTorles_Click( object sender, RoutedEventArgs e ) {

        }
        #endregion

        #region Startlista
        private void btnstartListaNyomtat_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Startlista.Startlista_Nyomtatas( ) ).ShowDialog( );
        }
        #endregion

        #region EredmenyLapok
        private void btneredmenylapNyomtat_Click( object sender, RoutedEventArgs e ) {

        }
        #endregion

        #region Oklevel
        private void btnOklevelNyomtat_Click( object sender, RoutedEventArgs e ) {

        }

        private void btnSablonTorles_Click( object sender, RoutedEventArgs e ) {
            var sablon = SablonGrid.SelectedItem as Sablon;

            ( new Megjelenites.Oklevel.Sablon_Torles( sablon.Azonosito ) ).ShowDialog( );
        }

        private void btnSablonHozzaadas_Click( object sender, RoutedEventArgs e ) {

        }

        private void btnSablonTorles_Click_1( object sender, RoutedEventArgs e ) {

        }

        private void btnOSablonHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Oklevel.Sablon_Hozzaadas_Modositas( ) ).ShowDialog( );
        }

        private void btnOklevelNyomtatas_Click( object sender, RoutedEventArgs e ) {

        }

        private void Sablon_Modositas( object sender, MouseButtonEventArgs e ) {
            var azonosito = ((sender as DataGridRow).DataContext as Model.Oklevel.Sablon).Azonosito;

            foreach( var sablon in Model.Data.Data.Sablonok._sablonok ) {
                if( sablon.Azonosito.Equals( azonosito ) ) {
                    ( new Megjelenites.Oklevel.Sablon_Hozzaadas_Modositas( sablon ) ).ShowDialog( );
                    return;
                }
            }
        }
        #endregion

        #endregion

        private void MainWindow_OnLoaded( object sender, RoutedEventArgs e ) {
            var worker = new BackgroundWorker();
            worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;
            worker.DoWork += WorkerOnDoWork;
            worker.RunWorkerAsync( );
        }

        /// <summary>
        /// load all the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="doWorkEventArgs"></param>
        private void WorkerOnDoWork( object sender, DoWorkEventArgs doWorkEventArgs ) {
            Data = new Data( );
        }

        /// <summary>
        /// set itemsource for binding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="runWorkerCompletedEventArgs"></param>
        private void WorkerOnRunWorkerCompleted( object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs ) {
            VersenysorozatGrid.ItemsSource = Model.Data.Data.Versenysorozatok._versenysorozatok;
            VersenyGrid.ItemsSource = Model.Data.Data.Versenyek._versenyek;
            IjtipusGrid.ItemsSource = Model.Data.Data.Ijtipusok._ijtipusok;
            EgyesuletGrid.ItemsSource = Model.Data.Data.Egyesuletek._egyesuletek;
            InduloGrid.ItemsSource = Model.Data.Data.Indulok._indulok;
            //EredmenyGrid.ItemsSource = Model.Data.Data.Eredmenyek._eredmenyek;
            SablonGrid.ItemsSource = Model.Data.Data.Sablonok._sablonok;


            cboVerseny.ItemsSource = Model.Data.Data.Versenyek._versenyek;
            cboEredmenyVerseny.ItemsSource = Model.Data.Data.Versenyek._versenyek;
            cbstartListaVersenyAzonosito.ItemsSource = Model.Data.Data.Versenyek._versenyek;

            cberedmenylapVersenyAzonosito.ItemsSource = Model.Data.Data.Versenyek._versenyek;
            cberedmenylapVersenysorozatAzonosito.ItemsSource = Model.Data.Data.Versenysorozatok._versenysorozatok;

            cboOklevelVeAzonosito.ItemsSource = Model.Data.Data.Versenyek._versenyek;
            cboOklevelVsAzonosito.ItemsSource = Model.Data.Data.Versenysorozatok._versenysorozatok;

            cboOklevelLegjobb.ItemsSource = new ObservableCollection<int> { 1, 2, 3, 4, 5 };

        }

        private void CbstartListaVersenyAzonosito_OnSelectionChanged( object sender, SelectionChangedEventArgs e ) {
            txtstartListaVersenyMegnevezes.Text = ( ( ( sender as ComboBox ).SelectedItem ) as Verseny ).Megnevezes;
        }

        private void CberedmenylapVersenyAzonosito_OnSelectionChanged( object sender, SelectionChangedEventArgs e ) {
            txteredmenylapVersenyMegnevezes.Text = ( ( ( sender as ComboBox ).SelectedItem ) as Verseny ).Megnevezes;
        }

        private void CberedmenylapVersenysorozatAzonosito_OnSelectionChanged( object sender, SelectionChangedEventArgs e ) {
            txteredmenylapVersenysorozatMegnevezes.Text = ( ( ( sender as ComboBox ).SelectedItem ) as Versenysorozat ).Megnevezes;
        }

        private void CboOklevelVeAzonosito_OnSelectionChanged( object sender, SelectionChangedEventArgs e ) {
            txtOklevelVeMegnevezes.Text = ( ( ( sender as ComboBox ).SelectedItem ) as Verseny ).Megnevezes;
        }

        private void CboOklevelVsAzonosito_OnSelectionChanged( object sender, SelectionChangedEventArgs e ) {
            txtOklevelVsMegnevezes.Text = ( ( ( sender as ComboBox ).SelectedItem ) as Versenysorozat ).Megnevezes;
        }

    }
}
