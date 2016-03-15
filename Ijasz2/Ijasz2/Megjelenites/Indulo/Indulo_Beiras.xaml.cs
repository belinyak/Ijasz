using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Ijasz2.Megjelenites.Korosztaly;
using Ijasz2.Model.Data;

namespace Ijasz2.Megjelenites.Indulo {

    /// <summary>
    /// meg kell nezni, hogy mar be van-e írva, ha igen elotolteni a korosztalyt
    /// </summary>
    public partial class Indulo_Beiras {
        private readonly Model.Indulo.Indulo _indulo;
        private static int utolsoSelectedVersenyIndex = -1;

        public Indulo_Beiras( Model.Indulo.Indulo indulo ) {
            _indulo = indulo;
            InitializeComponent( );
            InitializeContent( _indulo );
        }

        private void InitializeContent( Model.Indulo.Indulo indulo ) {
            var csapatok = new ObservableCollection<int>();
            for( var i = 1; i < 46; i++ ) {
                csapatok.Add( i );
            }
            cbCsapat.ItemsSource = csapatok;

            cbIjtipus.ItemsSource = Data.Ijtipusok._ijtipusok;
            cbVerseny.ItemsSource = Data.Versenyek._versenyek;

            if( utolsoSelectedVersenyIndex.Equals( -1 ) ) {
                cbVerseny.SelectedIndex = 0;
                utolsoSelectedVersenyIndex = 0;
            }
            else {
                cbVerseny.SelectedIndex = utolsoSelectedVersenyIndex;
            }

            cbUjKorosztaly.IsEnabled = false;

            var verseny = cbVerseny.SelectedItem as Model.Verseny.Verseny;
            if( verseny != null ) {
                var value = Model.Korosztaly.VersenyKorosztaly.InduloBeirasKorosztaly( _indulo, verseny );
                if( value.KorosztalyMessages != null ) {
                    InitializeMessages( value );
                }
                // ha nincs message, akkor kisebb window width
                else {
                    Width = 260;
                }
                // ezt mindig visszaadja, message lehet null
                cbUjKorosztaly.Text = value.KorosztalyAzonosito;
            }

            txtNev.Text = indulo.Nev;
            txtNev.IsEnabled = false;
        }

        private void InitializeMessages( KorosztalyInfo korosztalyInfo ) {
            MessagesTextBlock.Text = "";
            foreach( var korosztalyMessage in korosztalyInfo.KorosztalyMessages ) {
                MessagesTextBlock.Inlines.Add( "Az induló a " );
                MessagesTextBlock.Inlines.Add( new Bold( new Run( korosztalyMessage.VersenysorozatAzonosito ) ) );
                MessagesTextBlock.Inlines.Add( " versenysorozat " );
                MessagesTextBlock.Inlines.Add( new Bold( new Run( korosztalyMessage.VersenyAzonosito ) ) );
                MessagesTextBlock.Inlines.Add( " versenyén" + Environment.NewLine );
                MessagesTextBlock.Inlines.Add( " korosztály felülírással a " );
                MessagesTextBlock.Inlines.Add( new Bold( new Run( korosztalyMessage.KorosztalyAzonosito ) ) );
                MessagesTextBlock.Inlines.Add( " korosztályban szerepelt." + Environment.NewLine + Environment.NewLine );
            }
        }

        private void btnCsapatok_Click( object sender, RoutedEventArgs e ) {
            ( new Indulo_Csapatok( cbVerseny.Text ) ).ShowDialog( );
        }

        private void ChKorosztalyFelulir_OnClick( object sender, RoutedEventArgs e ) {
            if( cbVerseny.SelectedItem == null ) {
                return;
            }
            cbUjKorosztaly.IsEnabled = chKorosztalyFelulir.IsChecked == true;
        }

        /// <summary>
        /// meg kell nezni, hogy ezen a versenyen volt-e beirva, ha igen elotolteni 
        /// mindig lefut, itt kell elotolteni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbVerseny_OnSelectionChanged( object sender, SelectionChangedEventArgs e ) {
            if( cbVerseny.SelectedItem != null ) {
                var currentVerseny = cbVerseny.SelectedItem as Model.Verseny.Verseny;
                cbUjKorosztaly.ItemsSource = null;
                foreach( var versenyKorosztaly in Data.Korosztalyok._versenyKorosztalyok.Where( versenyKorosztaly => currentVerseny != null && versenyKorosztaly.VersenyAzonosito.Equals( currentVerseny.Azonosito ) ) ) {
                    cbUjKorosztaly.ItemsSource = versenyKorosztaly.Korosztalyok;
                    EloTolt( );
                    //return;
                }
                var value = Model.Korosztaly.VersenyKorosztaly.InduloBeirasKorosztaly( _indulo, currentVerseny );
                if( value.KorosztalyMessages != null ) {
                    InitializeMessages( value );
                    this.Width = 590;
                }
                else {
                    this.Width = 260;
                }

                cbUjKorosztaly.Text = value.KorosztalyAzonosito;

            }
        }

        /// <summary>
        /// | ha mar be volt irva akkor mindent elotoltunk |
        /// ha nincs mit elotolteni, akkor clear-elunk |
        /// </summary>
        private void EloTolt( ) {
            cbIjtipus.SelectedIndex = -1;
            cbCsapat.SelectedIndex = -1;
            chKorosztalyFelulir.IsChecked = false;
            cbUjKorosztaly.SelectedIndex = -1;
            cbUjKorosztaly.IsEnabled = false;
            chMegjelent.IsChecked = false;

            foreach( var versenyEredmeny in Data.Eredmenyek._versenyEredmenyek.Where( eredmeny => eredmeny.VersenyAzonosito.Equals( ( (Model.Verseny.Verseny)cbVerseny.SelectedItem ).Azonosito ) ) ) {
                foreach( var eredmeny in versenyEredmeny.Eredmenyek._eredmenyek.Where( eredmeny => eredmeny.Indulo.Equals( _indulo.Nev ) ) ) {
                    cbIjtipus.Text = eredmeny.Ijtipus;
                    cbCsapat.Text = eredmeny.Csapat.ToString( );
                    chKorosztalyFelulir.IsChecked = eredmeny.KorosztalyModositott;
                    cbUjKorosztaly.Text = eredmeny.KorosztalyAzonosito;
                    chMegjelent.IsChecked = eredmeny.Megjelent;
                }
            }
        }

        private bool IsValid( ) {
            var valid = true;

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
        ///     |
        ///     induló beírása |
        ///     TODO korosztaly szamolas |
        ///     TODO eredmenyek novelese |
        ///     TODO SZEBBEN, ha mar letezik akkor modositas nem add |
        ///     betoltott kor szamolas | 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRendben_OnClick( object sender, RoutedEventArgs e ) {
            bool duplaBeirolap = false;

            if( IsValid( ) == false ) {
                return;
            }

            // kell a datum, ha van versenysorozat, akkor az 1. verseny datuma, kulonben verseny datum
            string datum = "";
            foreach(
                var verseny1 in
                    Data.Versenyek._versenyek.Where( verseny => verseny.Azonosito.Equals( cbVerseny.Text ) ) ) {
                if( !string.IsNullOrEmpty( verseny1.Versenysorozat ) ) {
                    datum = ( from verseny in Data.Versenyek._versenyek
                              where verseny.Versenysorozat.Equals( verseny1.Versenysorozat )
                              orderby verseny.Datum ascending
                              select verseny.Datum ).First( );
                }
                else {
                    datum = verseny1.Datum;
                }
                duplaBeirolap = verseny1.DuplaBeirolap;
            }

            utolsoSelectedVersenyIndex = cbVerseny.SelectedIndex;

            // modositas
            foreach( var versenyEredmeny in Data.Eredmenyek._versenyEredmenyek ) {
                if( versenyEredmeny.VersenyAzonosito.Equals( cbVerseny.Text ) ) {
                    foreach( var eredmeny in
                            versenyEredmeny.Eredmenyek._eredmenyek.Where( eredmeny => eredmeny.Indulo.Equals( _indulo.Nev ) )
                        ) {
                        versenyEredmeny.Eredmenyek.Remove( eredmeny );
                        versenyEredmeny.Eredmenyek.Add( new Model.Eredmeny.Eredmeny {
                            Verseny = versenyEredmeny.VersenyAzonosito,
                            Indulo = _indulo.Nev,
                            Ijtipus = cbIjtipus.Text,
                            Csapat = Convert.ToInt32( cbCsapat.Text ),
                            Talalat10 = 0,
                            Talalat8 = 0,
                            Talalat5 = 0,
                            Melle = 0,
                            OsszPont = 0,
                            Szazalek = 0,
                            Megjelent = chMegjelent.IsChecked == true,
                            KorosztalyAzonosito = cbUjKorosztaly.Text,
                            Kor = Data.Korosztalyok.BetoltottKor( datum, _indulo.SzuletesiDatum ),
                            KorosztalyModositott = chKorosztalyFelulir.IsChecked == true,
                        }, _indulo.Nem );

                        // muszaly ujra lekerni a sorszam miatt
                        foreach( var versenyeredmeny in Model.Data.Data.Eredmenyek._versenyEredmenyek.Where( eredmeny2 => eredmeny2.VersenyAzonosito.Equals( cbVerseny.Text ) ) ) {
                            foreach( var eredmeny2 in versenyeredmeny.Eredmenyek._eredmenyek.Where( eredmeny2 => eredmeny2.Indulo.Equals( _indulo.Nev ) ) ) {
                                ( new Megjelenites.Beirolap.Beirolap_Nyomtatas( eredmeny2, duplaBeirolap ) ).ShowDialog( );
                            }
                        }
                        Close( );
                        return;
                    }
                }
            }

            // hozzaadas
            foreach( var versenyEredmeny in Data.Eredmenyek._versenyEredmenyek.Where( versenyEredmeny => versenyEredmeny.VersenyAzonosito.Equals( cbVerseny.Text ) ) ) {
                versenyEredmeny.Eredmenyek.Add( new Model.Eredmeny.Eredmeny {
                    Verseny = versenyEredmeny.VersenyAzonosito,
                    Indulo = _indulo.Nev,
                    Ijtipus = cbIjtipus.Text,
                    Csapat = Convert.ToInt32( cbCsapat.Text ),
                    Talalat10 = 0,
                    Talalat8 = 0,
                    Talalat5 = 0,
                    Melle = 0,
                    OsszPont = 0,
                    Szazalek = 0,
                    Megjelent = chMegjelent.IsChecked == true,
                    KorosztalyAzonosito = cbUjKorosztaly.Text,
                    Kor = Data.Korosztalyok.BetoltottKor( datum, _indulo.SzuletesiDatum ),
                    KorosztalyModositott = chKorosztalyFelulir.IsChecked == true,
                }, _indulo.Nem );

                // muszaly ujra lekerni a sorszam miatt
                foreach( var versenyeredmeny in Model.Data.Data.Eredmenyek._versenyEredmenyek.Where( eredmeny => eredmeny.VersenyAzonosito.Equals( cbVerseny.Text ) ) ) {
                    foreach( var eredmeny in versenyeredmeny.Eredmenyek._eredmenyek.Where( eredmeny => eredmeny.Indulo.Equals( _indulo.Nev ) ) ) {
                        ( new Megjelenites.Beirolap.Beirolap_Nyomtatas( eredmeny, duplaBeirolap ) ).ShowDialog( );
                    }
                }
                Close( );
                return;
            }
        }

        private void TagokButton_OnClick( object sender, RoutedEventArgs e ) {
            if( string.IsNullOrEmpty( cbUjKorosztaly.Text ) ) {
                return;
            }
            ( new Megjelenites.Korosztaly.Korosztaly_Indulok( cbVerseny.Text, cbUjKorosztaly.Text ) ).Show( );
        }
    }
}