using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ijasz2.Megjelenites.Eredmeny {
    /// <summary>
    /// Interaction logic for Eredmeny_Hozzaadas_Modositas.xaml
    /// </summary>
    public partial class Eredmeny_Hozzaadas_Modositas : Window {
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
        }

        /// <summary> |
        /// meg kell nezni, hogy minden talalat ures vagy valid int(nem negativ), osszeadni a lovesek szamat | 
        /// </summary>
        /// <returns></returns>
        private bool IsValid( ) {
            bool valid = true;

            txtTiz.ClearValue( Border.BorderBrushProperty );
            txtNyolc.ClearValue( Border.BorderBrushProperty );
            txtOt.ClearValue( Border.BorderBrushProperty );
            txtMelle.ClearValue( Border.BorderBrushProperty );

            try { Convert.ToInt32( txtTiz.Text ); } catch { txtTiz.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
            try { Convert.ToInt32( txtNyolc.Text ); } catch { txtNyolc.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
            try { Convert.ToInt32( txtOt.Text ); } catch { txtOt.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
            try { Convert.ToInt32( txtMelle.Text ); } catch { txtMelle.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

            if( valid ) {
                valid = IsPontszamSzumValid( );
            }
            return valid;
        }

        private bool IsPontszamSzumValid( ) {
            bool valid = true;

            foreach( var verseny in Model.Data.Data.Versenyek._versenyek ) {
                if( verseny.Azonosito.Equals( _eredmeny.Verseny ) ) {
                    var tizPont = Convert.ToInt32(txtTiz.Text);
                    var nyolcPont = Convert.ToInt32(txtNyolc.Text);
                    var otPont = Convert.ToInt32(txtOt.Text);
                    var melle = Convert.ToInt32(txtMelle.Text);
                    var osszPont = (tizPont + nyolcPont + otPont + melle);

                    if( osszPont != verseny.Osszes ) {
                        valid = false;
                        MessageBox.Show( "Lövések: " + ( verseny.Osszes ).ToString( ) + Environment.NewLine +
                            "Beírt lövések: " + osszPont.ToString( ) + Environment.NewLine +
                            "Hiányzó lövések: " + ( verseny.Osszes - osszPont ),
                            "Nem megfelelő a lövések száma!",
                            MessageBoxButton.OK, MessageBoxImage.Warning );
                    }
                    return valid;
                }
            }
            return valid;
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

            foreach( var verseny in Model.Data.Data.Versenyek._versenyek ) {
                if( verseny.Azonosito.Equals( _eredmeny.Verseny ) ) {
                    _eredmeny.Szazalek = (int)( _eredmeny.OsszPont / ( verseny.Osszes / 10.0f ) );
                    break;
                }
            }

            foreach( var versenyEredmeny in Model.Data.Data.Eredmenyek._versenyEredmenyek ) {
                if( versenyEredmeny.VersenyAzonosito.Equals( _eredmeny.Verseny ) ) {
                    versenyEredmeny.Eredmenyek.Update( _eredmeny );
                    break;
                }
            }

            Close( );
        }
    }
}
