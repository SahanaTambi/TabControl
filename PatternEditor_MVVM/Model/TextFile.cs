using System;
using System.Linq;

namespace PatternEditor_MVVM.Model
{
    public class TextFile : EditorFile
    {
        #region Contructor

        public static TextFile CreateNewTextFile()
        {
            return new TextFile();
        }

        public static TextFile CreateTextFile(
            string filePath,
            string dataContent
            )
        {
            return new TextFile
            {
                FilePath = filePath,
                DataContent = dataContent,
            };
        }

        protected TextFile()
        {
        }
        #endregion //Contructor
    }
}
