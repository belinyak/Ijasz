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
using Ijasz2.Model.Data;
using Ijasz2.Model.Oklevel;

namespace Ijasz2.Megjelenites.Oklevel {
    /// <summary>
    /// Interaction logic for Sablon_Hozzaadas_Modositas.xaml
    /// </summary>
    public partial class Sablon_Hozzaadas_Modositas : Window {
        private Model.Oklevel.Sablon _sablon;

        #region Hozzaadas
        public Sablon_Hozzaadas_Modositas( ) {
            InitializeComponent( );
            InitializeContent( );
        }

        private void InitializeContent( ) {
            Title += " hozzáadás";

            cbTipus.Items.Add( "Verseny" );
            cbTipus.Items.Add( "Versenysorozat" );
        }
        #endregion

        #region Modositas
        public Sablon_Hozzaadas_Modositas( Model.Oklevel.Sablon sablon ) {
            _sablon = sablon;
            InitializeComponent( );
            InitializeContent( sablon );
        }

        private void InitializeContent( Model.Oklevel.Sablon sablon ) {
            Title += " módosítás";
            cbTipus.Items.Add( "Verseny" );
            cbTipus.Items.Add( "Versenysorozat" );

            txtAzonosito.Text = sablon.Azonosito;
            txtAzonosito.IsEnabled = false;
            cbTipus.Text = sablon.Tipus;
            cbTipus.IsEnabled = false;

            SetValuesSeged( sablon );

        }
        #endregion

        private bool IsValid( ) {
            bool valid = true;
            txtAzonosito.ClearValue( Border.BorderBrushProperty );
            cbTipus.ClearValue( Border.BorderBrushProperty );
            lblTipus.Foreground = new SolidColorBrush( Colors.Black );

            if( txtAzonosito.Text.Length == 0 ) {
                txtAzonosito.BorderBrush = new SolidColorBrush( Colors.Red );
                valid = false;
            }

            if( cbTipus.SelectedItem == null ) {
                lblTipus.Foreground = new SolidColorBrush( Colors.Red );
                valid = false;
            }

            #region Verseny
            txtVersenySze.ClearValue( Border.BorderBrushProperty );
            txtVersenyMa.ClearValue( Border.BorderBrushProperty );
            txtVersenyHo.ClearValue( Border.BorderBrushProperty );
            chVersenyBo.ClearValue( Border.BorderBrushProperty );
            chVersenyIt.ClearValue( Border.BorderBrushProperty );
            txtVersenyMe.ClearValue( Border.BorderBrushProperty );
            lblBt.Foreground = new SolidColorBrush( Colors.Black );
            chVersenyRi.ClearValue( Border.BorderBrushProperty );
            chVersenyMi.ClearValue( Border.BorderBrushProperty );
            chVersenyLe.ClearValue( Border.BorderBrushProperty );

            if( txtVersenySze.Text != "" ) {
                if( txtVersenyMa.Text == "" ) { txtVersenyMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                if( txtVersenyHo.Text == "" ) { txtVersenyHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                try { Convert.ToInt32( txtVersenySze.Text ); } catch { txtVersenySze.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtVersenyMa.Text ); } catch { txtVersenyMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtVersenyHo.Text ); } catch { txtVersenyHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( chVersenyBo.IsChecked == false && chVersenyIt.IsChecked == false ) {
                    chVersenyBo.BorderBrush = new SolidColorBrush( Colors.Red );
                    chVersenyIt.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }

                if( txtVersenyMe.Text == "" ) { txtVersenyMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtVersenyMe.Text ); } catch { txtVersenyMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( cbVersenyBe.Text == "" ) {
                    MessageBox.Show( "Betűtípus kiválasztása kötelező.", "Verseny betűtípus" );
                    valid = false;
                }

                if( chVersenyLe.IsChecked == false && chVersenyRi.IsChecked == false && chVersenyMi.IsChecked == false ) {
                    chVersenyLe.BorderBrush = new SolidColorBrush( Colors.Red );
                    chVersenyRi.BorderBrush = new SolidColorBrush( Colors.Red );
                    chVersenyMi.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }
            }
            #endregion

            #region VersenySorozat
            txtVersenySorozatSze.ClearValue( Border.BorderBrushProperty );
            txtVersenySorozatMa.ClearValue( Border.BorderBrushProperty );
            txtVersenySorozatHo.ClearValue( Border.BorderBrushProperty );
            chVersenySorozatBo.ClearValue( Border.BorderBrushProperty );
            chVersenySorozatIt.ClearValue( Border.BorderBrushProperty );
            txtVersenySorozatMe.ClearValue( Border.BorderBrushProperty );
            lblBt.Foreground = new SolidColorBrush( Colors.Black );
            chVersenySorozatRi.ClearValue( Border.BorderBrushProperty );
            chVersenySorozatMi.ClearValue( Border.BorderBrushProperty );
            chVersenySorozatLe.ClearValue( Border.BorderBrushProperty );

            if( txtVersenySorozatSze.Text != "" ) {
                if( txtVersenySorozatMa.Text == "" ) { txtVersenySorozatMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                if( txtVersenySorozatHo.Text == "" ) { txtVersenySorozatHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                try { Convert.ToInt32( txtVersenySorozatSze.Text ); } catch { txtVersenySorozatSze.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtVersenySorozatMa.Text ); } catch { txtVersenySorozatMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtVersenySorozatHo.Text ); } catch { txtVersenySorozatHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( chVersenySorozatBo.IsChecked == false && chVersenySorozatIt.IsChecked == false ) {
                    chVersenySorozatBo.BorderBrush = new SolidColorBrush( Colors.Red );
                    chVersenySorozatIt.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }

                if( txtVersenySorozatMe.Text == "" ) { txtVersenySorozatMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtVersenySorozatMe.Text ); } catch { txtVersenySorozatMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( cbVersenySorozatBe.Text == "" ) {
                    MessageBox.Show( "Betűtípus kiválasztása kötelező.", "Versenysorozat betűtípus" );
                    valid = false;
                }

                if( chVersenySorozatLe.IsChecked == false && chVersenySorozatRi.IsChecked == false && chVersenySorozatMi.IsChecked == false ) {
                    chVersenySorozatLe.BorderBrush = new SolidColorBrush( Colors.Red );
                    chVersenySorozatRi.BorderBrush = new SolidColorBrush( Colors.Red );
                    chVersenySorozatMi.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }
            }
            #endregion

            #region Helyezes
            txtHelyezesSze.ClearValue( Border.BorderBrushProperty );
            txtHelyezesMa.ClearValue( Border.BorderBrushProperty );
            txtHelyezesHo.ClearValue( Border.BorderBrushProperty );
            chHelyezesBo.ClearValue( Border.BorderBrushProperty );
            chHelyezesIt.ClearValue( Border.BorderBrushProperty );
            txtHelyezesMe.ClearValue( Border.BorderBrushProperty );
            lblBt.Foreground = new SolidColorBrush( Colors.Black );
            chHelyezesRi.ClearValue( Border.BorderBrushProperty );
            chHelyezesMi.ClearValue( Border.BorderBrushProperty );
            chHelyezesLe.ClearValue( Border.BorderBrushProperty );

            if( txtHelyezesSze.Text != "" ) {
                if( txtHelyezesMa.Text == "" ) { txtHelyezesMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                if( txtHelyezesHo.Text == "" ) { txtHelyezesHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                try { Convert.ToInt32( txtHelyezesSze.Text ); } catch { txtHelyezesSze.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtHelyezesMa.Text ); } catch { txtHelyezesMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtHelyezesHo.Text ); } catch { txtHelyezesHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( chHelyezesBo.IsChecked == false && chHelyezesIt.IsChecked == false ) {
                    chHelyezesBo.BorderBrush = new SolidColorBrush( Colors.Red );
                    chHelyezesIt.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }

                if( txtHelyezesMe.Text == "" ) { txtHelyezesMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtHelyezesMe.Text ); } catch { txtHelyezesMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( cbHelyezesBe.Text == "" ) {
                    MessageBox.Show( "Betűtípus kiválasztása kötelező.", "Helyezés betűtípus" );
                    valid = false;
                }

                if( chHelyezesLe.IsChecked == false && chHelyezesRi.IsChecked == false && chHelyezesMi.IsChecked == false ) {
                    chHelyezesLe.BorderBrush = new SolidColorBrush( Colors.Red );
                    chHelyezesRi.BorderBrush = new SolidColorBrush( Colors.Red );
                    chHelyezesMi.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }
            }
            #endregion

            #region Indulo
            txtInduloSze.ClearValue( Border.BorderBrushProperty );
            txtInduloMa.ClearValue( Border.BorderBrushProperty );
            txtInduloHo.ClearValue( Border.BorderBrushProperty );
            chInduloBo.ClearValue( Border.BorderBrushProperty );
            chInduloIt.ClearValue( Border.BorderBrushProperty );
            txtInduloMe.ClearValue( Border.BorderBrushProperty );
            lblBt.Foreground = new SolidColorBrush( Colors.Black );
            chInduloRi.ClearValue( Border.BorderBrushProperty );
            chInduloMi.ClearValue( Border.BorderBrushProperty );
            chInduloLe.ClearValue( Border.BorderBrushProperty );

            if( txtInduloSze.Text != "" ) {
                if( txtInduloMa.Text == "" ) { txtInduloMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                if( txtInduloHo.Text == "" ) { txtInduloHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                try { Convert.ToInt32( txtInduloSze.Text ); } catch { txtInduloSze.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtInduloMa.Text ); } catch { txtInduloMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtInduloHo.Text ); } catch { txtInduloHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( chInduloBo.IsChecked == false && chInduloIt.IsChecked == false ) {
                    chInduloBo.BorderBrush = new SolidColorBrush( Colors.Red );
                    chInduloIt.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }

                if( txtInduloMe.Text == "" ) { txtInduloMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtInduloMe.Text ); } catch { txtInduloMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( cbInduloBe.Text == "" ) {
                    MessageBox.Show( "Betűtípus kiválasztása kötelező.", "Induló betűtípus" );
                    valid = false;
                }

                if( chInduloLe.IsChecked == false && chInduloRi.IsChecked == false && chInduloMi.IsChecked == false ) {
                    chInduloLe.BorderBrush = new SolidColorBrush( Colors.Red );
                    chInduloRi.BorderBrush = new SolidColorBrush( Colors.Red );
                    chInduloMi.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }
            }
            #endregion

            #region Egyesulet
            txtEgyesuletSze.ClearValue( Border.BorderBrushProperty );
            txtEgyesuletMa.ClearValue( Border.BorderBrushProperty );
            txtEgyesuletHo.ClearValue( Border.BorderBrushProperty );
            chEgyesuletBo.ClearValue( Border.BorderBrushProperty );
            chEgyesuletIt.ClearValue( Border.BorderBrushProperty );
            txtEgyesuletMe.ClearValue( Border.BorderBrushProperty );
            lblBt.Foreground = new SolidColorBrush( Colors.Black );
            chEgyesuletRi.ClearValue( Border.BorderBrushProperty );
            chEgyesuletMi.ClearValue( Border.BorderBrushProperty );
            chEgyesuletLe.ClearValue( Border.BorderBrushProperty );

            if( txtEgyesuletSze.Text != "" ) {
                if( txtEgyesuletMa.Text == "" ) { txtEgyesuletMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                if( txtEgyesuletHo.Text == "" ) { txtEgyesuletHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                try { Convert.ToInt32( txtEgyesuletSze.Text ); } catch { txtEgyesuletSze.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtEgyesuletMa.Text ); } catch { txtEgyesuletMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtEgyesuletHo.Text ); } catch { txtEgyesuletHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( chEgyesuletBo.IsChecked == false && chEgyesuletIt.IsChecked == false ) {
                    chEgyesuletBo.BorderBrush = new SolidColorBrush( Colors.Red );
                    chEgyesuletIt.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }

                if( txtEgyesuletMe.Text == "" ) { txtEgyesuletMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtEgyesuletMe.Text ); } catch { txtEgyesuletMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( cbEgyesuletBe.Text == "" ) {
                    MessageBox.Show( "Betűtípus kiválasztása kötelező.", "Egyesület betűtípus" );
                    valid = false;
                }

                if( chEgyesuletLe.IsChecked == false && chEgyesuletRi.IsChecked == false && chEgyesuletMi.IsChecked == false ) {
                    chEgyesuletLe.BorderBrush = new SolidColorBrush( Colors.Red );
                    chEgyesuletRi.BorderBrush = new SolidColorBrush( Colors.Red );
                    chEgyesuletMi.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }
            }
            #endregion

            #region Ijtipus
            txtIjtipusSze.ClearValue( Border.BorderBrushProperty );
            txtIjtipusMa.ClearValue( Border.BorderBrushProperty );
            txtIjtipusHo.ClearValue( Border.BorderBrushProperty );
            chIjtipusBo.ClearValue( Border.BorderBrushProperty );
            chIjtipusIt.ClearValue( Border.BorderBrushProperty );
            txtIjtipusMe.ClearValue( Border.BorderBrushProperty );
            lblBt.Foreground = new SolidColorBrush( Colors.Black );
            chIjtipusRi.ClearValue( Border.BorderBrushProperty );
            chIjtipusMi.ClearValue( Border.BorderBrushProperty );
            chIjtipusLe.ClearValue( Border.BorderBrushProperty );

            if( txtIjtipusSze.Text != "" ) {
                if( txtIjtipusMa.Text == "" ) { txtIjtipusMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                if( txtIjtipusHo.Text == "" ) { txtIjtipusHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                try { Convert.ToInt32( txtIjtipusSze.Text ); } catch { txtIjtipusSze.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtIjtipusMa.Text ); } catch { txtIjtipusMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtIjtipusHo.Text ); } catch { txtIjtipusHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( chIjtipusBo.IsChecked == false && chIjtipusIt.IsChecked == false ) {
                    chIjtipusBo.BorderBrush = new SolidColorBrush( Colors.Red );
                    chIjtipusIt.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }

                if( txtIjtipusMe.Text == "" ) { txtIjtipusMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtIjtipusMe.Text ); } catch { txtIjtipusMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( cbIjtipusBe.Text == "" ) {
                    MessageBox.Show( "Betűtípus kiválasztása kötelező.", "Íjtípus betűtípus" );
                    valid = false;
                }

                if( chIjtipusLe.IsChecked == false && chIjtipusRi.IsChecked == false && chIjtipusMi.IsChecked == false ) {
                    chIjtipusLe.BorderBrush = new SolidColorBrush( Colors.Red );
                    chIjtipusRi.BorderBrush = new SolidColorBrush( Colors.Red );
                    chIjtipusMi.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }
            }
            #endregion

            #region Korosztaly
            txtKorosztalySze.ClearValue( Border.BorderBrushProperty );
            txtKorosztalyMa.ClearValue( Border.BorderBrushProperty );
            txtKorosztalyHo.ClearValue( Border.BorderBrushProperty );
            chKorosztalyBo.ClearValue( Border.BorderBrushProperty );
            chKorosztalyIt.ClearValue( Border.BorderBrushProperty );
            txtKorosztalyMe.ClearValue( Border.BorderBrushProperty );
            lblBt.Foreground = new SolidColorBrush( Colors.Black );
            chKorosztalyRi.ClearValue( Border.BorderBrushProperty );
            chKorosztalyMi.ClearValue( Border.BorderBrushProperty );
            chKorosztalyLe.ClearValue( Border.BorderBrushProperty );

            if( txtKorosztalySze.Text != "" ) {
                if( txtKorosztalyMa.Text == "" ) { txtKorosztalyMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                if( txtKorosztalyHo.Text == "" ) { txtKorosztalyHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                try { Convert.ToInt32( txtKorosztalySze.Text ); } catch { txtKorosztalySze.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtKorosztalyMa.Text ); } catch { txtKorosztalyMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtKorosztalyHo.Text ); } catch { txtKorosztalyHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( chKorosztalyBo.IsChecked == false && chKorosztalyIt.IsChecked == false ) {
                    chKorosztalyBo.BorderBrush = new SolidColorBrush( Colors.Red );
                    chKorosztalyIt.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }

                if( txtKorosztalyMe.Text == "" ) { txtKorosztalyMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtKorosztalyMe.Text ); } catch { txtKorosztalyMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( cbKorosztalyBe.Text == "" ) {
                    MessageBox.Show( "Betűtípus kiválasztása kötelező.", "Korosztály betűtípus" );
                    valid = false;
                }

                if( chKorosztalyLe.IsChecked == false && chKorosztalyRi.IsChecked == false && chKorosztalyMi.IsChecked == false ) {
                    chKorosztalyLe.BorderBrush = new SolidColorBrush( Colors.Red );
                    chKorosztalyRi.BorderBrush = new SolidColorBrush( Colors.Red );
                    chKorosztalyMi.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }
            }
            #endregion

            #region InduloNeme
            txtInduloNemeSze.ClearValue( Border.BorderBrushProperty );
            txtInduloNemeMa.ClearValue( Border.BorderBrushProperty );
            txtInduloNemeHo.ClearValue( Border.BorderBrushProperty );
            chInduloNemeBo.ClearValue( Border.BorderBrushProperty );
            chInduloNemeIt.ClearValue( Border.BorderBrushProperty );
            txtInduloNemeMe.ClearValue( Border.BorderBrushProperty );
            lblBt.Foreground = new SolidColorBrush( Colors.Black );
            chInduloNemeRi.ClearValue( Border.BorderBrushProperty );
            chInduloNemeMi.ClearValue( Border.BorderBrushProperty );
            chInduloNemeLe.ClearValue( Border.BorderBrushProperty );

            if( txtInduloNemeSze.Text != "" ) {
                if( txtInduloNemeMa.Text == "" ) { txtInduloNemeMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                if( txtInduloNemeHo.Text == "" ) { txtInduloNemeHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                try { Convert.ToInt32( txtInduloNemeSze.Text ); } catch { txtInduloNemeSze.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtInduloNemeMa.Text ); } catch { txtInduloNemeMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtInduloNemeHo.Text ); } catch { txtInduloNemeHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( chInduloNemeBo.IsChecked == false && chInduloNemeIt.IsChecked == false ) {
                    chInduloNemeBo.BorderBrush = new SolidColorBrush( Colors.Red );
                    chInduloNemeIt.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }

                if( txtInduloNemeMe.Text == "" ) { txtInduloNemeMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtInduloNemeMe.Text ); } catch { txtInduloNemeMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( cbInduloNemeBe.Text == "" ) {
                    MessageBox.Show( "Betűtípus kiválasztása kötelező.", "Induló neme betűtípus" );
                    valid = false;
                }

                if( chInduloNemeLe.IsChecked == false && chInduloNemeRi.IsChecked == false && chInduloNemeMi.IsChecked == false ) {
                    chInduloNemeLe.BorderBrush = new SolidColorBrush( Colors.Red );
                    chInduloNemeRi.BorderBrush = new SolidColorBrush( Colors.Red );
                    chInduloNemeMi.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }
            }
            #endregion

            #region Datum
            txtDatumSze.ClearValue( Border.BorderBrushProperty );
            txtDatumMa.ClearValue( Border.BorderBrushProperty );
            txtDatumHo.ClearValue( Border.BorderBrushProperty );
            chDatumBo.ClearValue( Border.BorderBrushProperty );
            chDatumIt.ClearValue( Border.BorderBrushProperty );
            txtDatumMe.ClearValue( Border.BorderBrushProperty );
            lblBt.Foreground = new SolidColorBrush( Colors.Black );
            chDatumRi.ClearValue( Border.BorderBrushProperty );
            chDatumMi.ClearValue( Border.BorderBrushProperty );
            chDatumLe.ClearValue( Border.BorderBrushProperty );

            if( txtDatumSze.Text != "" ) {
                if( txtDatumMa.Text == "" ) { txtDatumMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                if( txtDatumHo.Text == "" ) { txtDatumHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                try { Convert.ToInt32( txtDatumSze.Text ); } catch { txtDatumSze.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtDatumMa.Text ); } catch { txtDatumMa.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtDatumHo.Text ); } catch { txtDatumHo.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( chDatumBo.IsChecked == false && chDatumIt.IsChecked == false ) {
                    chDatumBo.BorderBrush = new SolidColorBrush( Colors.Red );
                    chDatumIt.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }

                if( txtDatumMe.Text == "" ) { txtDatumMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }
                try { Convert.ToInt32( txtDatumMe.Text ); } catch { txtDatumMe.BorderBrush = new SolidColorBrush( Colors.Red ); valid = false; }

                if( cbDatumBe.Text == "" ) {
                    MessageBox.Show( "Betűtípus kiválasztása kötelező.", "Dátum betűtípus" );
                    valid = false;
                }

                if( chDatumLe.IsChecked == false && chDatumRi.IsChecked == false && chDatumMi.IsChecked == false ) {
                    chDatumLe.BorderBrush = new SolidColorBrush( Colors.Red );
                    chDatumRi.BorderBrush = new SolidColorBrush( Colors.Red );
                    chDatumMi.BorderBrush = new SolidColorBrush( Colors.Red );
                    valid = false;
                }
            }
            #endregion

            return valid;
        }
        /// <summary>
        /// TODO figyelembe vett mezők üzenet !!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRendben_OnClick( object sender, RoutedEventArgs e ) {
            if( IsValid( ) == false ) {
                return;
            }

            var sablon = new Model.Oklevel.Sablon {
                Azonosito = txtAzonosito.Text,
                Tipus = cbTipus.Text,
                Verseny = (txtVersenySze.Text == "" ? null : new SablonMezo {
                    X = Convert.ToInt32(txtVersenySze.Text),
                    Y = Convert.ToInt32(txtVersenyMa.Text),
                    Hossz = Convert.ToInt32(txtVersenyHo.Text),
                    Formatum = chVersenyBo.IsChecked == true ? (chVersenyIt.IsChecked == true ? "2" : "B") : (chVersenyIt.IsChecked == true ? "I" : "0"),
                    BetuMeret = Convert.ToInt32(txtVersenyMe.Text),
                    Betutipus = cbVersenyBe.Text,
                    Igazitas = chVersenyLe.IsChecked == true ? "L" : chVersenyMi.IsChecked ==  true ? "M" : chVersenyRi.IsChecked == true ? "R" : "M"
                }),
                Versenysorozat = (txtVersenySorozatSze.Text == "" ? null : new SablonMezo {
                    X = Convert.ToInt32(txtVersenySorozatSze.Text),
                    Y = Convert.ToInt32(txtVersenySorozatMa.Text),
                    Hossz = Convert.ToInt32(txtVersenySorozatHo.Text),
                    Formatum = chVersenySorozatBo.IsChecked == true ? (chVersenySorozatIt.IsChecked == true ? "2" : "B") : (chVersenySorozatIt.IsChecked == true ? "I" : "0"),
                    BetuMeret = Convert.ToInt32(txtVersenySorozatMe.Text),
                    Betutipus = cbVersenySorozatBe.Text,
                    Igazitas = chVersenySorozatLe.IsChecked == true ? "L" : chVersenySorozatMi.IsChecked ==  true ? "M" : chVersenySorozatRi.IsChecked == true ? "R" : "M"
                }),
                Helyezes = (txtHelyezesSze.Text == "" ? null : new SablonMezo {
                    X = Convert.ToInt32(txtHelyezesSze.Text),
                    Y = Convert.ToInt32(txtHelyezesMa.Text),
                    Hossz = Convert.ToInt32(txtHelyezesHo.Text),
                    Formatum = chHelyezesBo.IsChecked == true ? (chHelyezesIt.IsChecked == true ? "2" : "B") : (chHelyezesIt.IsChecked == true ? "I" : "0"),
                    BetuMeret = Convert.ToInt32(txtHelyezesMe.Text),
                    Betutipus = cbHelyezesBe.Text,
                    Igazitas = chHelyezesLe.IsChecked == true ? "L" : chHelyezesMi.IsChecked ==  true ? "M" : chHelyezesRi.IsChecked == true ? "R" : "M"
                }),
                Indulo = (txtInduloSze.Text == "" ? null : new SablonMezo {
                    X = Convert.ToInt32(txtInduloSze.Text),
                    Y = Convert.ToInt32(txtInduloMa.Text),
                    Hossz = Convert.ToInt32(txtInduloHo.Text),
                    Formatum = chInduloBo.IsChecked == true ? (chInduloIt.IsChecked == true ? "2" : "B") : (chInduloIt.IsChecked == true ? "I" : "0"),
                    BetuMeret = Convert.ToInt32(txtInduloMe.Text),
                    Betutipus = cbInduloBe.Text,
                    Igazitas = chInduloLe.IsChecked == true ? "L" : chInduloMi.IsChecked ==  true ? "M" : chInduloRi.IsChecked == true ? "R" : "M"
                }),
                Egyesulet = (txtEgyesuletSze.Text == "" ? null : new SablonMezo {
                    X = Convert.ToInt32(txtEgyesuletSze.Text),
                    Y = Convert.ToInt32(txtEgyesuletMa.Text),
                    Hossz = Convert.ToInt32(txtEgyesuletHo.Text),
                    Formatum = chEgyesuletBo.IsChecked == true ? (chEgyesuletIt.IsChecked == true ? "2" : "B") : (chEgyesuletIt.IsChecked == true ? "I" : "0"),
                    BetuMeret = Convert.ToInt32(txtEgyesuletMe.Text),
                    Betutipus = cbEgyesuletBe.Text,
                    Igazitas = chEgyesuletLe.IsChecked == true ? "L" : chEgyesuletMi.IsChecked ==  true ? "M" : chEgyesuletRi.IsChecked == true ? "R" : "M"
                }),
                Ijtipus = (txtIjtipusSze.Text == "" ? null : new SablonMezo {
                    X = Convert.ToInt32(txtIjtipusSze.Text),
                    Y = Convert.ToInt32(txtIjtipusMa.Text),
                    Hossz = Convert.ToInt32(txtIjtipusHo.Text),
                    Formatum = chIjtipusBo.IsChecked == true ? (chIjtipusIt.IsChecked == true ? "2" : "B") : (chIjtipusIt.IsChecked == true ? "I" : "0"),
                    BetuMeret = Convert.ToInt32(txtIjtipusMe.Text),
                    Betutipus = cbIjtipusBe.Text,
                    Igazitas = chIjtipusLe.IsChecked == true ? "L" : chIjtipusMi.IsChecked ==  true ? "M" : chIjtipusRi.IsChecked == true ? "R" : "M"
                }),
                Korosztaly = (txtKorosztalySze.Text == "" ? null : new SablonMezo {
                    X = Convert.ToInt32(txtKorosztalySze.Text),
                    Y = Convert.ToInt32(txtKorosztalyMa.Text),
                    Hossz = Convert.ToInt32(txtKorosztalyHo.Text),
                    Formatum = chKorosztalyBo.IsChecked == true ? (chKorosztalyIt.IsChecked == true ? "2" : "B") : (chKorosztalyIt.IsChecked == true ? "I" : "0"),
                    BetuMeret = Convert.ToInt32(txtKorosztalyMe.Text),
                    Betutipus = cbKorosztalyBe.Text,
                    Igazitas = chKorosztalyLe.IsChecked == true ? "L" : chKorosztalyMi.IsChecked ==  true ? "M" : chKorosztalyRi.IsChecked == true ? "R" : "M"
                }),
                InduloNem = (txtInduloNemeSze.Text == "" ? null : new SablonMezo {
                    X = Convert.ToInt32(txtInduloNemeSze.Text),
                    Y = Convert.ToInt32(txtInduloNemeMa.Text),
                    Hossz = Convert.ToInt32(txtInduloNemeHo.Text),
                    Formatum = chInduloNemeBo.IsChecked == true ? (chInduloNemeIt.IsChecked == true ? "2" : "B") : (chInduloNemeIt.IsChecked == true ? "I" : "0"),
                    BetuMeret = Convert.ToInt32(txtInduloNemeMe.Text),
                    Betutipus = cbInduloNemeBe.Text,
                    Igazitas = chInduloNemeLe.IsChecked == true ? "L" : chInduloNemeMi.IsChecked ==  true ? "M" : chInduloNemeRi.IsChecked == true ? "R" : "M"
                }),
                Datum = (txtDatumSze.Text == "" ? null : new SablonMezo {
                    X = Convert.ToInt32(txtDatumSze.Text),
                    Y = Convert.ToInt32(txtDatumMa.Text),
                    Hossz = Convert.ToInt32(txtDatumHo.Text),
                    Formatum = chDatumBo.IsChecked == true ? (chDatumIt.IsChecked == true ? "2" : "B") : (chDatumIt.IsChecked == true ? "I" : "0"),
                    BetuMeret = Convert.ToInt32(txtDatumMe.Text),
                    Betutipus = cbDatumBe.Text,
                    Igazitas = chDatumLe.IsChecked == true ? "L" : chDatumMi.IsChecked ==  true ? "M" : chDatumRi.IsChecked == true ? "R" : "M"
                })
            };

            //TODO ezeket innen ki kéne tenni, nem???
            // modositas
            if( _sablon != null ) {
                Model.Data.Data.Sablonok.Update( sablon );
            }
            //hozzaadas
            else {
                Model.Data.Data.Sablonok.Add( sablon );
            }
            Close( );

        }

        private void SetValuesSeged( Model.Oklevel.Sablon sablon ) {
            #region Verseny
            if( sablon.Verseny != null ) {
                txtVersenySze.Text = sablon.Verseny.X.ToString( );
                txtVersenyMa.Text = sablon.Verseny.Y.ToString( );
                txtVersenyHo.Text = sablon.Verseny.Hossz.ToString( );
                chVersenyBo.IsChecked = sablon.Verseny.Formatum == "B" || sablon.Verseny.Formatum == "2";
                chVersenyIt.IsChecked = sablon.Verseny.Formatum == "I" || sablon.Verseny.Formatum == "2";
                txtVersenyMe.Text = sablon.Verseny.BetuMeret.ToString( );
                cbVersenyBe.Text = sablon.Verseny.Betutipus;
                chVersenyLe.IsChecked = sablon.Verseny.Igazitas == "L";
                chVersenyRi.IsChecked = sablon.Verseny.Igazitas == "R";
                chVersenyMi.IsChecked = sablon.Verseny.Igazitas == "M";
            }
            #endregion

            #region Versenysorozat
            if( sablon.Versenysorozat != null ) {
                txtVersenySorozatSze.Text = sablon.Versenysorozat.X.ToString( );
                txtVersenySorozatMa.Text = sablon.Versenysorozat.Y.ToString( );
                txtVersenySorozatHo.Text = sablon.Versenysorozat.Hossz.ToString( );
                chVersenySorozatBo.IsChecked = sablon.Versenysorozat.Formatum == "B";
                chVersenySorozatIt.IsChecked = sablon.Versenysorozat.Formatum == "I";
                txtVersenySorozatMe.Text = sablon.Versenysorozat.BetuMeret.ToString( );
                cbVersenySorozatBe.Text = sablon.Versenysorozat.Betutipus;
                chVersenySorozatLe.IsChecked = sablon.Versenysorozat.Igazitas == "L";
                chVersenySorozatRi.IsChecked = sablon.Versenysorozat.Igazitas == "R";
                chVersenySorozatMi.IsChecked = sablon.Versenysorozat.Igazitas == "M";
            }
            #endregion

            #region Helyezes
            if( sablon.Helyezes != null ) {
                txtHelyezesSze.Text = sablon.Helyezes.X.ToString( );
                txtHelyezesMa.Text = sablon.Helyezes.Y.ToString( );
                txtHelyezesHo.Text = sablon.Helyezes.Hossz.ToString( );
                chHelyezesBo.IsChecked = sablon.Helyezes.Formatum == "B";
                chHelyezesIt.IsChecked = sablon.Helyezes.Formatum == "I";
                txtHelyezesMe.Text = sablon.Helyezes.BetuMeret.ToString( );
                cbHelyezesBe.Text = sablon.Helyezes.Betutipus;
                chHelyezesLe.IsChecked = sablon.Helyezes.Igazitas == "L";
                chHelyezesRi.IsChecked = sablon.Helyezes.Igazitas == "R";
                chHelyezesMi.IsChecked = sablon.Helyezes.Igazitas == "M";
            }
            #endregion

            #region Indulo
            if( sablon.Indulo != null ) {
                txtInduloSze.Text = sablon.Indulo.X.ToString( );
                txtInduloMa.Text = sablon.Indulo.Y.ToString( );
                txtInduloHo.Text = sablon.Indulo.Hossz.ToString( );
                chInduloBo.IsChecked = sablon.Indulo.Formatum == "B";
                chInduloIt.IsChecked = sablon.Indulo.Formatum == "I";
                txtInduloMe.Text = sablon.Indulo.BetuMeret.ToString( );
                cbInduloBe.Text = sablon.Indulo.Betutipus;
                chInduloLe.IsChecked = sablon.Indulo.Igazitas == "L";
                chInduloRi.IsChecked = sablon.Indulo.Igazitas == "R";
                chInduloMi.IsChecked = sablon.Indulo.Igazitas == "M";
            }
            #endregion

            #region Egyesulet
            if( sablon.Egyesulet != null ) {
                txtEgyesuletSze.Text = sablon.Egyesulet.X.ToString( );
                txtEgyesuletMa.Text = sablon.Egyesulet.Y.ToString( );
                txtEgyesuletHo.Text = sablon.Egyesulet.Hossz.ToString( );
                chEgyesuletBo.IsChecked = sablon.Egyesulet.Formatum == "B";
                chEgyesuletIt.IsChecked = sablon.Egyesulet.Formatum == "I";
                txtEgyesuletMe.Text = sablon.Egyesulet.BetuMeret.ToString( );
                cbEgyesuletBe.Text = sablon.Egyesulet.Betutipus;
                chEgyesuletLe.IsChecked = sablon.Egyesulet.Igazitas == "L";
                chEgyesuletRi.IsChecked = sablon.Egyesulet.Igazitas == "R";
                chEgyesuletMi.IsChecked = sablon.Egyesulet.Igazitas == "M";
            }
            #endregion

            #region Ijtipus
            if( sablon.Ijtipus != null ) {
                txtIjtipusSze.Text = sablon.Ijtipus.X.ToString( );
                txtIjtipusMa.Text = sablon.Ijtipus.Y.ToString( );
                txtIjtipusHo.Text = sablon.Ijtipus.Hossz.ToString( );
                chIjtipusBo.IsChecked = sablon.Ijtipus.Formatum == "B";
                chIjtipusIt.IsChecked = sablon.Ijtipus.Formatum == "I";
                txtIjtipusMe.Text = sablon.Ijtipus.BetuMeret.ToString( );
                cbIjtipusBe.Text = sablon.Ijtipus.Betutipus;
                chIjtipusLe.IsChecked = sablon.Ijtipus.Igazitas == "L";
                chIjtipusRi.IsChecked = sablon.Ijtipus.Igazitas == "R";
                chIjtipusMi.IsChecked = sablon.Ijtipus.Igazitas == "M";
            }
            #endregion

            #region Korosztaly
            if( sablon.Korosztaly != null ) {
                txtKorosztalySze.Text = sablon.Korosztaly.X.ToString( );
                txtKorosztalyMa.Text = sablon.Korosztaly.Y.ToString( );
                txtKorosztalyHo.Text = sablon.Korosztaly.Hossz.ToString( );
                chKorosztalyBo.IsChecked = sablon.Korosztaly.Formatum == "B";
                chKorosztalyIt.IsChecked = sablon.Korosztaly.Formatum == "I";
                txtKorosztalyMe.Text = sablon.Korosztaly.BetuMeret.ToString( );
                cbKorosztalyBe.Text = sablon.Korosztaly.Betutipus;
                chKorosztalyLe.IsChecked = sablon.Korosztaly.Igazitas == "L";
                chKorosztalyRi.IsChecked = sablon.Korosztaly.Igazitas == "R";
                chKorosztalyMi.IsChecked = sablon.Korosztaly.Igazitas == "M";
            }
            #endregion

            #region InduloNem
            if( sablon.InduloNem != null ) {
                txtInduloNemeSze.Text = sablon.InduloNem.X.ToString( );
                txtInduloNemeMe.Text = sablon.InduloNem.Y.ToString( );
                txtInduloNemeHo.Text = sablon.InduloNem.Hossz.ToString( );
                chInduloNemeBo.IsChecked = sablon.InduloNem.Formatum == "B";
                chInduloNemeIt.IsChecked = sablon.InduloNem.Formatum == "I";
                txtInduloNemeMe.Text = sablon.InduloNem.BetuMeret.ToString( );
                cbInduloNemeBe.Text = sablon.InduloNem.Betutipus;
                chInduloNemeLe.IsChecked = sablon.InduloNem.Igazitas == "L";
                chInduloNemeRi.IsChecked = sablon.InduloNem.Igazitas == "R";
                chInduloNemeMi.IsChecked = sablon.InduloNem.Igazitas == "M";
            }
            #endregion

            #region Datum
            if( sablon.Datum != null ) {
                txtDatumSze.Text = sablon.Datum.X.ToString( );
                txtDatumMa.Text = sablon.Datum.Y.ToString( );
                txtDatumHo.Text = sablon.Datum.Hossz.ToString( );
                chDatumBo.IsChecked = sablon.Datum.Formatum == "B";
                chDatumIt.IsChecked = sablon.Datum.Formatum == "I";
                txtDatumMe.Text = sablon.Datum.BetuMeret.ToString( );
                cbDatumBe.Text = sablon.Datum.Betutipus;
                chDatumLe.IsChecked = sablon.Datum.Igazitas == "L";
                chDatumRi.IsChecked = sablon.Datum.Igazitas == "R";
                chDatumMi.IsChecked = sablon.Datum.Igazitas == "M";
            }
            #endregion
        }
    }
}
