using System;
using System.Windows;
using Ijasz2.Nyomtatas.Seged;
using Ijasz2.Nyomtatas.Startlista;

namespace Ijasz2.Megjelenites.Startlista {
    /// <summary>
    ///     Interaction logic for Startlista_Nyomtatas.xaml
    /// </summary>
    public partial class Startlista_Nyomtatas {
        private readonly string _versenyAzonosito;
        private readonly StartlistaTipus _dokumentumTipus;
        public Startlista_Nyomtatas( StartlistaTipus tipus, string versenyAzonosito ) {
            InitializeComponent( );
            _versenyAzonosito = versenyAzonosito;
            _dokumentumTipus = tipus;
        }

        private void BtnMegnyitas_OnClick( object sender, RoutedEventArgs e ) {
            switch( _dokumentumTipus ) {
                case StartlistaTipus.CsapatLista:
                    new Nyomtatas.Startlista.CsapatLista( _versenyAzonosito ).Open( );
                    break;
                case StartlistaTipus.HianyzokLista:
                    new Nyomtatas.Startlista.HianyzokLista( _versenyAzonosito ).Open();
                    break;
                case StartlistaTipus.NevezesiLista:
                    new Nyomtatas.Startlista.NevezesiLista( _versenyAzonosito ).Open();
                    break;
            }
        }

        private void BtnIgen_OnClick( object sender, RoutedEventArgs e ) {
            switch( _dokumentumTipus ) {
                case StartlistaTipus.CsapatLista:
                    new Nyomtatas.Startlista.CsapatLista( _versenyAzonosito ).Print();
                    break;
                case StartlistaTipus.HianyzokLista:
                    new Nyomtatas.Startlista.HianyzokLista( _versenyAzonosito ).Print();
                    break;
                case StartlistaTipus.NevezesiLista:
                    new Nyomtatas.Startlista.NevezesiLista( _versenyAzonosito ).Print();
                    break;
            }
            Close( );
        }

        private void BtnNem_OnClick( object sender, RoutedEventArgs e ) {
            Close( );
        }
    }
}