using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatternEditor_MVVM.Model;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace PatternEditor_MVVM.ViewModel
{
    public class TextFileViewModel : EditorFileViewModel
    {
        TextFile _txtFile;        

        #region Constructor

        public TextFileViewModel(TextFile txtFile)
            : base(txtFile)
        {
            if (txtFile == null)
                throw new ArgumentNullException("txtFile");

            _txtFile = txtFile;
           
        }

        #endregion // Constructor

        public override string DisplayName
        {
            get
            {
                if (this.IsFileDirty && File.Exists(ExtractFileName(_txtFile.FilePath)))
                {
                    return _txtFile.FilePath = ExtractFileName(_txtFile.FilePath);
                }
                else
                {
                    return ExtractFileName(_txtFile.FilePath);
                }
            }
        }

        public override void Save()
        {

            if (this.IsFileNew)
            {
                SaveAs();
                this.SetNewFileFlag(false);
                return;
            }
            
            if (this.IsFileDirty)
            {                
                if (!string.IsNullOrWhiteSpace(this.FilePath))
                    {
                        _txtFile.FilePath = this.FilePath.TrimEnd(new Char[] { '*' });
                        File.WriteAllText(this.FilePath, DataContent);
                        base.OnPropertyChanged("DisplayName");
                    }
                
            }
            else
            {
                File.WriteAllText(FilePath, DataContent);
                MessageBox.Show("File saved successfully", "Save");
            }
        }

        public override void SaveAs()
        {
            SaveFileDialog dlg = new SaveFileDialog();

            if (!string.IsNullOrWhiteSpace(this.FilePath))
                dlg.FileName = this.FilePath;

            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text Files(*.txt)|*.txt";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                if (!string.IsNullOrWhiteSpace(dlg.FileName))
                {
                    File.WriteAllText(dlg.FileName, DataContent);

                    _txtFile.FilePath = dlg.FileName;

                    base.OnPropertyChanged("DisplayName");
                    MessageBox.Show("File saved successfully", "Save");
                }
            }            
        }

        #region RequestClose

        public override void OnRequestClose()
        {
            //check to see that the file is not Dirty
            if (this.IsFileDirty)
            {
                MessageBoxResult result = MessageBoxResult.OK;
                result = MessageBox.Show("Close the file without saving changes?", "Save File Warning", MessageBoxButton.OKCancel);

                if (result != MessageBoxResult.OK)
                {
                    if (SaveCommand.CanExecute(null))
                    {
                        SaveCommand.Execute(null);
                        _txtFile.FilePath = _txtFile.FilePath.TrimEnd('*');
                        base.OnPropertyChanged("DisplayName");
                    }
                    
                    return;
                }
            }
            
            base.OnRequestClose();
        }

        #endregion // RequestClose

    }
}
