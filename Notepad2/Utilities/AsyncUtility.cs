﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notepad2.Utilities
{
    public static class AsyncUtility
    {
        /// <summary>
        /// A helper for running asynchronous 
        /// code in the main thread
        /// </summary>
        public static void RunSync(Action method)
        {
            Application.Current?.Dispatcher?.Invoke(method);
        }

        /// <summary>
        /// A helper for running code
        /// in another thread
        /// </summary>
        public static void RunAsync(Action method)
        {
            Task.Run(method);
        }
    }
}