﻿#pragma checksum "..\..\..\View\AscFileView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EEB4FA7CD8D23B109B1E03450ED1B03F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PatternEditor_MVVM;
using PatternEditor_MVVM.Behaviors;
using PatternEditor_MVVM.Model;
using PatternEditor_MVVM.View;
using PatternEditor_MVVM.ViewModel;
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
using System.Windows.Interactivity;
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


namespace PatternEditor_MVVM.View {
    
    
    /// <summary>
    /// AscFileView
    /// </summary>
    public partial class AscFileView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\View\AscFileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.StatusBar StatusBar;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\View\AscFileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar ProgressBar;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\View\AscFileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FStatus;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\View\AscFileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelBtn;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\View\AscFileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FillOptions;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\View\AscFileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SendOptions;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\View\AscFileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton SendToGen;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\View\AscFileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton SendToDet;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\View\AscFileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton SendToBoth;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\View\AscFileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PatternEditor_MVVM.Model.MvvmTextEditor EditorTextBlock;
        
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
            System.Uri resourceLocater = new System.Uri("/PatternEditor_MVVM;component/view/ascfileview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\AscFileView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.StatusBar = ((System.Windows.Controls.Primitives.StatusBar)(target));
            return;
            case 2:
            this.ProgressBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 3:
            this.FStatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.CancelBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.FillOptions = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.SendOptions = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.SendToGen = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.SendToDet = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.SendToBoth = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 10:
            this.EditorTextBlock = ((PatternEditor_MVVM.Model.MvvmTextEditor)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

