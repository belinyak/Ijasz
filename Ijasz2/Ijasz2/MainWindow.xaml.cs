﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Ijasz2.Model;

namespace Ijasz2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public static ObservableCollection<Versenysorozat> _versenysorozatok; 

        public MainWindow( ) {
            InitializeComponent( );
        }

        public static void Add(Versenysorozat versenysorozat) {
            _versenysorozatok.Add(versenysorozat);
        }

        #region Button EventHandlers
        private void BtnVersenysorozatHozzaadas_OnClick( object sender, RoutedEventArgs e ) {
            //_versenysorozatok.Add( new Versenysorozat { Azonosito = "vs10", Megnevezes = "versenysorozat10", VersenyekSzama = 10 } );

            (new Megjelenites.Versenysorozat.Versenysorozat_Hozzaadas()).ShowDialog();
        }

        private void BtnVersenysorozatTorles_OnClick( object sender, RoutedEventArgs e ) {
            if( VersenysorozatGrid.SelectedItem != null )
            {
                _versenysorozatok.Remove(
                    _versenysorozatok.Single(
                        s => s.Azonosito.Equals((VersenysorozatGrid.SelectedItem as Versenysorozat).Azonosito)));
            }
        }

        private void btnVersenyHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Megjelenites.Verseny.Verseny_Hozzaadas( ) ).ShowDialog( );
        }

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
        /// itt töltődik be minden adat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="doWorkEventArgs"></param>
        private void WorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs) {
            _versenysorozatok = new ObservableCollection<Versenysorozat> {
                new Versenysorozat("vs1", "versenysorozat1", 0),
                new Versenysorozat("vs2", "versenysorozat1", 0),
                new Versenysorozat("vs3", "versenysorozat1", 0)
            };
        }

        private void WorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs) {
            VersenysorozatGrid.ItemsSource = _versenysorozatok;
        }

    }
}
