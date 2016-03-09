using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Ijasz2.Adatbazis;
using Ijasz2.Megjelenites.Egyesület;
using Ijasz2.Megjelenites.Eredmeny;
using Ijasz2.Megjelenites.Ijtipus;
using Ijasz2.Megjelenites.Indulo;
using Ijasz2.Megjelenites.Korosztaly;
using Ijasz2.Megjelenites.Oklevel;
using Ijasz2.Megjelenites.Seged;
using Ijasz2.Megjelenites.Startlista;
using Ijasz2.Megjelenites.Verseny;
using Ijasz2.Megjelenites.Versenysorozat;
using Ijasz2.Model.Data;
using Ijasz2.Model.Egyesulet;
using Ijasz2.Model.Eredmeny;
using Ijasz2.Model.Ijtipus;
using Ijasz2.Model.Indulo;
using Ijasz2.Model.Korosztaly;
using Ijasz2.Model.Oklevel;
using Ijasz2.Model.Verseny;
using Ijasz2.Model.Versenysorozat;
using Ijasz2.Nyomtatas.Seged;
using Ijasz2.Nyomtatas.Startlista;

namespace Ijasz2 {
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        private static Data Data;
        private Megjelenites.Seged.WaitWindow loadWait;
        public MainWindow( ) {
            InitializeComponent( );
        }

        private void MainWindow_OnLoaded( object sender, RoutedEventArgs e ) {
            loadWait = new Megjelenites.Seged.WaitWindow( "Adatok betöltése..." );
            loadWait.Show( );

            new Database( );

            var worker = new BackgroundWorker();
            worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;
            worker.DoWork += WorkerOnDoWork;
            worker.RunWorkerAsync( );
        }

        /// <summary>
        ///     load all the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="doWorkEventArgs"></param>
        private static void WorkerOnDoWork( object sender, DoWorkEventArgs doWorkEventArgs ) {
            Data = new Data( );
        }

        /// <summary>
        ///     set itemsource for binding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="runWorkerCompletedEventArgs"></param>
        private void WorkerOnRunWorkerCompleted( object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs ) {
            VersenysorozatGrid.ItemsSource = Data.Versenysorozatok._versenysorozatok;
            VersenyGrid.ItemsSource = Data.Versenyek._versenyek;
            IjtipusGrid.ItemsSource = Data.Ijtipusok._ijtipusok;
            EgyesuletGrid.ItemsSource = Data.Egyesuletek._egyesuletek;
            InduloGrid.ItemsSource = Data.Indulok._indulok;

            //EredmenyGrid.ItemsSource = Model.Data.Data.Eredmenyek._eredmenyek;
            SablonGrid.ItemsSource = Data.Sablonok._sablonok;

            //TODO egységesen cb-re átnevezni !!!
            //TODO a plusz üres mit csesz el ???
            cboVerseny.ItemsSource = Data.Versenyek._versenyek;
            cboEredmenyVerseny.ItemsSource = Data.Versenyek._versenyek;
            cbstartListaVersenyAzonosito.ItemsSource = Data.Versenyek._versenyek;
            cberedmenylapVersenyAzonosito.ItemsSource = Data.Versenyek._versenyek;
            cberedmenylapVersenysorozatAzonosito.ItemsSource = Data.Versenysorozatok._versenysorozatok;

            cboOklevelVeAzonosito.ItemsSource = Data.Versenyek._versenyek;
            cboOklevelVsAzonosito.ItemsSource = Data.Versenysorozatok._versenysorozatok;
            cboOklevelLegjobb.ItemsSource = new ObservableCollection<int> { 1, 2, 3, 4, 5 };

            // set sort order
            InduloGrid.Items.SortDescriptions.Add( new SortDescription( InduloGrid.Columns.First( ).SortMemberPath, ListSortDirection.Ascending ) );
            EgyesuletGrid.Items.SortDescriptions.Add( new SortDescription( EgyesuletGrid.Columns.First( ).SortMemberPath, ListSortDirection.Ascending ) );
            loadWait.Close( );

        }

        #region Button EventHandlers

        #region Versenysorozat

        private void BtnVersenysorozatHozzaadas_OnClick( object sender, RoutedEventArgs e ) {
            ( new Versenysorozat_Hozzaadas_Modositas( ) ).ShowDialog( );
        }

        private void BtnVersenysorozatTorles_OnClick( object sender, RoutedEventArgs e ) {
            var vs = VersenysorozatGrid.SelectedItem as Versenysorozat;

            if( vs != null ) ( new Versenysorozat_Torles( vs.Azonosito ) ).ShowDialog( );
        }

        private void Versenysorozat_Modositas( object sender, MouseButtonEventArgs e ) {
            if( VersenysorozatGrid.SelectedItem == null ) {
                return;
            }
            var vs = VersenysorozatGrid.SelectedItem as Versenysorozat;

            ( new Versenysorozat_Hozzaadas_Modositas( vs ) ).ShowDialog( );
        }

        #endregion

        #region Verseny

        private void btnVersenyHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Verseny_Hozzaadas_Modositas( ) ).ShowDialog( );
        }

        private void Verseny_Modositas( object sender, MouseButtonEventArgs e ) {
            var verseny = VersenyGrid.SelectedItem as Verseny;
            ( new Verseny_Hozzaadas_Modositas( verseny ) ).ShowDialog( );
        }

        private void BtnVersenyTorles_OnClick( object sender, RoutedEventArgs e ) {
            var ve = VersenyGrid.SelectedItem as Verseny;

            if( ve != null ) ( new Verseny_Torles( ve.Azonosito ) ).ShowDialog( );
        }

        #endregion

        #region Korosztaly

        /// <summary>
        ///     versenyhez tartozo korosztalyok bindolasa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Korosztaly_Modositas( object sender, MouseButtonEventArgs e ) {
            if( KorosztalyGrid.SelectedItem == null || cboVerseny.Text == "" ) {
                return;
            }
            var korosztaly = KorosztalyGrid.SelectedItem as Korosztaly;
            ( new Korosztaly_Hozzaadas_Modositas( korosztaly ) ).ShowDialog( );
        }

        private void btnKorosztalyHozzaadas_Click( object sender, RoutedEventArgs e ) {
            if( cboVerseny.Text == "" ) {
                return;
            }

            var korosztaly = new Korosztaly {
                Verseny = cboVerseny.Text
            };

            ( new Korosztaly_Hozzaadas_Modositas( korosztaly ) ).ShowDialog( );
        }

        private void btnKorosztalyIndulok_Click( object sender, RoutedEventArgs e ) {
            if( cboVerseny.Text == "" || KorosztalyGrid.SelectedItem == null ) {
                return;
            }

            var korosztaly = KorosztalyGrid.SelectedItem as Korosztaly;
            if( korosztaly != null ) {
                var korosztalyAzonosito = korosztaly.Azonosito;

                ( new Korosztaly_Indulok( cboVerseny.Text, korosztalyAzonosito ) ).ShowDialog( );
            }
        }

        private void btnKorosztalyTorles_Click( object sender, RoutedEventArgs e ) {
            if( KorosztalyGrid.SelectedItem == null || cboVerseny.Text == "" ) {
                return;
            }
            var korosztaly = KorosztalyGrid.SelectedItem as Korosztaly;

            ( new Korosztaly_Torles( korosztaly ) ).ShowDialog( );
        }

        /// <summary>
        /// TODO ezt automatizáni kéne
        /// TODO a cbo as verseny !!!
        /// ha van versenysorozat, akkor a versenysorozat 1. versenyekor betöltött életkor számít
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKorosztalySzamolas_Click( object sender, RoutedEventArgs e ) {
            if( string.IsNullOrEmpty( cboVerseny.Text ) ) {
                return;
            }
            foreach( var korosztalyok in Data.Korosztalyok._versenyKorosztalyok.Where( korosztaly => korosztaly.VersenyAzonosito.Equals( cboVerseny.Text ) ) ) {
                korosztalyok.KorosztalySzamolas( cboVerseny.Text );
            }
        }


        #endregion

        #region Ijtipus

        private void btnIjtipusHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Ijtipus_Hozzaadas_Modositas( ) ).ShowDialog( );
        }

        private void BtnIjtipusTorles_OnClick( object sender, RoutedEventArgs e ) {
            if( IjtipusGrid.SelectedItem == null ) {
                return;
            }

            var ijtipus = IjtipusGrid.SelectedItem as Ijtipus;
            ( new Ijtipus_Torles( ijtipus ) ).ShowDialog( );
        }

        private void Ijtipus_Modositas( object sender, MouseButtonEventArgs e ) {
            var ijtipus = IjtipusGrid.SelectedItem as Ijtipus;
            ( new Ijtipus_Hozzaadas_Modositas( ijtipus ) ).ShowDialog( );
        }

        #endregion

        #region Egyesulet

        private void btnEgyesuletTorles_Click( object sender, RoutedEventArgs e ) {
            if( EgyesuletGrid.SelectedItem == null ) {
                return;
            }

            var egyesulet = EgyesuletGrid.SelectedItem as Egyesulet;

            ( new Egyesulet_Torles( egyesulet ) ).ShowDialog( );
        }

        private void btnEgyesuletHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Egyesulet_Hozzaadas_Modositas( ) ).ShowDialog( );
        }

        private void Egyesulet_Modositas( object sender, MouseButtonEventArgs e ) {
            var egyesulet = EgyesuletGrid.SelectedItem as Egyesulet;

            ( new Egyesulet_Hozzaadas_Modositas( egyesulet ) ).ShowDialog( );
        }

        private void btnTagok_Click( object sender, RoutedEventArgs e ) {
            var egyesulet = EgyesuletGrid.SelectedItem as Egyesulet;

            if( egyesulet == null ) {
                return;
            }

            ( new Megjelenites.Egyesület.Egyesulet_Tagok( egyesulet ) ).Show( );
        }
        #endregion

        #region Indulo

        private void Indulo_Modositas( object sender, MouseButtonEventArgs e ) {
            var Indulo = InduloGrid.SelectedItem as Indulo;

            ( new Indulo_Hozzaadas_Modositas( Indulo ) ).ShowDialog( );
        }

        private void btnInduloHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Indulo_Hozzaadas_Modositas( ) ).ShowDialog( );
        }

        private void btnInduloTorles_Click( object sender, RoutedEventArgs e ) {
            if( InduloGrid.SelectedItem == null ) {
                return;
            }

            var Indulo = InduloGrid.SelectedItem as Indulo;

            ( new Indulo_Torles( Indulo ) ).ShowDialog( );
        }

        private void btnInduloBeiras_Click( object sender, RoutedEventArgs e ) {
            if( InduloGrid.SelectedItem == null ) {
                return;
            }

            var Indulo = InduloGrid.SelectedItem as Indulo;

            ( new Indulo_Beiras( Indulo ) ).ShowDialog( );
        }

        #endregion

        #region Eredmenyek

        private void cboEredmenyVerseny_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
            EredmenyGrid.ItemsSource = null;

            var comboBox = sender as ComboBox;
            var verseny = comboBox?.SelectedItem as Verseny;

            if( verseny != null ) {
                foreach( var versenyEredmeny in Data.Eredmenyek._versenyEredmenyek.Where( versenyEredmeny => versenyEredmeny.VersenyAzonosito.Equals( verseny.Azonosito ) ) ) {
                    EredmenyGrid.ItemsSource = versenyEredmeny.Eredmenyek._eredmenyek;
                    EredmenyGrid.Items.SortDescriptions.Add( new SortDescription( EredmenyGrid.Columns[1].SortMemberPath, ListSortDirection.Ascending ) );
                    return;
                }
            }
        }

        private void Eredmeny_Modositas( object sender, MouseButtonEventArgs e ) {
            var Eredmeny = EredmenyGrid.SelectedItem as Eredmeny;

            ( new Eredmeny_Hozzaadas_Modositas( Eredmeny ) ).ShowDialog( );
        }

        private void btnEredmenyTorles_Click( object sender, RoutedEventArgs e ) {
            if( EredmenyGrid.SelectedItem == null ) {
                return;
            }
            var eredmeny = EredmenyGrid.SelectedItem as Eredmeny;
            ( new Eredmeny_Torles( eredmeny ) ).ShowDialog( );
        }

        #endregion

        #region Startlista

        private void btnstartListaNyomtat_Click( object sender, RoutedEventArgs e ) {
            if( chStartlistaNevezesi.IsChecked.Equals( true ) ) {
                ( new Startlista_Nyomtatas( DokumentumTipus.Startlista.NevezesiLista, versenyAzonosito: cbstartListaVersenyAzonosito.Text ) ).ShowDialog( );
            }
            if( chStartlistaCsapat.IsChecked.Equals( true ) ) {
                ( new Startlista_Nyomtatas( DokumentumTipus.Startlista.CsapatLista, cbstartListaVersenyAzonosito.Text ) ).ShowDialog( );
            }
            if( chStartlistaMegjelent.IsChecked.Equals( true ) ) {
                ( new Startlista_Nyomtatas( DokumentumTipus.Startlista.HianyzokLista, cbstartListaVersenyAzonosito.Text ) ).ShowDialog( );
            }
        }
        #endregion

        #region EredmenyLapok

        private void btneredmenylapNyomtat_Click( object sender, RoutedEventArgs e ) {
            // ha nincs kivalasztva, hogy verseny/versenysorozat
            if( cheredmenylapVerseny.IsChecked == false && cheredmenylapVersenysorozat.IsChecked == false ) {
                return;
            }
            // ha verseny van
            if( cheredmenylapVerseny.IsChecked == true ) {
                if( string.IsNullOrEmpty( cberedmenylapVersenyAzonosito.Text ) ) {
                    return;
                }
            }
            if( cheredmenylapVersenysorozat.IsChecked == true ) {
                if( string.IsNullOrEmpty( cberedmenylapVersenysorozatAzonosito.Text ) ) {
                    return;
                }
            }

            if( cheredmenylapTeljes.IsChecked == false && cheredmenylapMisz.IsChecked == false &&
                    cheredmenylapEgyesulet.IsChecked == false && cheredmenylapReszletes.IsChecked == false ) {
                return;
            }

            var tipus = "";
            if( cheredmenylapVerseny.IsChecked == true ) {
                if( cheredmenylapTeljes.IsChecked == true ) {
                    tipus = DokumentumTipus.Eredmenylap.Verseny.Teljes;
                }
                if( cheredmenylapMisz.IsChecked == true ) {
                    tipus = DokumentumTipus.Eredmenylap.Verseny.MISZ;
                }
                if( cheredmenylapEgyesulet.IsChecked == true ) {
                    tipus = DokumentumTipus.Eredmenylap.Verseny.Egyesulet;
                }
                if( cheredmenylapReszletes.IsChecked == true ) {
                    tipus = DokumentumTipus.Eredmenylap.Verseny.Reszletes;
                }
            }
            else if( cheredmenylapVersenysorozat.IsChecked == true ) {
                if( cheredmenylapTeljes.IsChecked == true ) {
                    tipus = DokumentumTipus.Eredmenylap.VersenySorozat.Teljes;
                }
                if( cheredmenylapMisz.IsChecked == true ) {
                    tipus = DokumentumTipus.Eredmenylap.VersenySorozat.MISZ;
                }
                if( cheredmenylapEgyesulet.IsChecked == true ) {
                    tipus = DokumentumTipus.Eredmenylap.VersenySorozat.Egyesulet;
                }
                if( cheredmenylapReszletes.IsChecked == true ) {
                    tipus = DokumentumTipus.Eredmenylap.VersenySorozat.Reszletes;
                }
            }

            ( new Megjelenites.Eredmenylap.Eredmenylap_Nyomtatas( tipus, cberedmenylapVersenyAzonosito.Text ) ).Show( );
        }

        #endregion

        #region Oklevel
        private void btnSablonTorles_Click( object sender, RoutedEventArgs e ) {
            var sablon = SablonGrid.SelectedItem as Sablon;

            if( sablon != null ) ( new Sablon_Torles( sablon.Azonosito ) ).ShowDialog( );
        }

        private void btnSablonHozzaadas_Click( object sender, RoutedEventArgs e ) {
            throw new NotImplementedException( );
        }

        private void btnSablonTorles_Click_1( object sender, RoutedEventArgs e ) {
            throw new NotImplementedException( );
        }

        private void btnOSablonHozzaadas_Click( object sender, RoutedEventArgs e ) {
            ( new Sablon_Hozzaadas_Modositas( ) ).ShowDialog( );
        }

        private void btnOklevelNyomtatas_Click( object sender, RoutedEventArgs e ) {
            throw new NotImplementedException( );
        }

        private void Sablon_Modositas( object sender, MouseButtonEventArgs e ) {
            var dataGridRow = sender as DataGridRow;
            var sablon1 = dataGridRow?.DataContext as Sablon;
            if( sablon1 != null ) {
                var azonosito = sablon1.Azonosito;

                foreach( var sablon in Data.Sablonok._sablonok.Where( sablon => sablon.Azonosito.Equals( azonosito ) ) ) {
                    ( new Sablon_Hozzaadas_Modositas( sablon ) ).ShowDialog( );
                    return;
                }
            }
        }

        #endregion

        #endregion

        #region ComboBox EventHandlers

        private void cboVerseny_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
            KorosztalyGrid.ItemsSource = null;
            var verseny = cboVerseny.SelectedItem as Verseny;
            if( verseny != null ) {
                foreach( var versenykorosztalyok in Data.Korosztalyok._versenyKorosztalyok.Where( versenykorosztalyok => versenykorosztalyok.VersenyAzonosito.Equals( verseny.Azonosito ) ) ) {
                    KorosztalyGrid.ItemsSource = versenykorosztalyok.Korosztalyok;
                    KorosztalyGrid.Items.SortDescriptions.Add( new SortDescription( KorosztalyGrid.Columns.First( ).SortMemberPath, ListSortDirection.Ascending ) );
                    return;
                }
            }
        }

        private void CbstartListaVersenyAzonosito_OnSelectionChanged( object sender, SelectionChangedEventArgs e ) {
            var verseny = (((ComboBox) sender).SelectedItem) as Verseny;
            if( verseny != null )
                txtstartListaVersenyMegnevezes.Text = verseny.Megnevezes;
        }

        private void CberedmenylapVersenyAzonosito_OnSelectionChanged( object sender, SelectionChangedEventArgs e ) {
            var verseny = (((ComboBox) sender).SelectedItem) as Verseny;
            if( verseny != null ) {
                txteredmenylapVersenyMegnevezes.Text = verseny.Megnevezes;
            }
        }

        private void CberedmenylapVersenysorozatAzonosito_OnSelectionChanged( object sender, SelectionChangedEventArgs e ) {
            var versenysorozat = (((ComboBox) sender).SelectedItem) as Versenysorozat;
            if( versenysorozat != null )
                txteredmenylapVersenysorozatMegnevezes.Text =
                    versenysorozat.Megnevezes;
        }

        private void CboOklevelVeAzonosito_OnSelectionChanged( object sender, SelectionChangedEventArgs e ) {
            var verseny = (((ComboBox) sender).SelectedItem) as Verseny;
            if( verseny != null )
                txtOklevelVeMegnevezes.Text = verseny.Megnevezes;
        }

        private void CboOklevelVsAzonosito_OnSelectionChanged( object sender, SelectionChangedEventArgs e ) {
            var versenysorozat = (((ComboBox) sender).SelectedItem) as Versenysorozat;
            if( versenysorozat != null )
                txtOklevelVsMegnevezes.Text = versenysorozat.Megnevezes;
        }
        #endregion

        #region TextBox EventHandlers
        private void TxtEredmenySorszam_OnTextChanged( object sender, TextChangedEventArgs e ) {
            if( cboEredmenyVerseny.SelectedItem == null ) {
                return;
            }
            int temp;
            if( Int32.TryParse( ( sender as TextBox ).Text, out temp ) ) {
                foreach( var item in EredmenyGrid.Items ) {
                    var q = item as Eredmeny;
                    if( q != null && q.Sorszam.ToString( ).Equals( txtEredmenySorszam.Text ) ) {
                        EredmenyGrid.SelectedItem = q;
                        EredmenyGrid.ScrollIntoView( q );
                    }
                }
            }
        }
        private void TxtEredmenySorszam_OnKeyDown( object sender, KeyEventArgs e ) {
            if( e.Key != Key.Enter ) {
                return;
            }
            var eredmeny = EredmenyGrid.SelectedItem as Eredmeny;
            if( eredmeny == null ) {
                return;
            }

            ( new Eredmeny_Hozzaadas_Modositas( eredmeny ) ).Show( );
        }
        private void TxtInduloNev_OnTextChanged( object sender, TextChangedEventArgs e ) {
            if( InduloGrid.Items.Count.Equals( 0 ) ) {
                return;
            }

            foreach( var induloitem in InduloGrid.Items ) {
                int talalt = 0;
                var indulo = induloitem as Indulo;
                for( int i = 0; i < txtInduloNev.Text.Length; i++ ) {
                    if( indulo != null && indulo.Nev.Length < txtInduloNev.Text.Length ) {
                        break;
                    }
                    if( indulo.Nev[i].ToString( ).ToLower( ) == txtInduloNev.Text[i].ToString( ).ToLower( ) ) {
                        talalt++;
                    }
                }
                if( talalt.Equals( txtInduloNev.Text.Length ) ) {
                    InduloGrid.SelectedItem = induloitem;
                    InduloGrid.ScrollIntoView( induloitem );
                    return;
                }
            }
        }
        #endregion

        #region CheckBox EventHandlers
        private void StartlistaTipus_Click( object sender, RoutedEventArgs e ) {
            if( string.IsNullOrEmpty( cbstartListaVersenyAzonosito.Text ) ) {
                chStartlistaCsapat.IsChecked = false;
                chStartlistaMegjelent.IsChecked = false;
                chStartlistaNevezesi.IsChecked = false;
                return;
            }

            var aktiv = sender as CheckBox;

            if( aktiv.Equals( chStartlistaCsapat ) ) {
                chStartlistaCsapat.IsChecked = true;
                chStartlistaMegjelent.IsChecked = false;
                chStartlistaNevezesi.IsChecked = false;
            }
            else if( aktiv.Equals( chStartlistaMegjelent ) ) {
                chStartlistaMegjelent.IsChecked = true;
                chStartlistaCsapat.IsChecked = false;
                chStartlistaNevezesi.IsChecked = false;

            }
            else if( aktiv.Equals( chStartlistaNevezesi ) ) {
                chStartlistaNevezesi.IsChecked = true;
                chStartlistaCsapat.IsChecked = false;
                chStartlistaMegjelent.IsChecked = false;
            }
        }

        private void CheredmenylapVerseny_OnClick( object sender, RoutedEventArgs e ) {
            var aktiv = sender as CheckBox;
            if( aktiv == null ) {
                return;
            }

            if( aktiv.Equals( cheredmenylapVerseny ) ) {
                cheredmenylapVerseny.IsChecked = true;
                cheredmenylapVersenysorozat.IsChecked = false;

                cberedmenylapVersenyAzonosito.IsEnabled = true;
                cberedmenylapVersenysorozatAzonosito.IsEnabled = false;
                cberedmenylapVersenysorozatAzonosito.SelectedIndex = -1;
                txteredmenylapVersenysorozatMegnevezes.Text = "";
            }
            else if( aktiv.Equals( cheredmenylapVersenysorozat ) ) {
                cheredmenylapVersenysorozat.IsChecked = true;
                cheredmenylapVerseny.IsChecked = false;

                cberedmenylapVersenysorozatAzonosito.IsEnabled = true;
                cberedmenylapVersenyAzonosito.IsEnabled = false;
                cberedmenylapVersenyAzonosito.SelectedIndex = -1;
                txteredmenylapVersenyMegnevezes.Text = "";
            }
        }

        private void CheredmenylapTeljes_OnClick( object sender, RoutedEventArgs e ) {
            var aktiv = sender as CheckBox;
            if( aktiv == null ) {
                return;
            }

            if( aktiv.Equals( cheredmenylapTeljes ) ) {
                cheredmenylapTeljes.IsChecked = true;
                cheredmenylapMisz.IsChecked = false;
                cheredmenylapEgyesulet.IsChecked = false;
                cheredmenylapReszletes.IsChecked = false;
            }
            else if( aktiv.Equals( cheredmenylapMisz ) ) {
                cheredmenylapMisz.IsChecked = true;
                cheredmenylapTeljes.IsChecked = false;
                cheredmenylapEgyesulet.IsChecked = false;
                cheredmenylapReszletes.IsChecked = false;
            }
            else if( aktiv.Equals( cheredmenylapEgyesulet ) ) {
                cheredmenylapEgyesulet.IsChecked = true;
                cheredmenylapTeljes.IsChecked = false;
                cheredmenylapMisz.IsChecked = false;
                cheredmenylapReszletes.IsChecked = false;
            }
            else if( aktiv.Equals( cheredmenylapReszletes ) ) {
                cheredmenylapReszletes.IsChecked = true;
                cheredmenylapTeljes.IsChecked = false;
                cheredmenylapMisz.IsChecked = false;
                cheredmenylapEgyesulet.IsChecked = false;
            }
        }
        #endregion
    }
}