using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Ijasz2.Model.Egyesulet;

namespace Ijasz2.Megjelenites.Egyesület {
    /// <summary>
    /// Interaction logic for Egyesulet_Tagok.xaml
    /// </summary>
    public partial class Egyesulet_Tagok {
        private readonly Egyesulet _egyesulet;
        public Egyesulet_Tagok( Egyesulet egyesulet ) {
            _egyesulet = egyesulet;
            InitializeComponent( );
            InitializeContent( egyesulet );
        }

        private void InitializeContent( Egyesulet egyesulet ) {

            cboEgyesuletTagokVerseny.ItemsSource = Model.Data.Data.Versenyek._versenyek;

        }

        /// <summary>
        /// TODO ha nincs kiválasztva, akkor maz összeset mutassa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboEgyesuletTagokVerseny_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
            EgyesuletTagokGrid.ItemsSource = null;

            List<Model.Egyesulet.Egyesulet_Tagok> egyesuletIndulok = new List<Model.Egyesulet.Egyesulet_Tagok>();
            foreach( var indulo in Model.Data.Data.Indulok._indulok.Where( indulo => indulo.Egyesulet.Equals( _egyesulet.Azonosito ) ) ) {
                foreach( var eredmenyek in Model.Data.Data.Eredmenyek._versenyEredmenyek.Where( eredmeny => {
                    var verseny = cboEgyesuletTagokVerseny.SelectedItem as Model.Verseny.Verseny;
                    return verseny != null && eredmeny.VersenyAzonosito.Equals( verseny.Azonosito );
                } ) ) {
                    foreach( var eredmeny in eredmenyek.Eredmenyek._eredmenyek ) {
                        if( eredmeny.Indulo.Equals( indulo.Nev ) ) {
                            egyesuletIndulok.Add( new Model.Egyesulet.Egyesulet_Tagok {
                                Indulo = eredmeny.Indulo,
                                Nem = indulo.Nem,
                                Megjelent = eredmeny.Megjelent,
                                Kor = eredmeny.Kor
                            } );
                        }
                    }
                }
            }
            EgyesuletTagokGrid.ItemsSource = egyesuletIndulok;
            EgyesuletTagokGrid.Items.SortDescriptions.Add( new SortDescription( EgyesuletTagokGrid.Columns[2].SortMemberPath, ListSortDirection.Ascending ) );
        }

        private void BtnEgysuletTagokClear_OnClick( object sender, RoutedEventArgs e ) {
            cboEgyesuletTagokVerseny.SelectedIndex = -1;
        }
    }
}
