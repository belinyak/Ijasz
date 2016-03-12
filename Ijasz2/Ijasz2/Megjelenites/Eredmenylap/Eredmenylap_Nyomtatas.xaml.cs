using System;
using System.Windows;
using Ijasz2.Nyomtatas.Seged;

namespace Ijasz2.Megjelenites.Eredmenylap {
    /// <summary>
    /// Interaction logic for Eredmenylap_Nyomtatas.xaml
    /// </summary>
    public partial class Eredmenylap_Nyomtatas {
        private readonly string _azonosito;
        private readonly string _dokumentumTipus;
        public Eredmenylap_Nyomtatas( string tipus, string azonosito ) {
            InitializeComponent( );
            _azonosito = azonosito;
            _dokumentumTipus = tipus;
        }

        private void MegnyitasButton_OnClick( object sender, RoutedEventArgs e ) {
            switch( _dokumentumTipus ) {
                case DokumentumTipus.Eredmenylap.Verseny.Teljes:
                    new Nyomtatas.Eredmenylap.VersenyEredmenyLap( _dokumentumTipus, _azonosito ).Open( );
                    break;
                case DokumentumTipus.Eredmenylap.Verseny.Reszletes:
                    break;
                case DokumentumTipus.Eredmenylap.Verseny.MISZ:
                    new Nyomtatas.Eredmenylap.VersenyEredmenyLap( _dokumentumTipus, _azonosito ).Open( );
                    break;
                case DokumentumTipus.Eredmenylap.Verseny.Egyesulet:
                    new Nyomtatas.Eredmenylap.VersenyEredmenyLapEgyesulet(_azonosito);
                    break;
                case DokumentumTipus.Eredmenylap.VersenySorozat.Teljes:
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
            new Nyomtatas.Eredmenylap.VersenyEredmenyLap( _dokumentumTipus, _azonosito ).Print( );

            throw new NotImplementedException( );
        }

        private void NemButton_OnClick( object sender, RoutedEventArgs e ) {
            Close( );
        }
    }
}
