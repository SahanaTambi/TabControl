using System;
using System.ComponentModel;
using System.Linq;
using System.Diagnostics;

namespace PatternEditor_MVVM.Model
{
    public abstract class EditorFile : IDataErrorInfo
    {        
        #region Creation
        
        protected EditorFile()
        {            
        }
        #endregion //Contructor

        #region State Properties

        /// <summary>
        /// Gets/sets the Fragment length of the Editorfile name
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets/sets the DisplayFileName of the Editorfile.
        /// </summary>       
        public string DisplayFileName { get; set; }

        /// <summary>
        /// Gets/sets the TemFileName of the Editorfile.
        /// </summary>       
        //public string TempFileName { get; set; }

        public MvvmTextEditor FileDataContent { get; set; } 

        /// <summary>
        /// Gets/sets the DataContent of the Editorfile name
        /// </summary>
        public string DataContent { get; set; }
                
        #endregion // State Properties

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        #endregion // IDataErrorInfo Members

        #region Validation

        static readonly string[] ValidatedProperties = 
        { 
            "FilePath",  
            "DataContent"
        };        

        string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;

            string error = null;

            switch (propertyName)
            {
                case "FilePath":
                    error = this.ValidateFilePath();
                    break;               

                case "DataContent":
                    error = this.ValidateDataContent();
                    break;

                default:
                    Debug.Fail("Unexpected property being validated on EditorFile: " + propertyName);
                    break;
            }

            return error;
        }


        string ValidateFilePath()
        { return null; }

        string ValidateDataContent()
        { return null; }
        
        #endregion // Validation

    }
}
