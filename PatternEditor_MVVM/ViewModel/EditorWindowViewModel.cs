using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using PatternEditor_MVVM.Model;
using System.Windows.Input;
using System.Windows;
using System.Windows.Data;
using Microsoft.Win32;
using System.IO;

namespace PatternEditor_MVVM.ViewModel
{
    /// <summary>
    /// The ViewModel for the application's EditorView window.
    /// </summary>
    public class EditorWindowViewModel : ViewModelBase
    {
        const int DEFAULT_WIDTH = 128;

        #region Fields

        RelayCommand _openCommand, _exitCommand,  _closeCommand;        
        ObservableCollection<EditorFileViewModel> _editorFileVM;        
        EditorFileViewModel currentVM;
        
        #endregion // Fields

        #region Constructor

        public EditorWindowViewModel(string EditorWindowViewModel_DisplayName)
        {
            base.DisplayName = EditorWindowViewModel_DisplayName;            
        }

        #endregion // Constructor

        #region OpenCommand

        /// <summary>
        /// Returns the command that, when invoked, attempts
        /// to open a editor file from the user interface.
        /// </summary>
        public ICommand OpenCommand
        {
            get
            {
                if (_openCommand == null)
                    _openCommand = new RelayCommand(
                        param => this.OpenFile());

                return _openCommand;
            }
        }       

        #endregion // OpenCommand

        #region CloseCommand

        /// <summary>
        /// Returns the command that, when invoked, attempts
        /// to open a editor file from the user interface.
        /// </summary>
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new RelayCommand(param => this.ExitApplication());

                return _closeCommand;
            }
        }

        #endregion // CloseCommand

        #region ExitCommand

        /// <summary>
        /// Returns the command that, when invoked, attempts
        /// to open a editor file from the user interface.
        /// </summary>
        public ICommand ExitCommand
        {
            get
            {
                if (_exitCommand == null)
                    _exitCommand = new RelayCommand(param => this.ExitApplication());

                return _exitCommand;
            }
        }

        #endregion // OpenCommand
        
        #region EditorFileVM

        /// <summary>
        /// Returns the collection of available EditorFileVM to display.
        /// A 'EditorFileVM' is a ViewModel that can request to be closed.
        /// </summary>
        public ObservableCollection<EditorFileViewModel> EditorFileVM
        {
            get
            {
                if (_editorFileVM == null)
                {
                    _editorFileVM = new ObservableCollection<EditorFileViewModel>();
                    _editorFileVM.CollectionChanged += this.OnEditorFileVMChanged;                    
                }
                return _editorFileVM;
            }
        }

        void OnEditorFileVMChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ///selectedIndex += 1; 
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (EditorFileViewModel editorFileVM in e.NewItems)
                {
                    editorFileVM.RequestClose += this.OnEditorFileVMRequestClose;                    
                }

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (EditorFileViewModel editorFileVM in e.OldItems)
                {
                    editorFileVM.RequestClose -= this.OnEditorFileVMRequestClose;
                }
        }
        
        void OnEditorFileVMRequestClose(object sender, EventArgs e)
        {
            //selectedIndex -= 1; 
            EditorFileViewModel editorFileVM = sender as EditorFileViewModel;
            editorFileVM.Dispose();
            this.EditorFileVM.Remove(editorFileVM);
        }
        #endregion // EditorFileVM
        
        #region Private Helpers       

        void OpenFile()
        {
            //need to change
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text Files(*.txt)|*.txt";

            Nullable<bool> result = dlg.ShowDialog();

            if (_editorFileVM.Any(vm => vm.FilePath == dlg.FileName))
            {
                string message = "File with name " + dlg.FileName  +" already open in one of the tabs.";
                //move this to message control
                MessageBox.Show(message, "DuplicateFileOpenAttempt");
                return;
            }

            if (result == true)
            {
                if (File.Exists(dlg.FileName))
                {
                    EditorFileViewModel newFileVM = null;
                    string content = File.ReadAllText(dlg.FileName);
                    switch (Path.GetExtension(dlg.FileName))
                    {
                        case ".txt":
                            OpenTextFile(newFileVM, content, dlg);
                            break;
                    }
                }
                else
                {
                    //move this to message control
                    MessageBox.Show("NoSuch file exsists", "OpenError");
                }

            } 
        }

        void OpenTextFile(EditorFileViewModel newFileVM, string content, OpenFileDialog dlg)
        {
            TextFile txtFile = TextFile.CreateTextFile(dlg.FileName, content);
            newFileVM = new TextFileViewModel(txtFile);
            this.EditorFileVM.Add(newFileVM);
            this.SetActiveEditorFileVM(newFileVM);
        }

        void ExitApplication()
        { 
            //make sure all temp files and other objects are deleted 
            Application.Current.Shutdown();
        }

        void SetActiveEditorFileVM(EditorFileViewModel editorFileVM)
        {
            Debug.Assert(this.EditorFileVM.Contains(editorFileVM));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.EditorFileVM);
            //collectionView.CurrentChanging += this.OnEditorFileActiveVMChanging;
            
            collectionView.CurrentChanged += this.OnEditorFileActiveVMChanged;
            if (collectionView != null)
                collectionView.MoveCurrentTo(editorFileVM);
        }

        void OnEditorFileActiveVMChanging(object sender, CurrentChangingEventArgs e)
        {
            object test = sender;
        }

        public void OnEditorFileActiveVMChanged(object sender, System.EventArgs e)
        {
            ICollectionView test = (ICollectionView)sender;
            currentVM = (EditorFileViewModel)test.CurrentItem;
            if (currentVM != null)
            {
                
            }
            else
            {           
                
            }
        }
        #endregion // Private Helpers

    }
}