﻿using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MahAppsMetroCustomDialogExample
{
    public static class MyDialogExtensions
    {
        public static async Task<MyDialogResult> ShowMyDialogAsync(this MetroWindow window, string title, string message)
        {
            MyDialog dialog = new MyDialog()
            {
                DataContext = new MyDialogViewModel()
                {
                    Titel = title,
                    Message = message
                },
            };

            MyDialog.Close closingHandler = () => { window.HideMetroDialogAsync(dialog); };
            await window.ShowMetroDialogAsync(dialog);
            dialog.CloseDialog += closingHandler;
            await dialog.WaitUntilUnloadedAsync();
            dialog.CloseDialog -= closingHandler;
            return new MyDialogResult();
        }


    }
}
