using Surfer.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Surfer.Controls
{
    public class SBTextBox: TextBox
    {
        public delegate bool CanAddUndoRedoEvent(string text);

        private CanAddUndoRedoEvent _canAddUndoRedoEvent = new CanAddUndoRedoEvent((text) => true);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Bindable(false)]
        [Browsable(false)]
        public CanAddUndoRedoEvent CanAddUndoRedo
        {
            get
            {
                return _canAddUndoRedoEvent;
            }
            set
            {
                if (value == null)
                    throw new Exception("CanAddUndoRedo can not be null");
                else
                    _canAddUndoRedoEvent = value;
            }
        }

        public bool TrimPaste
        {
            get;
            set;
        } = false;

        private bool ShouldSerializeTrimPaste()
        {
            return TrimPaste;
        }
        private void ResetVisualTrimPaste()
        {
            TrimPaste = true;
        }

        private bool _isUndoRedo = false;
        private int _undoRedoCurrentIndex = 0;
        private List<string> _undoRedoList = new List<string>() {
            ""
        };

        public SBTextBox()
        {
            CanAddUndoRedo = _canAddUndoRedoEvent;
            TextChanged += SBTextBox_TextChanged;
        }

        private void SBTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!_isUndoRedo && CanAddUndoRedo(Text))
            {
                ClearRedo();
                if (_undoRedoList[_undoRedoList.Count - 1] != Text)
                {
                    _undoRedoList.Add(Text);
                    _undoRedoCurrentIndex = _undoRedoList.Count - 1;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Bindable(false)]
        [Browsable(false)]
        public new bool CanUndo
        {
            get
            {
                return _undoRedoCurrentIndex - 1 >= 0;
            }
        }

        public new void Undo()
        {
            _isUndoRedo = true;
            if (CanUndo)
            {
                _undoRedoCurrentIndex -= 1;
                SetUndoRedoText();
            }
            _isUndoRedo = false;
        }

        public new void ClearUndo()
        {
            for (int i = 0; i < _undoRedoCurrentIndex; i++)
                _undoRedoList.RemoveAt(i);
            SetFirstItem();
            _undoRedoCurrentIndex = 0;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Bindable(false)]
        [Browsable(false)]
        public bool CanRedo
        {
            get
            {
                return _undoRedoCurrentIndex + 1 < _undoRedoList.Count;
            }
        }

        public void Redo()
        {
            _isUndoRedo = true;
            if (CanRedo)
            {
                _undoRedoCurrentIndex += 1;
                SetUndoRedoText();
            }
            _isUndoRedo = false;
        }

        public void ClearRedo()
        {
            for (int i = _undoRedoCurrentIndex + 1; i < _undoRedoList.Count; i++)
                _undoRedoList.RemoveAt(i);
            SetFirstItem();
            _undoRedoCurrentIndex = _undoRedoList.Count - 1;
        }

        private void SetUndoRedoText()
        {
            bool _isSelectedAll = SelectionLength == Text.Length;
            Text = _undoRedoList[_undoRedoCurrentIndex];
            if (_isSelectedAll)
                SelectAll();
            else
                SelectionStart = Text.Length;
        }

        private void SetFirstItem()
        {
            if (_undoRedoList.Count == 0)
                _undoRedoList.Add("");
            else
            {
                if (_undoRedoList[0] != "")
                    _undoRedoList.Insert(0, "");
            }
        }
        public new void Paste()
        {
            string originalText = Clipboard.GetText();
            if (TrimPaste)
                Clipboard.SetText(originalText.TrimAdvanced());
            base.Paste();
            if(TrimPaste)
                Clipboard.SetText(originalText);
        }
    }
}
