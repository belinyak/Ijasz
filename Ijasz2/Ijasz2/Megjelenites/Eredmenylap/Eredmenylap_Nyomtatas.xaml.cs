using System;
using System.Windows;
using Ijasz2.Nyomtatas.Seged;

namespace Ijasz2.Megjelenites.Eredmenylap {
    /// <summary>
    /// Interaction logic for Eredmenylap_Nyomtatas.xaml
    /// </summary>
    public partial class Eredmenylap_Nyomtatas {
        private string Azonosito { get; set; }
        private string _dokumentumTipus { get; set; }
        public Eredmenylap_Nyomtatas( string tipus, string azonosito ) {
            InitializeComponent( );
            Azonosito = azonosito;
            _dokumentumTipus = tipus;
        }

        private void MegnyitasButton_OnClick( object sender, RoutedEventArgs e ) {
            switch( _dokumentumTipus ) {
                //verseny
                case DokumentumTipus.Eredmenylap.Verseny.Teljes:
                    new Nyomtatas.Eredmenylap.VersenyEredmenyLap( _dokumentumTipus, Azonosito ).Open( );
                    break;
                case DokumentumTipus.Eredmenylap.Verseny.Reszletes:
                    break;
                case DokumentumTipus.Eredmenylap.Verseny.MISZ:
                    new Nyomtatas.Eredmenylap.VersenyEredmenyLap( _dokumentumTipus, Azonosito ).Open( );
                    break;
                case DokumentumTipus.Eredmenylap.Verseny.Egyesulet:
                    new Nyomtatas.Eredmenylap.VersenyEredmenyLapEgyesulet( Azonosito ).Open( );
                    break;
                //versenysorozat
                case DokumentumTipus.Eredmenylap.VersenySorozat.Teljes:
                    new Nyomtatas.Eredmenylap.VersenysorozatEredmenyLap( Azonosito ).Open( );
                    break;
                case DokumentumTipus.Eredmenylap.VersenySorozat.Reszletes:
                    break;
                case DokumentumTipus.Eredmenylap.VersenySorozat.MISZ:
                    break;
                case DokumentumTipus.Eredmenylap.VersenySorozat.Egyesulet:
                    break;
                default:
                    throw new ArgumentOutOfRangeException( );
            }
        }
        private void IgenButton_OnClick( object sender, RoutedEventArgs e ) {
            new Nyomtatas.Eredmenylap.VersenyEredmenyLap( _dokumentumTipus, Azonosito ).Print( );

            throw new NotImplementedException( );
        }

        private void NemButton_OnClick( object sender, RoutedEventArgs e ) {
            Close( );
        }
    }
}
