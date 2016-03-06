using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Ijasz2.Model.Indulo;

namespace Ijasz2.Megjelenites.Indulo {
    /// <summary>
    ///     Interaction logic for Indulo_Csapatok.xaml
    /// </summary>
    public partial class Indulo_Csapatok {
        private List<Csapat> _csapatok;
        public Indulo_Csapatok( string versenyAzonosito ) {
            InitializeComponent( );
            InitializeContent( versenyAzonosito );
        }

        private void InitializeContent( string versenyAzonosito ) {
            _csapatok = new List<Csapat>( );
            for( int i = 1; i < 46; i++ ) {
                _csapatok.Add( new Csapat {
                    Azonosito = i,
                    IndulokSzama = 0,
                    CsapatIndulok = new List<CsapatIndulo>( )
                } );

                CsapatGrid.SelectionChanged += CsapatGridOnSelectionChanged;
            }

            //var indulok = Model.Data.Data.Indulok._indulok.Where()
            foreach( var versenyeredmenyek in Model.Data.Data.Eredmenyek._versenyEredmenyek.Where( eredmeny => eredmeny.VersenyAzonosito.Equals( versenyAzonosito ) ) ) {
                foreach( var eredmeny in versenyeredmenyek.Eredmenyek._eredmenyek ) {
                    _csapatok[eredmeny.Csapat].IndulokSzama += 1;
                    _csapatok[eredmeny.Csapat].CsapatIndulok.Add( new CsapatIndulo {
                        Indulo = eredmeny.Indulo,
                        Ijtipus = eredmeny.Ijtipus,
                        Kor = eredmeny.Kor,
                        Egyesulet = (from indulo in Model.Data.Data.Indulok._indulok
                                    where indulo.Nev.Equals(eredmeny.Indulo)
                                    select indulo.Egyesulet).First()
                    } );
                }
            }
            CsapatGrid.ItemsSource = _csapatok;
        }

        private void CsapatGridOnSelectionChanged( object sender, SelectionChangedEventArgs selectionChangedEventArgs ) {
            CsapatIndulokGrid.ItemsSource = null;
            var csapat = CsapatGrid.SelectedItem as Csapat;
            CsapatIndulokGrid.ItemsSource = csapat.CsapatIndulok;
        }
    }
}