﻿#pragma checksum "..\..\..\..\..\Megjelenites\Indulo\Indulo_Beiras.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7A23FF0451C13CB1D0B90183029FC9E8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Ijasz2.Megjelenites.Indulo {
    
    
    /// <summary>
    /// Indulo_Beiras
    /// </summary>
    public partial class Indulo_Beiras : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\..\..\Megjelenites\Indulo\Indulo_Beiras.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNev;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\Megjelenites\Indulo\Indulo_Beiras.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbVerseny;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\Megjelenites\Indulo\Indulo_Beiras.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbIjtipus;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\Megjelenites\Indulo\Indulo_Beiras.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbCsapat;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\Megjelenites\Indulo\Indulo_Beiras.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chMegjelent;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\..\Megjelenites\Indulo\Indulo_Beiras.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chKorosztalyFelulir;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\Megjelenites\Indulo\Indulo_Beiras.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbUjKorosztaly;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Ijasz2;component/megjelenites/indulo/indulo_beiras.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Megjelenites\Indulo\Indulo_Beiras.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtNev = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.cbVerseny = ((System.Windows.Controls.ComboBox)(target));
            
            #line 40 "..\..\..\..\..\Megjelenites\Indulo\Indulo_Beiras.xaml"
            this.cbVerseny.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbVerseny_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbIjtipus = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.cbCsapat = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.chMegjelent = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.chKorosztalyFelulir = ((System.Windows.Controls.CheckBox)(target));
            
            #line 47 "..\..\..\..\..\Megjelenites\Indulo\Indulo_Beiras.xaml"
            this.chKorosztalyFelulir.Click += new System.Windows.RoutedEventHandler(this.ChKorosztalyFelulir_OnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cbUjKorosztaly = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            
            #line 51 "..\..\..\..\..\Megjelenites\Indulo\Indulo_Beiras.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnRendben_OnClick);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 53 "..\..\..\..\..\Megjelenites\Indulo\Indulo_Beiras.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnCsapatok_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

