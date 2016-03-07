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

namespace Ijasz2.Megjelenites.Beirolap {
    /// <summary>
    /// Interaction logic for Beirolap_Nyomtatas.xaml
    /// </summary>
    public partial class Beirolap_Nyomtatas {
        private Model.Eredmeny.Eredmeny _eredmeny;
        public Beirolap_Nyomtatas( Model.Eredmeny.Eredmeny eredmeny ) {
            InitializeComponent( );
            _eredmeny = eredmeny;
        }

        private void IgenButton_OnClick( object sender, RoutedEventArgs e ) {
            ( new Nyomtatas.Beirolap.Beirolap( _eredmeny ) ).Print( );
            Close( );
        }

        private void NemButton_OnClick( object sender, RoutedEventArgs e ) {
            Close( );
        }

        private void MegnyitasButton_OnClick( object sender, RoutedEventArgs e ) {
            ( new Nyomtatas.Beirolap.Beirolap(_eredmeny ) ).Open( );
            Close();
        }
    }
}
