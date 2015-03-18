using PatternEditor_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace PatternEditor_MVVM.ViewModel
{
    public abstract class PatternFileViewModel : EditorFileViewModel
    {
        #region Fields                
        PatternFile _patternFile;
        RelayCommand _cancelCommand;        
        bool uIEnableFlag;
        
        #endregion //Fields
                
        #region Constructor
        
        public PatternFileViewModel(PatternFile patternFile) : base(patternFile)
        {
            if (patternFile == null)
                throw new ArgumentNullException("editorFile");

            _patternFile = patternFile;           
            uIEnableFlag = true;
        }

        #endregion // Constructor  

        public bool UIEnableFlag
        {
            get { return this.uIEnableFlag; }
            set
            {
                if (value == this.uIEnableFlag)
                    return;

                this.uIEnableFlag = value;

                base.OnPropertyChanged("UIEnableFlag");
            }
        }

        #region AbstarctActions

        public abstract void CancelBackgroundWork();

        #endregion //AbstarctActions

        #region CancelCommand
        /// <summary>
        /// Returns a command that cancels the file operation.
        /// </summary>
        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new RelayCommand(
                        param => this.CancelBackgroundWork());
                }
                return _cancelCommand;
            }
        }

        #endregion // CancelCommand
    }
}
