﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CAFABDD9C06873D078BA16FB1DAC753DFE926223"
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
using emlekmu;
using emlekmu.commands;


namespace emlekmu {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding AddMonumentCommand;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding AddTypeCommand;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding AddTagCommand;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal emlekmu.MainContent MainContent;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApplication1;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.AddMonumentCommand = ((System.Windows.Input.CommandBinding)(target));
            
            #line 11 "..\..\MainWindow.xaml"
            this.AddMonumentCommand.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.AddMonumentCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 11 "..\..\MainWindow.xaml"
            this.AddMonumentCommand.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.AddMonumentCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AddTypeCommand = ((System.Windows.Input.CommandBinding)(target));
            
            #line 12 "..\..\MainWindow.xaml"
            this.AddTypeCommand.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.AddTypeCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 12 "..\..\MainWindow.xaml"
            this.AddTypeCommand.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.AddTypeCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddTagCommand = ((System.Windows.Input.CommandBinding)(target));
            
            #line 13 "..\..\MainWindow.xaml"
            this.AddTagCommand.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.AddTagCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 13 "..\..\MainWindow.xaml"
            this.AddTagCommand.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.AddTagCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 4:
            this.EditMonumentCommand = ((System.Windows.Input.CommandBinding)(target));
            
            #line 14 "..\..\MainWindow.xaml"
            this.EditMonumentCommand.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.EditMonumentCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 14 "..\..\MainWindow.xaml"
            this.EditMonumentCommand.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.EditMonumentCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RemoveMonumentCommand = ((System.Windows.Input.CommandBinding)(target));
            
            #line 15 "..\..\MainWindow.xaml"
            this.RemoveMonumentCommand.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.RemoveMonumentCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 15 "..\..\MainWindow.xaml"
            this.RemoveMonumentCommand.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.RemoveMonumentCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MainContent = ((emlekmu.MainContent)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

