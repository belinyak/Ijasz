using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
                    break;
                case DokumentumTipus.Eredmenylap.Verseny.Reszletes:
                    break;
                case DokumentumTipus.Eredmenylap.Verseny.MISZ:
                    break;
                case DokumentumTipus.Eredmenylap.Verseny.Egyesulet:
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
            throw new NotImplementedException( );
        }

        private void NemButton_OnClick( object sender, RoutedEventArgs e ) {
            Close( );
        }
    }
}
