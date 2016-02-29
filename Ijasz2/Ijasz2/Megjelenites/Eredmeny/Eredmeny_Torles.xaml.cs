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

namespace Ijasz2.Megjelenites.Eredmeny {
    /// <summary>
    /// Interaction logic for Eredmeny_Torles.xaml
    /// </summary>
    public partial class Eredmeny_Torles : Window {
        private readonly Model.Eredmeny.Eredmeny _eredmeny;
        public Eredmeny_Torles( Model.Eredmeny.Eredmeny eredmeny ) {
            InitializeComponent( );
            _eredmeny = eredmeny;
            lblKerdes.Content += Environment.NewLine + "Név: " + _eredmeny.Indulo;
        }

        private void BtnIgen_OnClick( object sender, RoutedEventArgs e ) {
            foreach( var versenyEredmeny in Model.Data.Data.Eredmenyek._versenyEredmenyek ) {
                if( versenyEredmeny.VersenyAzonosito.Equals( _eredmeny.Verseny ) ) {
                    versenyEredmeny.Eredmenyek.Remove( _eredmeny );
                    Close( );
                    return;
                }
            }
        }

        private void btnNem_Click( object sender, RoutedEventArgs e ) {
            Close( );
        }
    }
}
