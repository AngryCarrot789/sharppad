﻿using SharpPad.CClipboard;
using SharpPad.FileChangeWatcher;
using SharpPad.InformationStuff;
using SharpPad.Notepad;
using SharpPad.Notepad.DragDropping;
using SharpPad.Utilities;
using SharpPad.ViewModels;
using SharpPad.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace SharpPad.Applications
{
    public static class ThisApplication
    {
        public static ApplicationViewModel App { get; private set; }

        public static string UnclosedFilesStorageLocation { get; }

        public static string SharpPadFolderLocation { get; }

        static ThisApplication()
        {
            SharpPadFolderLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SharpPadFiles");
            UnclosedFilesStorageLocation = Path.Combine(SharpPadFolderLocation, "UnclosedFiles");

            if (!Directory.Exists(UnclosedFilesStorageLocation))
                CreateUnclosedFilesStorageDirectory();
        }

        public static void Startup(string[] args)
        {
            App = new ApplicationViewModel(args);
            WindowManager.WindowPreviews.ThisApp = App;

            ClipboardNotification.StartListener();
            DragDropFileWatchers.Initialise();
            ApplicationFileWatcher.StartDocumentWatcher();
            //TheRInstance.StartWatcher();
        }

        public static void ShutdownApplication()
        {
            Information.Show("Shutting down application", "App");

            ClipboardNotification.ShutdownListener();
            DragDropFileWatchers.Shutdown();
            ApplicationFileWatcher.StopDocumentWatcher();
            //TheRInstance.StopWatcher();

            Application.Current?.Shutdown();
        }

        public static void CreateUnclosedFilesStorageDirectory()
        {
            try
            {
                if (!Directory.Exists(UnclosedFilesStorageLocation))
                    Directory.CreateDirectory(UnclosedFilesStorageLocation);
            }
            catch { }
        }

        public static void CloseWindowFromDataContext(NotepadViewModel notepad)
        {
            Information.Show("Closing a window", "Windows");
            App.FullyCloseWindowFromDataContext(notepad);
        }

        public static void ShowWindowManager()
        {
            WindowManager.WindowPreviews.Show();
        }

        public static void OpenFileInNewWindow(string path, bool clearPath = false, bool useStartupDelay = false)
        {
            Information.Show("Opening file in new window", "NewWindow");
            App.OpenFileInNewWindow(path, clearPath, useStartupDelay);
        }

        public static void OpenNewWindow()
        {
            App.CreateAndShowNotepadWindowAndPreviewWithDefaultItem();
        }

        public static void ReopenLastWindow()
        {
            Information.Show("Opening last window...", "Window");
            App.ReopenLastWindow();
        }

        public static void ShowClipboard()
        {
            WindowManager.ClipboardWin.ShowWindow();
        }

        public static void SetClipboardContext(ClipboardViewModel model)
        {
            WindowManager.ClipboardWin.Clipboard = model;
        }

        public static void ShowPreferencesWindow()
        {
            WindowManager.Preferences.Show();
        }

        public static void ShowHelp()
        {
            WindowManager.Help.Show();
        }

        public static void WriteFileToUnclosedStorageLocation(string fileName, string contents)
        {
            try
            {
                string newFilePath = Path.Combine(UnclosedFilesStorageLocation, "tmp_" + fileName);

                if (File.Exists(newFilePath))
                {
                    // attempt 2
                    newFilePath = Path.Combine(UnclosedFilesStorageLocation, "atmpt2_tmp_" + fileName);
                }

                File.WriteAllText(newFilePath, contents);
            }
            catch { }
        }

        // bad name i know lol
        public static bool CheckUnclosedStorageDirectoryExistsElseCreateIt()
        {
            if (!Directory.Exists(UnclosedFilesStorageLocation))
            {
                CreateUnclosedFilesStorageDirectory();
            }

            return Directory.Exists(UnclosedFilesStorageLocation);
        }

        public static void SaveAllUnclosedFilesToStorageLocation(NotepadWindow window)
        {
            NotepadViewModel model = window.Notepad;
            foreach (NotepadItemViewModel item in model.NotepadItems)
            {
                TextDocumentViewModel doc = item.Notepad;

                if (!doc.Document.Text.IsEmpty() && doc.HasMadeChanges)
                {
                    if (CheckUnclosedStorageDirectoryExistsElseCreateIt())
                    {
                        WriteFileToUnclosedStorageLocation(doc.Document.FileName, doc.Document.Text);
                    }
                }
            }
        }

        public static List<string> GetPreviouslyUnclosedFiles()
        {
            List<string> paths = new List<string>();

            if (Directory.Exists(UnclosedFilesStorageLocation))
            {
                foreach (string file in Directory.GetFiles(UnclosedFilesStorageLocation))
                {
                    paths.Add(file);
                }
            }

            return paths;
        }

        public static void DeletePreviouslyUnclosedFiles()
        {
            try
            {
                if (Directory.Exists(UnclosedFilesStorageLocation))
                {
                    foreach (string file in Directory.GetFiles(UnclosedFilesStorageLocation))
                    {
                        try { File.Delete(file); }
                        catch { }
                    }
                }
            }
            catch { }
        }
    }
}
