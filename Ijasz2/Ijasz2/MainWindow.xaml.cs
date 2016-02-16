﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows;
using System.Windows.Input;
using Ijasz2.Model;
using Ijasz2.Model.Data;
using Ijasz2.Model.Ijtipus;
using Ijasz2.Model.Korosztaly;
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
                foreach( var versenykorosztalyok in Model.Data.Data.Korosztalyok._korosztalyok ) {
                    if( versenykorosztalyok[0].Verseny.Equals( verseny.Azonosito ) ) {
                        KorosztalyGrid.ItemsSource = versenykorosztalyok;
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
            ( new Megjelenites.Korosztaly.Korosztaly_Torles( cboVerseny.Text, korosztaly.Azonosito ) ).ShowDialog( );
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

            cboVerseny.ItemsSource = Model.Data.Data.Versenyek._versenyek;
        }
    }
}
