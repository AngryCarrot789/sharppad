﻿using SharpPad.Notepad;
using SharpPad.Utilities;
using System;

namespace SharpPad.Finding.NotepadItemFinding
{
    public class FoundNotepadItemViewModel : BaseViewModel
    {
        private NotepadItemViewModel _notepad;
        public NotepadItemViewModel Notepad
        {
            get => _notepad;
            set => RaisePropertyChanged(ref _notepad, value);
        }

        public Action<FoundNotepadItemViewModel> SelectNotepadCallback { get; set; }

        public void Select()
        {
            SelectNotepadCallback?.Invoke(this);
        }
    }
}
