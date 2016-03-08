using System.Windows;

namespace Ijasz2.Megjelenites.Beirolap {
    /// <summary>
    /// Interaction logic for Beirolap_Nyomtatas.xaml
    /// </summary>
    public partial class Beirolap_Nyomtatas {
        private Model.Eredmeny.Eredmeny _eredmeny;
        private bool _duplaBeirolap;
        public Beirolap_Nyomtatas( Model.Eredmeny.Eredmeny eredmeny, bool duplaBeirolap ) {
            InitializeComponent( );
            _eredmeny = eredmeny;
            _duplaBeirolap = duplaBeirolap;
        }

        private void IgenButton_OnClick( object sender, RoutedEventArgs e ) {
            var beiroLap = new Nyomtatas.Beirolap.Beirolap(_eredmeny);
            if( _duplaBeirolap ) {
                beiroLap.Print( );
                beiroLap.Print( );
            }
            else {
                beiroLap.Print( );
            }
            Close( );
        }

        private void NemButton_OnClick( object sender, RoutedEventArgs e ) {
            Close( );
        }

        private void MegnyitasButton_OnClick( object sender, RoutedEventArgs e ) {
            ( new Nyomtatas.Beirolap.Beirolap( _eredmeny ) ).Open( );
        }
    }
}
