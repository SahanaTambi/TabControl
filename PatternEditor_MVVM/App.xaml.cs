using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace PatternEditor_MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow app = new MainWindow();
            PatternEditor_MVVM.ViewModel.EditorWindowViewModel context = new PatternEditor_MVVM.ViewModel.EditorWindowViewModel("Pattern Editor");
            app.DataContext = context;
            app.Show();
        }
    }
}
