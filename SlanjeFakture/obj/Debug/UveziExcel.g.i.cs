﻿#pragma checksum "..\..\UveziExcel.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1A794F8111B2136D3C148A741CD56DE8D3C53176D4047BD48ED3E30935A85051"
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
using SlanjeFakture.LinqToSql;
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


namespace SlanjeFakture.LinqToSql {
    
    
    /// <summary>
    /// UveziExcel
    /// </summary>
    public partial class UveziExcel : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\UveziExcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridProizvoda;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\UveziExcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbOdaberi;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\UveziExcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOdaberi;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\UveziExcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUvezi;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\UveziExcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSacuvaj;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\UveziExcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNazad;
        
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
            System.Uri resourceLocater = new System.Uri("/SlanjeFakture;component/uveziexcel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UveziExcel.xaml"
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
            this.gridProizvoda = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.tbOdaberi = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnOdaberi = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\UveziExcel.xaml"
            this.btnOdaberi.Click += new System.Windows.RoutedEventHandler(this.btnOdaberi_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnUvezi = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\UveziExcel.xaml"
            this.btnUvezi.Click += new System.Windows.RoutedEventHandler(this.btnUvezi_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnSacuvaj = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.btnNazad = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\UveziExcel.xaml"
            this.btnNazad.Click += new System.Windows.RoutedEventHandler(this.btnNazad_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
