﻿#pragma checksum "..\..\..\..\..\Megjelenites\Egyesület\Egyesulet_Tagok.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4BC3A7FB88AC0E3A63673F1A0BE2AAE4"
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


namespace Ijasz2.Megjelenites.Egyesület {
    
    
    /// <summary>
    /// Egyesulet_Tagok
    /// </summary>
    public partial class Egyesulet_Tagok : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\..\Megjelenites\Egyesület\Egyesulet_Tagok.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid EgyesuletTagokGrid;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\Megjelenites\Egyesület\Egyesulet_Tagok.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboEgyesuletTagokVerseny;
        
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
            System.Uri resourceLocater = new System.Uri("/Ijasz2;component/megjelenites/egyes%c3%bclet/egyesulet_tagok.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Megjelenites\Egyesület\Egyesulet_Tagok.xaml"
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
            this.EgyesuletTagokGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.cboEgyesuletTagokVerseny = ((System.Windows.Controls.ComboBox)(target));
            
            #line 51 "..\..\..\..\..\Megjelenites\Egyesület\Egyesulet_Tagok.xaml"
            this.cboEgyesuletTagokVerseny.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cboEgyesuletTagokVerseny_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 52 "..\..\..\..\..\Megjelenites\Egyesület\Egyesulet_Tagok.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnEgysuletTagokClear_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

