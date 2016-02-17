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
    /// Interaction logic for Eredmeny_Hozzaadas_Modositas.xaml
    /// </summary>
    public partial class Eredmeny_Hozzaadas_Modositas : Window {
        private readonly Model.Eredmeny.Eredmeny _eredmeny;

        public Eredmeny_Hozzaadas_Modositas( Model.Eredmeny.Eredmeny eredmeny ) {
            _eredmeny = eredmeny;
            InitializeComponent( );
            InitializeContent(_eredmeny);
        }

        private void InitializeContent( Model.Eredmeny.Eredmeny eredmeny ) {
            txtNev.Text = eredmeny.Indulo;
            txtNev.IsEnabled = false;
            txtIjtipus.Text = eredmeny.Ijtipus;
            txtIjtipus.IsEnabled = false;
            txtCsapat.Text = eredmeny.Csapat.ToString();
            txtCsapat.IsEnabled = false;
            chMegjelent.IsChecked = eredmeny.Megjelent;
            chMegjelent.IsEnabled = false;
            txtTiz.Text = eredmeny.Talalat10.ToString();
            txtNyolc.Text = eredmeny.Talalat8.ToString();
            txtOt.Text = eredmeny.Talalat5.ToString();
            txtMelle.Text = eredmeny.Melle.ToString();
            txtOsszes.Text = eredmeny.OsszPont.ToString();
            txtEredmeny.Text = eredmeny.Szazalek.ToString();
        }
    }
}
