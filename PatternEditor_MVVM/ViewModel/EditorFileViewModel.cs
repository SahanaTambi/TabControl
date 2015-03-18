using System;
using System.Windows.Input;
using PatternEditor_MVVM.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace PatternEditor_MVVM.ViewModel
{
    /// <summary>
    /// This ViewModelBase subclass requests to be removed 
    /// from the UI when its CloseCommand executes.
    /// This class is abstract.
    /// </summary>
    public abstract class EditorFileViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Fields

        RelayCommand _saveCommand, _saveAsCommand, _closeCommand;// _parseCommand, _errorCommand;
        EditorFile _editorFile;
        bool isFileDirty, isFileNew, internalChange=false;              
        #endregion // Fields

        #region Constructor
        
        public EditorFileViewModel(EditorFile editorFile)
        {
            if (editorFile == null)
                throw new ArgumentNullException("editorFile");

            _editorFile = editorFile;                   
        }

        #endregion // Constructor        
        
        #region CloseCommand

        /// <summary>
        /// Returns the command that, when invoked, attempts
        /// to remove this workspace from the user interface.
        /// </summary>
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new RelayCommand(param => this.OnRequestClose());

                return _closeCommand;
            }
        }

        #endregion // CloseCommand
        
        #region RequestClose [event]

        /// <summary>
        /// Raised when this EditorFielVM should be removed from the UI.
        /// </summary>
        public event EventHandler RequestClose;

        //public void OnRequestClose();

        public virtual void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion // RequestClose [event]

        #region SaveCommand
        /// <summary>
        /// Returns a command that saves the file.
        /// </summary>
        public ICommand SaveCommand 
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(
                        param => this.Save(),
                        param => this.CanSave
                        );
                }
                return _saveCommand;
            }
        
        }
        #endregion // SaveCommand 

        #region SaveAsCommand
        /// <summary>
        /// Returns a command that saves the file.
        /// </summary>
        public ICommand SaveAsCommand 
        {
            get
            {
                if (_saveAsCommand == null)
                {
                    _saveAsCommand = new RelayCommand(
                        param => this.SaveAs(),
                        param => this.CanSave
                        );
                }
                return _saveAsCommand;
            }
        
        }
        #endregion // SaveAsCommand         

        #region Public Methods

        /// <summary>
        /// Saves the EditorFile.  This method is invoked by the SaveCommand.
        /// </summary>
        public abstract void Save();

        public abstract void SaveAs();

        //public abstract void Parse();

        //public abstract void DisplayErrors();

        //public abstract bool DisplayFormatChanged(DisplayFormat prevFormat, DisplayFormat currFormat);

        public void SetNewFileFlag(bool value)
        {
            this.isFileNew = value;
        }

        #endregion // Public Methods

        #region Helpers
        /// <summary>
        /// Returns true if the File is valid, parsed succesfully and can be saved.
        /// </summary>
        protected bool CanSave
        {
            get { return this.ValidateFileToSave(); }
        }

        protected bool CanPrint
        {
            get { return this.ValidateFileToPrint(); }
        }

        //bool CanParse
        //{
        //    get { return this.ValidateFileToParse(); }
        //}

        //bool CanDisplayErrors
        //{
        //    get { return this.ValidateFileToDisplayErrors(); }
        //}

        protected string ExtractFileName(string filePath)
        {
            int position = filePath.LastIndexOf('\\');
            return filePath.Substring(position + 1);
        }

        bool ValidateFileToPrint()
        {
            if (!string.IsNullOrWhiteSpace(this.DataContent))
            {                
                return true;             
            }
            return false;
        }

        bool ValidateFileToSave()
        {
            if (!string.IsNullOrWhiteSpace(this.DataContent))
            {
                //if (this.ParserStatus == ParserStatusEnum.CompleteSuccess)
                    return true;
                //else
                //{
                //    //Parse here and return true or false based on errors  
                //    this.Parse();

                //    if (this.ParserStatus == ParserStatusEnum.CompleteSuccess)
                //        return true;
                //    else
                //        return false;
                //}
            }
            return false;
        }

        public bool IsFileDirty
        {
            get { return this.isFileDirty; }

            set
            {
                if (value != this.isFileDirty)
                    this.isFileDirty = value;
            }
        }

        protected bool IsFileNew
        {
            get { return this.isFileNew; }

            set
            {
                if (value != this.isFileNew)
                    this.isFileNew = value;
            }
        }        
        #endregion//Helpers

        /// <summary>
        /// Returns true if this customer was created by the user and it has not yet
        /// been saved to the customer repository.
        /// </summary>       


        public string FilePath 
		{
            get { return _editorFile.FilePath; }
            set
            {
                if (value == _editorFile.FilePath)
                    return;

                _editorFile.FilePath = value;

                base.OnPropertyChanged("FilePath");
            }
        }
        
        public bool InternalChange
        {
            get { return this.internalChange; }
            set
            {
                if (value == this.internalChange)
                    return;

                this.internalChange = value;

                base.OnPropertyChanged("InternalChange");
            }
        }                          

        public string DataContent
        {
            get { return _editorFile.DataContent; }
            set
            {
                if (value == _editorFile.DataContent)
                    return;

                _editorFile.DataContent = value;

                if (!internalChange)
                {  
                    isFileDirty = true;
                    UpdateTabHeader();
                }
                else
                    this.internalChange = false;

                base.OnPropertyChanged("DataContent");
            }
        }

        //public void 

        public void UpdateTabHeader() 
        {
            if (!_editorFile.FilePath.Contains("*"))
            {
                _editorFile.FilePath = _editorFile.FilePath + "*";
                //base.OnPropertyChanged("FilePath");
                DisplayName = ExtractFileName(_editorFile.FilePath);
                base.OnPropertyChanged("DisplayName");
            }           
        }

        public int DisplayFileName
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get { return (_editorFile as IDataErrorInfo).Error; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                string error = null;

                //need to change this
                if (propertyName == "DataContent")
                {
                    // The IsCompany property of the EditorFile class 
                    // is Boolean, so it has no concept of being in
                    // an "unselected" state.  The SegmentFileViewModel
                    // class handles this mapping and validation.
                    //error = this.ValidateCustomerType();
                }
                else
                {
                    error = (_editorFile as IDataErrorInfo)[propertyName];
                }

                // Dirty the commands registered with CommandManager,
                // such as our Save command, so that they are queried
                // to see if they can execute now.
                CommandManager.InvalidateRequerySuggested();

                return error;
            }
        }

        #endregion // IDataErrorInfo Members
       
    }
}