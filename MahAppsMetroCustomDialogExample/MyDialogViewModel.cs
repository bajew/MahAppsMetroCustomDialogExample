using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MahAppsMetroCustomDialogExample
{
    public class MyDialogViewModel
    {
        public MyDialogViewModel()
        {
            EscCommand = new RelayCommand(() => { CosingHandler?.Invoke(); });
        }
        public ICommand  EscCommand{ get; set; }
        public string Titel { get; set; }
        public string Message { get;  set; }
        public MyDialog.Close CosingHandler { get; internal set; }
    }
}
