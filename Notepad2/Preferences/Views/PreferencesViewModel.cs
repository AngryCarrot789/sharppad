﻿using SharpPad.InformationStuff;
using SharpPad.Utilities;
using System;
using System.Windows.Input;

namespace SharpPad.Preferences.Views
{
    public class PreferencesViewModel : BaseViewModel
    {
        private bool _scrollVerticalCtrlArrows;
        private bool _scrollHorizontalCtrlArrows;
        private bool _scrollHorizontalShiftMWheel;

        private bool _cutLineCtrlX;
        private bool _copyLineCtrlC;
        private bool _selectLineCtrlShiftA;
        private bool _addLineCtrlEnter;

        private bool _zoomEditorCtrlMWheel;

        private bool _wrapTextByDefault;

        private bool _canCloseWinWithCtrlWShift;
        private bool _canReOpenWinWithCtrlShiftT;

        private bool _closeNotepadListByDefault;

        private bool _useNewDragDropSystem;

        private bool _saveOpenUnclosedFiles;

        private bool _useWordCounterByDefault;

        private bool _checkFileNamesForChanges;
        private bool _unsetSetting2;
        private bool _unsetSetting3;
        private bool _unsetSetting4;
        private bool _unsetSetting5;
        private bool _unsetSetting6;

        public bool ScrollVerticallyCtrlArrowKeys
        {
            get => _scrollVerticalCtrlArrows;
            set => RaisePropertyChanged(ref _scrollVerticalCtrlArrows, value);
        }

        public bool ScrollHorizontallyCtrlArrowKeys
        {
            get => _scrollHorizontalCtrlArrows;
            set => RaisePropertyChanged(ref _scrollHorizontalCtrlArrows, value);
        }

        public bool ScrollHorizontallyShiftMouseWheel
        {
            get => _scrollHorizontalShiftMWheel;
            set => RaisePropertyChanged(ref _scrollHorizontalShiftMWheel, value);
        }


        public bool CutEntireLineCtrlX
        {
            get => _cutLineCtrlX;
            set => RaisePropertyChanged(ref _cutLineCtrlX, value);
        }

        public bool CopyEntireLineCtrlC
        {
            get => _copyLineCtrlC;
            set => RaisePropertyChanged(ref _copyLineCtrlC, value);
        }

        public bool SelectEntireLineCtrlShiftA
        {
            get => _selectLineCtrlShiftA;
            set => RaisePropertyChanged(ref _selectLineCtrlShiftA, value);
        }

        public bool AddEntireLineCtrlEnter
        {
            get => _addLineCtrlEnter;
            set => RaisePropertyChanged(ref _addLineCtrlEnter, value);
        }


        public bool ZoomEditorCtrlScrollwheel
        {
            get => _zoomEditorCtrlMWheel;
            set => RaisePropertyChanged(ref _zoomEditorCtrlMWheel, value);
        }


        public bool WrapTextByDefault
        {
            get => _wrapTextByDefault;
            set => RaisePropertyChanged(ref _wrapTextByDefault, value);
        }


        public bool CanCloseWindowsWithCtrlWAndShift
        {
            get => _canCloseWinWithCtrlWShift;
            set => RaisePropertyChanged(ref _canCloseWinWithCtrlWShift, value);
        }

        public bool CanReopenWindowWithCtrlShiftT
        {
            get => _canReOpenWinWithCtrlShiftT;
            set => RaisePropertyChanged(ref _canReOpenWinWithCtrlShiftT, value);
        }

        public bool CloseNotepadListByDefault
        {
            get => _closeNotepadListByDefault;
            set => RaisePropertyChanged(ref _closeNotepadListByDefault, value);
        }

        public bool UseNewDragDropSystem
        {
            get => _useNewDragDropSystem;
            set => RaisePropertyChanged(ref _useNewDragDropSystem, value);
        }

        public bool SaveOpenUnclosedFiles
        {
            get => _saveOpenUnclosedFiles;
            set => RaisePropertyChanged(ref _saveOpenUnclosedFiles, value);
        }

        public bool UseWordCounterByDefault
        {
            get => _useWordCounterByDefault;
            set => RaisePropertyChanged(ref _useWordCounterByDefault, value);
        }

        public bool CheckFileNamesForChangesInDocumentWatcher
        {
            get => _checkFileNamesForChanges;
            set => RaisePropertyChanged(ref _checkFileNamesForChanges, value);
        }

        public bool UnsetSetting2
        {
            get => _unsetSetting2;
            set => RaisePropertyChanged(ref _unsetSetting2, value);
        }

        public bool UnsetSetting3
        {
            get => _unsetSetting3;
            set => RaisePropertyChanged(ref _unsetSetting3, value);
        }

        public bool UnsetSetting4
        {
            get => _unsetSetting4;
            set => RaisePropertyChanged(ref _unsetSetting4, value);
        }

        public bool UnsetSetting5
        {
            get => _unsetSetting5;
            set => RaisePropertyChanged(ref _unsetSetting5, value);
        }

        public bool UnsetSetting6
        {
            get => _unsetSetting6;
            set => RaisePropertyChanged(ref _unsetSetting6, value);
        }

        public ICommand RefreshCommand { get; private set; }
        public ICommand SavePreferencesCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public Action CloseViewCallback { get; set; }

        public PreferencesViewModel()
        {
            RefreshCommand = new Command(LoadPreferences);
            SavePreferencesCommand = new Command(SaveAndClosePreferencesView);
            CancelCommand = new Command(Cancel);
        }

        public void LoadPreferences()
        {
            PreferencesG.LoadFromPropertiesFile();
            LoadPreferencesPropertiesIntoView();
        }

        public void LoadPreferencesPropertiesIntoView()
        {
            ScrollHorizontallyShiftMouseWheel = PreferencesG.SCROLL_HORIZONTAL_WITH_SHIFT_MOUSEWHEEL;
            ScrollHorizontallyCtrlArrowKeys = PreferencesG.SCROLL_HORIZONTAL_WITH_CTRL_ARROWKEYS;
            ScrollVerticallyCtrlArrowKeys = PreferencesG.SCROLL_VERTICAL_WITH_CTRL_ARROWKEYS;

            CutEntireLineCtrlX = PreferencesG.CAN_CUT_ENTIRE_LINE_CTRL_X;
            CopyEntireLineCtrlC = PreferencesG.CAN_COPY_ENTIRE_LINE_CTRL_C;
            SelectEntireLineCtrlShiftA = PreferencesG.CAN_SELECT_ENTIRE_LINE_CTRL_SHIFT_A;
            AddEntireLineCtrlEnter = PreferencesG.CAN_ADD_ENTIRE_LINES;

            ZoomEditorCtrlScrollwheel = PreferencesG.CAN_ZOOM_EDITOR_CTRL_MWHEEL;

            WrapTextByDefault = PreferencesG.WRAP_TEXT_BY_DEFAULT;

            CanCloseWindowsWithCtrlWAndShift = PreferencesG.CAN_CLOSE_WIN_WITH_CTRL_W;
            CanReopenWindowWithCtrlShiftT = PreferencesG.CAN_REOPEN_WIN_WITH_CTRL_SHIFT_T;

            CloseNotepadListByDefault = PreferencesG.CLOSE_NOTEPADLIST_BY_DEFAULT;

            UseNewDragDropSystem = PreferencesG.USE_NEW_DRAGDROP_SYSTEM;

            SaveOpenUnclosedFiles = PreferencesG.SAVE_OPEN_UNCLOSED_FILES;

            UseWordCounterByDefault = PreferencesG.USE_WORD_COUNTER_BY_DEFAULT;

            CheckFileNamesForChangesInDocumentWatcher = PreferencesG.CHECK_FILENAME_CHANGES_IN_DOCUMENT_WATCHER;
            UnsetSetting2 = PreferencesG.UNSET_SETTINGS_AAAAHLOL2;
            UnsetSetting3 = PreferencesG.UNSET_SETTINGS_AAAAHLOL3;
            UnsetSetting4 = PreferencesG.UNSET_SETTINGS_AAAAHLOL4;
            UnsetSetting5 = PreferencesG.UNSET_SETTINGS_AAAAHLOL5;
            UnsetSetting6 = PreferencesG.UNSET_SETTINGS_AAAAHLOL6;
        }

        public void SetPreferencesPropertiesFromView()
        {
            PreferencesG.SCROLL_HORIZONTAL_WITH_SHIFT_MOUSEWHEEL = ScrollHorizontallyShiftMouseWheel;
            PreferencesG.SCROLL_HORIZONTAL_WITH_CTRL_ARROWKEYS = ScrollHorizontallyCtrlArrowKeys;
            PreferencesG.SCROLL_VERTICAL_WITH_CTRL_ARROWKEYS = ScrollVerticallyCtrlArrowKeys;

            PreferencesG.CAN_CUT_ENTIRE_LINE_CTRL_X = CutEntireLineCtrlX;
            PreferencesG.CAN_COPY_ENTIRE_LINE_CTRL_C = CopyEntireLineCtrlC;
            PreferencesG.CAN_SELECT_ENTIRE_LINE_CTRL_SHIFT_A = SelectEntireLineCtrlShiftA;
            PreferencesG.CAN_ADD_ENTIRE_LINES = AddEntireLineCtrlEnter;

            PreferencesG.CAN_ZOOM_EDITOR_CTRL_MWHEEL = ZoomEditorCtrlScrollwheel;

            PreferencesG.WRAP_TEXT_BY_DEFAULT = WrapTextByDefault;

            PreferencesG.CAN_CLOSE_WIN_WITH_CTRL_W = CanCloseWindowsWithCtrlWAndShift;
            PreferencesG.CAN_REOPEN_WIN_WITH_CTRL_SHIFT_T = CanReopenWindowWithCtrlShiftT;

            PreferencesG.CLOSE_NOTEPADLIST_BY_DEFAULT = CloseNotepadListByDefault;

            PreferencesG.USE_NEW_DRAGDROP_SYSTEM = UseNewDragDropSystem;

            PreferencesG.SAVE_OPEN_UNCLOSED_FILES = SaveOpenUnclosedFiles;

            PreferencesG.USE_WORD_COUNTER_BY_DEFAULT = UseWordCounterByDefault;

            PreferencesG.CHECK_FILENAME_CHANGES_IN_DOCUMENT_WATCHER = CheckFileNamesForChangesInDocumentWatcher;
            PreferencesG.UNSET_SETTINGS_AAAAHLOL2 = UnsetSetting2;
            PreferencesG.UNSET_SETTINGS_AAAAHLOL3 = UnsetSetting3;
            PreferencesG.UNSET_SETTINGS_AAAAHLOL4 = UnsetSetting4;
            PreferencesG.UNSET_SETTINGS_AAAAHLOL5 = UnsetSetting5;
            PreferencesG.UNSET_SETTINGS_AAAAHLOL6 = UnsetSetting6;
        }

        public void SaveAndClosePreferencesView()
        {
            SetPreferencesPropertiesFromView();
            PreferencesG.SavePropertiesToFile();
            Information.Show("Properties Saved!", "Properties");
            ClosePreferencesWindow();
        }

        public void ResetPreferences()
        {
            LoadPreferences();
        }

        public void Cancel()
        {
            ResetPreferences();
            ClosePreferencesWindow();
        }

        public void ClosePreferencesWindow()
        {
            CloseViewCallback?.Invoke();
        }
    }
}
