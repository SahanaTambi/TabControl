using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interactivity;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;

namespace PatternEditor_MVVM.Behaviors
{
    public sealed class AvalonEditBehaviour : Behavior<TextEditor>
    {
        /// <summary>
        /// DependencyProperty to provide access to the Text property of the 
        /// AvalonEditor Document.Text.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(AvalonEditBehaviour),
            new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PropertyChangedCallback));

        public static readonly DependencyProperty CaretProperty =
          DependencyProperty.Register("Caret", typeof(ICSharpCode.AvalonEdit.Editing.Caret), typeof(AvalonEditBehaviour));//,
          //new FrameworkPropertyMetadata(default(ICSharpCode.AvalonEdit.Editing.Caret), FrameworkPropertyMetadataOptions.None, PropertyChangedCallback));

        /// <summary>
        /// The accessor for TextProperty DP.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public ICSharpCode.AvalonEdit.Editing.Caret Caret
        {
            get { return (ICSharpCode.AvalonEdit.Editing.Caret)GetValue(CaretProperty); }
            set { SetValue(CaretProperty, value); }
        }

        /// <summary>
        /// Called when the ascociated DP is attached.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            if (AssociatedObject != null)
            {
                AssociatedObject.TextChanged += AssociatedObjectOnTextChanged;
                AssociatedObject.TextArea.Caret.PositionChanged += AssociatedObjectOnCaretChanged;
            }
        }

        /// <summary>
        /// Called when the ascociated DP is detached.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (AssociatedObject != null)
            {
                AssociatedObject.TextChanged -= AssociatedObjectOnTextChanged;
                AssociatedObject.TextArea.Caret.PositionChanged -= AssociatedObjectOnCaretChanged;
            }
        }

        /// <summary>
        /// Fires when the editor text is changed from the View.
        /// </summary>
        private void AssociatedObjectOnTextChanged(object sender, EventArgs eventArgs)
        {
            TextEditor textEditor = sender as TextEditor;
            if (textEditor != null)
            {
                if (textEditor.Document != null)
                    Text = textEditor.Document.Text;
            }
        }

        private void AssociatedObjectOnCaretChanged(object sender, EventArgs eventArgs)
        {
            //TextEditor textEditor = sender as TextEditor;
            if(sender != null)
                Caret = sender as Caret;

            //if(textEditor != null)
            //{            
            //    if (textEditor.TextArea.Caret != null)
            //        Caret = textEditor.TextArea.Caret;
            //}
        }
        /// <summary>
        /// Fires when the text property is updated from the ViewModel.
        /// </summary>
        /// <param name="dependencyObject">Object that holds the instance of this class.</param>
        /// <param name="dependencyPropertyChangedEventArgs">The required args.</param>
        private static void PropertyChangedCallback(
            DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            TextEditor editor = ((AvalonEditBehaviour)dependencyObject).AssociatedObject as TextEditor;
            if (editor != null)
            {
                if (editor.Document.Text != null)
                {
                    string updateText = String.Empty;
                    if (dependencyPropertyChangedEventArgs.NewValue != null)
                        updateText = dependencyPropertyChangedEventArgs.NewValue.ToString();
                    if (!updateText.Equals(editor.Document.Text))
                        editor.Document.Text = updateText;
                }               
            }
        }
    }
}
