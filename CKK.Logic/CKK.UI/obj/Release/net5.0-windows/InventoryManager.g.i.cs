﻿#pragma checksum "..\..\..\InventoryManager.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7D45990DDBFB934C5C653363BDBC90010F5EDF3A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CKK.UI;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace CKK.UI {
    
    
    /// <summary>
    /// InventoryManager
    /// </summary>
    public partial class InventoryManager : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 57 "..\..\..\InventoryManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimize;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\InventoryManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\InventoryManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addButton;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\InventoryManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button removeButton;
        
        #line default
        #line hidden
        
        
        #line 189 "..\..\..\InventoryManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbInventoryList;
        
        #line default
        #line hidden
        
        
        #line 196 "..\..\..\InventoryManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchBox;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\..\InventoryManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchButton;
        
        #line default
        #line hidden
        
        
        #line 237 "..\..\..\InventoryManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sortQ;
        
        #line default
        #line hidden
        
        
        #line 271 "..\..\..\InventoryManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sortPButton;
        
        #line default
        #line hidden
        
        
        #line 305 "..\..\..\InventoryManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button refreshButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CKK.UI;component/inventorymanager.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\InventoryManager.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\InventoryManager.xaml"
            ((CKK.UI.InventoryManager)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\InventoryManager.xaml"
            this.btnMinimize.Click += new System.Windows.RoutedEventHandler(this.btnMinimize_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\..\InventoryManager.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.addButton = ((System.Windows.Controls.Button)(target));
            
            #line 129 "..\..\..\InventoryManager.xaml"
            this.addButton.Click += new System.Windows.RoutedEventHandler(this.addButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.removeButton = ((System.Windows.Controls.Button)(target));
            
            #line 163 "..\..\..\InventoryManager.xaml"
            this.removeButton.Click += new System.Windows.RoutedEventHandler(this.removeButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lbInventoryList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.searchBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.searchButton = ((System.Windows.Controls.Button)(target));
            
            #line 213 "..\..\..\InventoryManager.xaml"
            this.searchButton.Click += new System.Windows.RoutedEventHandler(this.searchButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.sortQ = ((System.Windows.Controls.Button)(target));
            
            #line 243 "..\..\..\InventoryManager.xaml"
            this.sortQ.Click += new System.Windows.RoutedEventHandler(this.sortQ_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.sortPButton = ((System.Windows.Controls.Button)(target));
            
            #line 277 "..\..\..\InventoryManager.xaml"
            this.sortPButton.Click += new System.Windows.RoutedEventHandler(this.sortP_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.refreshButton = ((System.Windows.Controls.Button)(target));
            
            #line 311 "..\..\..\InventoryManager.xaml"
            this.refreshButton.Click += new System.Windows.RoutedEventHandler(this.refreshButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
