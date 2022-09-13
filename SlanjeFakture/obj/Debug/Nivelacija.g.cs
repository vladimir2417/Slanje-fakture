﻿#pragma checksum "..\..\Nivelacija.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "47E0FDEEA0523E0F5EFD5FEE6EB65E17EF521BF889917F96C0009D3C93E751B2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using SlanjeFakture;
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


namespace SlanjeFakture {
    
    
    /// <summary>
    /// Nivelacija
    /// </summary>
    public partial class Nivelacija : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\Nivelacija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridProizvodaNivelacija;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Nivelacija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnObrisiRed;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Nivelacija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpisi;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Nivelacija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSacuvaj;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Nivelacija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNazad;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Nivelacija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDatumNivelacije;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Nivelacija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbBrojNivelacije;
        
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
            System.Uri resourceLocater = new System.Uri("/SlanjeFakture;component/nivelacija.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Nivelacija.xaml"
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
            this.gridProizvodaNivelacija = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.btnObrisiRed = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\Nivelacija.xaml"
            this.btnObrisiRed.Click += new System.Windows.RoutedEventHandler(this.btnObrisiRed_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnUpisi = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\Nivelacija.xaml"
            this.btnUpisi.Click += new System.Windows.RoutedEventHandler(this.btnUpisi_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnSacuvaj = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\Nivelacija.xaml"
            this.btnSacuvaj.Click += new System.Windows.RoutedEventHandler(this.btnSacuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnNazad = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\Nivelacija.xaml"
            this.btnNazad.Click += new System.Windows.RoutedEventHandler(this.btnNazad_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dpDatumNivelacije = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.tbBrojNivelacije = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
