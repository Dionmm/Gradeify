﻿#pragma checksum "..\..\DisplayStudents.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E7D511552245004E9058C440A4B97263"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Coursework;
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


namespace Coursework {
    
    
    /// <summary>
    /// DisplayStudents
    /// </summary>
    public partial class DisplayStudents : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\DisplayStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid studentGrid;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\DisplayStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Header;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\DisplayStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox studentListBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\DisplayStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label studentName;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\DisplayStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label studentMatric;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\DisplayStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label studentCom1;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\DisplayStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label studentCom2;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\DisplayStudents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label studentCom3;
        
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
            System.Uri resourceLocater = new System.Uri("/Coursework;component/displaystudents.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DisplayStudents.xaml"
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
            this.studentGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Header = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.studentListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 27 "..\..\DisplayStudents.xaml"
            this.studentListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.editSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.studentName = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.studentMatric = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.studentCom1 = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.studentCom2 = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.studentCom3 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

