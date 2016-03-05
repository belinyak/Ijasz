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
using Ijasz2.Model.Egyesulet;

namespace Ijasz2.Megjelenites.Egyesület {
    /// <summary>
    /// Interaction logic for Egyesulet_Tagok.xaml
    /// </summary>
    public partial class Egyesulet_Tagok : Window {
        private readonly Egyesulet _egyesulet;
        public Egyesulet_Tagok( Model.Egyesulet.Egyesulet egyesulet ) {
            _egyesulet = egyesulet;
            InitializeComponent( );
            InitializeContent( egyesulet );
        }

        private void InitializeContent( Model.Egyesulet.Egyesulet egyesulet ) {

            cboEgyesuletTagokVerseny.ItemsSource = Model.Data.Data.Versenyek._versenyek;

        }
        private void cboEgyesuletTagokVerseny_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
            EgyesuletTagokGrid.ItemsSource = null;
            List<Model.Egyesulet.Egyesulet_Tagok> egyesuletIndulok = new List<Model.Egyesulet.Egyesulet_Tagok>();
            foreach( var indulo in Model.Data.Data.Indulok._indulok.Where( indulo => indulo.Egyesulet.Equals( _egyesulet.Azonosito ) ) ) {
                foreach( var eredmenyek in Model.Data.Data.Eredmenyek._versenyEredmenyek.Where( eredmeny => eredmeny.VersenyAzonosito.Equals( cboEgyesuletTagokVerseny.Text ) ) ) {
                    foreach( var eredmeny in eredmenyek.Eredmenyek._eredmenyek ) {
                        if( eredmeny.Indulo.Equals( indulo.Nev ) ) {
                            egyesuletIndulok.Add( new Model.Egyesulet.Egyesulet_Tagok {
                                Indulo = eredmeny.Indulo,
                                Nem = indulo.Nem,
                                Megjelent = eredmeny.Megjelent,
                            } );
                        }
                    }
                }
            }

            EgyesuletTagokGrid.ItemsSource = egyesuletIndulok;

        }

        private void BtnEgysuletTagokClear_OnClick( object sender, RoutedEventArgs e ) {
            cboEgyesuletTagokVerseny.SelectedIndex = -1;
        }
    }
}
