using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Ijasz2.Model.Data;

namespace Ijasz2.Megjelenites.Eredmeny {
    /// <summary>
    ///     Interaction logic for Eredmeny_Hozzaadas_Modositas.xaml
    /// </summary>
    public partial class Eredmeny_Hozzaadas_Modositas {
        private readonly Model.Eredmeny.Eredmeny _eredmeny;

        public Eredmeny_Hozzaadas_Modositas( Model.Eredmeny.Eredmeny eredmeny ) {
            _eredmeny = eredmeny;
            InitializeComponent( );
            InitializeContent( _eredmeny );
        }

        private void InitializeContent( Model.Eredmeny.Eredmeny eredmeny ) {
            txtNev.Text = eredmeny.Indulo;
            txtNev.IsEnabled = false;
            txtIjtipus.Text = eredmeny.Ijtipus;
            txtIjtipus.IsEnabled = false;
            txtCsapat.Text = eredmeny.Csapat.ToString( );
            txtCsapat.IsEnabled = false;
            chMegjelent.IsChecked = eredmeny.Megjelent;
            chMegjelent.IsEnabled = false;
            txtTiz.Text = eredmeny.Talalat10.ToString( );
            txtNyolc.Text = eredmeny.Talalat8.ToString( );
            txtOt.Text = eredmeny.Talalat5.ToString( );
            txtMelle.Text = eredmeny.Melle.ToString( );
            txtOsszes.Text = eredmeny.OsszPont.ToString( );
            txtOsszes.IsEnabled = false;
            txtEredmeny.Text = eredmeny.Szazalek.ToString( );
            txtEredmeny.IsEnabled = false;

            txtTiz.TextChanged += EredmenySzamolas;
            txtNyolc.TextChanged += EredmenySzamolas;
            txtOt.TextChanged += EredmenySzamolas;
            txtMelle.TextChanged += EredmenySzamolas;

            txtTiz.GotFocus += TxtTizOnGotFocus;
            txtNyolc.GotFocus += TxtNyolcOnGotFocus;
            txtOt.GotFocus += TxtOtOnGotFocus;
            txtMelle.GotFocus += TxtMelleOnGotFocus;
        }

        #region Talalatok EventHandlers
        private void TxtTizOnGotFocus( object sender, RoutedEventArgs routedEventArgs ) {
            txtTiz.SelectAll( );
        }
        private void TxtNyolcOnGotFocus( object sender, RoutedEventArgs routedEventArgs ) {
            txtNyolc.SelectAll( );
        }
        private void TxtOtOnGotFocus( object sender, RoutedEventArgs routedEventArgs ) {
            txtOt.SelectAll( );
        }
        private void TxtMelleOnGotFocus( object sender, RoutedEventArgs routedEventArgs ) {
            txtMelle.SelectAll( );
        }

        private void EredmenySzamolas( object sender, TextChangedEventArgs textChangedEventArgs ) {
            int találat_10;
            try { találat_10 = Convert.ToInt32( txtTiz.Text ); if( találat_10 < 0 ) { return; } } catch { return; }
            int találat_8;
            try { találat_8 = Convert.ToInt32( txtNyolc.Text ); if( találat_8 < 0 ) { return; } } catch { return; }
            int találat_5;
            try { találat_5 = Convert.ToInt32( txtOt.Text ); if( találat_5 < 0 ) { return; } } catch { return; }
            int találat_mellé;
            try { találat_mellé = Convert.ToInt32( txtMelle.Text ); if( találat_mellé < 0 ) { return; } } catch { return; }

            txtOsszes.Text = ( találat_10 * 10 + találat_8 * 8 + találat_5 * 5 ).ToString( );

            // TODO ezt sem kéne mindig lekérni, hanem átadni
            var versenyOsszPont = (from verseny in Model.Data.Data.Versenyek._versenyek
                                   where verseny.Azonosito.Equals(_eredmeny.Verseny)
                                   select verseny.Osszes).First();

            txtEredmeny.Text = ( (int)( ( (double)Convert.ToInt32( txtOsszes.Text ) / ( versenyOsszPont * 10 ) ) * 100 ) ).ToString( ) + "%"; return;

        }
        #endregion

        /// <summary>
        ///     
        /// | meg kell nezni, hogy minden talalat ures vagy valid int(nem negativ), osszeadni a lovesek szamat |
        /// </summary>
        /// <returns></returns>
        private bool IsValid( ) {
            var valid = true;

            txtTiz.ClearValue( Border.BorderBrushProperty );
            txtNyolc.ClearValue( Border.BorderBrushProperty );
            txtOt.ClearValue( Border.BorderBrushProperty );
            txtMelle.ClearValue( Border.BorderBrushProperty );

            int temp;
            if( !Int32.TryParse( txtTiz.Text, out temp ) ) {
                txtTiz.BorderBrush = new SolidColorBrush( Colors.Red );
                valid = false;
            }
            if( !Int32.TryParse( txtNyolc.Text, out temp ) ) {
                txtNyolc.BorderBrush = new SolidColorBrush( Colors.Red );
                valid = false;
            }
            if( !Int32.TryParse( txtOt.Text, out temp ) ) {
                txtOt.BorderBrush = new SolidColorBrush( Colors.Red );
                valid = false;
            }
            if( !Int32.TryParse( txtMelle.Text, out temp ) ) {
                txtMelle.BorderBrush = new SolidColorBrush( Colors.Red );
                valid = false;
            }

            if( valid ) {
                valid = IsPontszamSzumValid( );
            }
            return valid;
        }

        private bool IsPontszamSzumValid( ) {
            var valid = true;

            foreach( var verseny in Data.Versenyek._versenyek ) {
                if( verseny.Azonosito.Equals( _eredmeny.Verseny ) ) {
                    var tizPont = Convert.ToInt32(txtTiz.Text);
                    var nyolcPont = Convert.ToInt32(txtNyolc.Text);
                    var otPont = Convert.ToInt32(txtOt.Text);
                    var melle = Convert.ToInt32(txtMelle.Text);
                    var osszPont = (tizPont + nyolcPont + otPont + melle);

                    if( osszPont != verseny.Osszes ) {
                        valid = false;
                        MessageBox.Show( "Lövések: " + ( verseny.Osszes ) + Environment.NewLine +
                                        "Beírt lövések: " + osszPont + Environment.NewLine +
                                        "Hiányzó lövések: " + ( verseny.Osszes - osszPont ),
                            "Nem megfelelő a lövések száma!",
                            MessageBoxButton.OK, MessageBoxImage.Warning );
                    }
                    return valid;
                }
            }
            return true;
        }

        private void btnRendben_Click( object sender, RoutedEventArgs e ) {
            if( IsValid( ) == false ) {
                return;
            }

            _eredmeny.Talalat10 = Convert.ToInt32( txtTiz.Text );
            _eredmeny.Talalat8 = Convert.ToInt32( txtNyolc.Text );
            _eredmeny.Talalat5 = Convert.ToInt32( txtOt.Text );
            _eredmeny.Melle = Convert.ToInt32( txtMelle.Text );
            _eredmeny.OsszPont = ( _eredmeny.Talalat10 * 10 + _eredmeny.Talalat8 * 8 + _eredmeny.Talalat5 * 5 );
            _eredmeny.Szazalek = Convert.ToInt32(txtEredmeny.Text.Replace("%", ""));

            foreach( var verseny in Data.Versenyek._versenyek.Where( verseny => verseny.Azonosito.Equals( _eredmeny.Verseny ) ) ) {
                _eredmeny.Szazalek = (int)( _eredmeny.OsszPont / ( verseny.Osszes / 10.0f ) );
                break;
            }

            foreach( var versenyEredmeny in Data.Eredmenyek._versenyEredmenyek.Where( versenyEredmeny => versenyEredmeny.VersenyAzonosito.Equals( _eredmeny.Verseny ) ) ) {
                versenyEredmeny.Eredmenyek.Update( _eredmeny );
                break;
            }

            Close( );
        }
    }
}