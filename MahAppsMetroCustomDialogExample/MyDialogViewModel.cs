using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MahAppsMetroCustomDialogExample
{
    public enum IconType
    {
        None, 
        Info, 
        Warning, 
        Error, 
        Question
    }

    public class MyDialogViewModel
    {
        public MyDialogViewModel()
        {
            EscCommand = new RelayCommand(() =>
            {
                CosingHandler?.Invoke(); 
            });

            AffirmativeCommand = new RelayCommand(() => 
            {
                Result.Result = "Affirmative"; 
                CosingHandler?.Invoke(); 
            });

            NegativeCommand = new RelayCommand(() =>
            { 
                Result.Result = "Negative";
                CosingHandler?.Invoke(); 
            });

            ChooseCommand = new RelayCommand((o) => 
            { 
                Result.Result = "Affirmative"; 
                Result.SelectedMessage = o?.ToString() ?? string.Empty;
                CosingHandler?.Invoke(); 
            });

        }
        public ICommand AffirmativeCommand { get; set; }
        public ICommand NegativeCommand { get; set; }
        public ICommand ChooseCommand { get; set; }
        public ICommand EscCommand { get; set; }
        public string Titel { get; set; }
        public string Message { get; set; }

        public IconType IconType { get; set; }
        public List<string> MessageList { get; set; }
        public string SelectedMessage { get; set; }
        public MyDialog.Close CosingHandler { get; internal set; }

        public MyDialogResult Result { get; set; } = new MyDialogResult();
    }
}
