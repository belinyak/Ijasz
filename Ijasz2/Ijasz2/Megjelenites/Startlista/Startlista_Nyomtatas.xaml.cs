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
        private readonly DokumentumTipus _dokumentumTipus;
        public Startlista_Nyomtatas( DokumentumTipus tipus, string versenyAzonosito ) {
            InitializeComponent( );
            _versenyAzonosito = versenyAzonosito;
            _dokumentumTipus = tipus;
        }

        private void BtnMegnyitas_OnClick( object sender, RoutedEventArgs e ) {
            switch( _dokumentumTipus ) {
                case DokumentumTipus.CsapatLista:
                    new Nyomtatas.Startlista.CsapatLista( _versenyAzonosito ).Open( );
                    break;
                case DokumentumTipus.HianyzokLista:
                    new Nyomtatas.Startlista.HianyzokLista( _versenyAzonosito ).Open();
                    break;
                case DokumentumTipus.NevezesiLista:
                    new Nyomtatas.Startlista.NevezesiLista( _versenyAzonosito ).Open();
                    break;
            }
            Close( );
        }

        private void BtnIgen_OnClick( object sender, RoutedEventArgs e ) {
            switch( _dokumentumTipus ) {
                case DokumentumTipus.CsapatLista:
                    new Nyomtatas.Startlista.CsapatLista( _versenyAzonosito ).Print();
                    break;
                case DokumentumTipus.HianyzokLista:
                    new Nyomtatas.Startlista.HianyzokLista( _versenyAzonosito ).Print();
                    break;
                case DokumentumTipus.NevezesiLista:
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