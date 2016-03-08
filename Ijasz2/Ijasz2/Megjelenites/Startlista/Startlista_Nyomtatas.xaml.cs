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
        private readonly string _dokumentumTipus;
        public Startlista_Nyomtatas( string tipus, string versenyAzonosito ) {
            InitializeComponent( );
            _versenyAzonosito = versenyAzonosito;
            _dokumentumTipus = tipus;
        }

        private void BtnMegnyitas_OnClick( object sender, RoutedEventArgs e ) {
            switch( _dokumentumTipus ) {
                case DokumentumTipus.Startlista.CsapatLista:
                    new CsapatLista( _versenyAzonosito ).Open( );
                    break;
                case DokumentumTipus.Startlista.HianyzokLista:
                    new HianyzokLista( _versenyAzonosito ).Open();
                    break;
                case DokumentumTipus.Startlista.NevezesiLista:
                    new NevezesiLista( _versenyAzonosito ).Open();
                    break;
            }
        }

        private void BtnIgen_OnClick( object sender, RoutedEventArgs e ) {
            switch( _dokumentumTipus ) {
                case DokumentumTipus.Startlista.CsapatLista:
                    new CsapatLista( _versenyAzonosito ).Print();
                    break;
                case DokumentumTipus.Startlista.HianyzokLista:
                    new HianyzokLista( _versenyAzonosito ).Print();
                    break;
                case DokumentumTipus.Startlista.NevezesiLista:
                    new NevezesiLista( _versenyAzonosito ).Print();
                    break;
            }
            Close( );
        }

        private void BtnNem_OnClick( object sender, RoutedEventArgs e ) {
            Close( );
        }
    }
}