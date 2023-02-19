using ControlzEx;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MahAppsMetroCustomDialogExample
{
    /// <summary>
    /// Interaktionslogik für MyDialog.xaml
    /// </summary>
    public partial class MyDialog : CustomDialog
    {
        public delegate void Close();
        public event Close CloseDialog;
        public MyDialog()
        {
            InitializeComponent();
           

        }

        public MyDialog(MetroWindow parentWindow) : base(parentWindow)
        {
        }

        public MyDialog(MetroDialogSettings settings) : base(settings)
        {
        }

        public MyDialog(MetroWindow parentWindow, MetroDialogSettings settings) : base(parentWindow, settings)
        {
        }

        private void CustomDialog_Loaded(object sender, RoutedEventArgs e)
        {
            KeyboardNavigationEx.Focus(AffirmativeButton);
        }
    }
}
