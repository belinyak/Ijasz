using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows;
using System.Windows.Input;
using Ijasz2.Model;
using Ijasz2.Model.Data;
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
            ( new Megjelenites.Versenysorozat.Versenysorozat_Hozzaadas( ) ).ShowDialog( );
        }

        private void BtnVersenysorozatTorles_OnClick( object sender, RoutedEventArgs e ) {
            if (VersenysorozatGrid.SelectedItem == null){
                return;
            }
            var vs = VersenysorozatGrid.SelectedItem as Versenysorozat;

            (new Megjelenites.Versenysorozat.Versenysorozat_Torles(vs.Azonosito)).ShowDialog();
        }

        private void Versenysorozat_Modositas( object sender, MouseButtonEventArgs e ) {
            if (VersenysorozatGrid.SelectedItem == null){
                return;
            }
            var vs = VersenysorozatGrid.SelectedItem as Versenysorozat;

            (new Megjelenites.Versenysorozat.Versenysorozat_Modositas(vs)).ShowDialog();

        }
        #endregion

        #region Verseny
        private void btnVersenyHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Verseny.Verseny_Hozzaadas( ) ).ShowDialog( );
        }

        private void Verseny_Modositas( object sender, MouseButtonEventArgs e ) {
        }

        private void BtnVersenyTorles_OnClick( object sender, RoutedEventArgs e ) {
        }
        #endregion


        private void btnKorosztalyHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Korosztaly.Korosztaly_Hozzaadas( ) ).ShowDialog( );
        }

        private void btnKorosztalyIndulok_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Korosztaly.Korosztaly_Indulok( ) ).ShowDialog( );
        }

        private void btnIjtipusHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Ijtipusok.Ijtipus_Hozzaadas( ) ).ShowDialog( );
        }

        private void btnKorosztalyTorles_Click( object sender, RoutedEventArgs e ) {

        }

        private void btnKorosztalySzamolas_Click( object sender, RoutedEventArgs e ) {

        }

        private void btnEgyesuletTorles_Click( object sender, RoutedEventArgs e ) {

        }

        private void btnEgyesuletHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Egyesület.Egyesulet_Hozzaadas( ) ).ShowDialog( );
        }

        private void btnEgyesuletHozzaadas_Click_1( object sender, RoutedEventArgs e ) {

        }

        private void btnInduloHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Indulo.Indulo_Hozzaadas( ) ).ShowDialog( );
        }

        private void btnInduloTorles_Click( object sender, RoutedEventArgs e ) {

        }

        private void btnInduloBeiras_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Indulo.Indulo_Beiras( ) ).ShowDialog( );
        }

        private void btnEredmenyLezaras_Click( object sender, RoutedEventArgs e ) {

        }

        private void btnEredmenyMegnyitas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Eredmeny.Eredmeny_Hozzaadas( ) ).ShowDialog( );
        }

        private void btnEredmenyTorles_Click( object sender, RoutedEventArgs e ) {

        }

        private void btnstartListaNyomtat_Click( object sender, RoutedEventArgs e ) {

        }

        private void btneredmenylapNyomtat_Click( object sender, RoutedEventArgs e ) {

        }

        private void btnOklevelNyomtat_Click( object sender, RoutedEventArgs e ) {

        }

        private void btnSablonTorles_Click( object sender, RoutedEventArgs e ) {

        }

        private void btnSablonHozzaadas_Click( object sender, RoutedEventArgs e ) {

        }

        private void btnSablonTorles_Click_1( object sender, RoutedEventArgs e ) {

        }

        private void btnOSablonHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Oklevel.Sablon_Hozzaadas( ) ).ShowDialog( );
        }

        private void btnOklevelNyomtatas_Click( object sender, RoutedEventArgs e ) {

        }
        #endregion

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e) {
            var worker = new BackgroundWorker();
            worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;
            worker.DoWork += WorkerOnDoWork;
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// load all the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="doWorkEventArgs"></param>
        private void WorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs) {
            Data = new Data();
        }

        /// <summary>
        /// set itemsource for binding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="runWorkerCompletedEventArgs"></param>
        private void WorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs) {

            VersenysorozatGrid.ItemsSource = Model.Data.Data.Versenysorozatok._versenysorozatok;
            VersenyGrid.ItemsSource = Model.Data.Data.Versenyek._versenyek;
            cboVerseny.ItemsSource = Model.Data.Data.Versenyek._versenyek;
        }


    }
}
