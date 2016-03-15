using System;
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
            InitializeContent( );
            cboEgyesuletTagokVerseny.SelectedIndex = -1;
        }

        private void InitializeContent( ) {
            var egyesuletIndulok = new List<Model.Egyesulet.Egyesulet_Tagok>();

            cboEgyesuletTagokVerseny.ItemsSource = Model.Data.Data.Versenyek._versenyek;
            foreach( var indulo in Model.Data.Data.Indulok._indulok.Where( indulo => indulo.Egyesulet.Equals( _egyesulet.Azonosito ) ) ) {
                // ha nincs verseny akkor mindenki, szuletesi datum + mai nap alapján számol kort
                egyesuletIndulok.Add( new Model.Egyesulet.Egyesulet_Tagok {
                    Indulo = indulo.Nev,
                    Nem = indulo.Nem,
                    Kor = Model.Data.Data.Korosztalyok.BetoltottKor( DateTime.Now.ToString( ), indulo.SzuletesiDatum ),
                    Megjelent = false
                } );
            }
            EgyesuletTagokGrid.ItemsSource = egyesuletIndulok;
            EgyesuletTagokGrid.Items.SortDescriptions.Add( new SortDescription( EgyesuletTagokGrid.Columns[2].SortMemberPath, ListSortDirection.Ascending ) );
        }

        /// <summary>
        /// TODO ha nincs kiválasztva, akkor maz összeset mutassa
        /// TODO ha nincs kiválasztva, akkor ne mutassa a megjelent oszlopot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboEgyesuletTagokVerseny_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
            EgyesuletTagokGrid.ItemsSource = null;

            var egyesuletIndulok = new List<Model.Egyesulet.Egyesulet_Tagok>();
            var verseny = cboEgyesuletTagokVerseny.SelectedItem as Model.Verseny.Verseny;

            foreach( var indulo in Model.Data.Data.Indulok._indulok.Where( indulo => indulo.Egyesulet.Equals( _egyesulet.Azonosito ) ) ) {
                // ha nincs verseny akkor mindenki, szuletesi datum + mai nap alapján számol kort
                if( verseny == null ) {
                    egyesuletIndulok.Add( new Model.Egyesulet.Egyesulet_Tagok {
                        Indulo = indulo.Nev,
                        Nem = indulo.Nem,
                        Kor = Model.Data.Data.Korosztalyok.BetoltottKor( DateTime.Now.ToString( ), indulo.SzuletesiDatum ),
                        Megjelent = false
                    } );
                }
                else {
                    foreach( var versenyeredmenyek in Model.Data.Data.Eredmenyek._versenyEredmenyek.Where( eredmeny => eredmeny.VersenyAzonosito.Equals( verseny.Azonosito ) ) ) {
                        foreach( var eredmeny in versenyeredmenyek.Eredmenyek._eredmenyek.Where( eredmeny => eredmeny.Indulo.Equals( indulo.Nev ) ) ) {
                            egyesuletIndulok.Add( new Model.Egyesulet.Egyesulet_Tagok {
                                Indulo = indulo.Nev,
                                Kor = eredmeny.Kor,
                                Nem = indulo.Nem,
                                Megjelent = eredmeny.Megjelent
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
