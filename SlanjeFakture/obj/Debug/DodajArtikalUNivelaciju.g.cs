﻿#pragma checksum "..\..\DodajArtikalUNivelaciju.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F36460D1B84E1BF75D4CDF35AAF6C9B7D13CC29B4DDF7769A325BC18723BF9DE"
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
    /// DodajArtikalUNivelaciju
    /// </summary>
    public partial class DodajArtikalUNivelaciju : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\DodajArtikalUNivelaciju.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPretraga;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\DodajArtikalUNivelaciju.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbArtikli;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\DodajArtikalUNivelaciju.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUnesi;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\DodajArtikalUNivelaciju.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOtkazi;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\DodajArtikalUNivelaciju.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridProizvodaMagacin;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\DodajArtikalUNivelaciju.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnObrisiRed;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\DodajArtikalUNivelaciju.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbPovecajCenu;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\DodajArtikalUNivelaciju.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbUmanjiCenu;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\DodajArtikalUNivelaciju.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbDodajZaradu;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\DodajArtikalUNivelaciju.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbUnesiCenu;
        
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
            System.Uri resourceLocater = new System.Uri("/SlanjeFakture;component/dodajartikalunivelaciju.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DodajArtikalUNivelaciju.xaml"
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
            this.tbPretraga = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\DodajArtikalUNivelaciju.xaml"
            this.tbPretraga.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbPretraga_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lbArtikli = ((System.Windows.Controls.ListBox)(target));
            
            #line 25 "..\..\DodajArtikalUNivelaciju.xaml"
            this.lbArtikli.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.lbArtikli_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnUnesi = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\DodajArtikalUNivelaciju.xaml"
            this.btnUnesi.Click += new System.Windows.RoutedEventHandler(this.btnUnesi_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnOtkazi = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\DodajArtikalUNivelaciju.xaml"
            this.btnOtkazi.Click += new System.Windows.RoutedEventHandler(this.btnOtkazi_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.gridProizvodaMagacin = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.btnObrisiRed = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\DodajArtikalUNivelaciju.xaml"
            this.btnObrisiRed.Click += new System.Windows.RoutedEventHandler(this.btnObrisiRed_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.rbPovecajCenu = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.rbUmanjiCenu = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.rbDodajZaradu = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 10:
            this.tbUnesiCenu = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
