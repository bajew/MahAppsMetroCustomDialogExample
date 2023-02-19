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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = new MainViewModel();

            DataContext = viewModel;
        }


        private async void btnMessage_Click(object sender, RoutedEventArgs e)
        {

            await this.ShowMessageAsync("Example Message", Lorem(1));
        }
        private async void btnMessage2_Click(object sender, RoutedEventArgs e)
        {
            var result = await this.ShowMessageAsync("Example Message", "Your message here", MessageDialogStyle.AffirmativeAndNegative);
            lblUser.Content = result;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var loginData = await this.ShowLoginAsync("Login", "Mit MA-Kennung anmelden");
            lblUser.Content = loginData.Username;
        }

        private async void btnProgress_Click(object sender, RoutedEventArgs e)
        {
            int delay = 1000;
            var progController = await this.ShowProgressAsync("Progress", "Lade daten...");
            progController.SetIndeterminate();

            await Task.Delay(delay);
            progController.SetMessage("Lade konfig...");

            await Task.Delay(delay);
            progController.SetMessage("Überprüfe daten...");

            await Task.Delay(delay);
            await progController.CloseAsync();
        }
        private async void btnProgress2_Click(object sender, RoutedEventArgs e)
        {
            int delay = 1000;
            var progController = await this.ShowProgressAsync("Progress", "Lade daten...");
            progController.Maximum = 0;
            progController.Maximum = 3;

            await Task.Delay(delay);
            progController.SetProgress(1);

            progController.SetMessage("Lade konfig...");
            await Task.Delay(delay);
            progController.SetProgress(2);

            progController.SetMessage("Überprüfe daten...");
            await Task.Delay(delay);
            progController.SetProgress(3);


            await progController.CloseAsync();
        }

        private async void btnCustom_Click(object sender, RoutedEventArgs e)
        {

            var result = await this.ShowMyDialogAsync("My Dialog Test", 
                                                        "Choose an Optiom",
                                                        new List<string>() { "Custom Message1", "Custom Message2", "Custom Message3", "Custom Message4" },
                                                        IconType.None);
            lblUser.Content = result.Result + result.SelectedMessage;

        }
        private async void btnCustomQuestion_Click(object sender, RoutedEventArgs e)
        {
            var result = await this.ShowMyDialogAsync("My Dialog Test",
                                                    "Choose an Optiom",
                                                    new List<string>() { "Custom Message1", "Custom Message2", "Custom Message3", "Custom Message4" },
                                                    IconType.Question);
            lblUser.Content = result.Result + result.SelectedMessage;
        }

        private async void btnCustomError_Click(object sender, RoutedEventArgs e)
        {
            var result = await this.ShowMyDialogAsync("My Dialog Test",
                                                    "Choose an Optiom",
                                                    new List<string>() { "Custom Message1", "Custom Message2", "Custom Message3", "Custom Message4" },
                                                    IconType.Error);
            lblUser.Content = result.Result + result.SelectedMessage;
        }

        private async void btnCustomWarning_Click(object sender, RoutedEventArgs e)
        {
            var result = await this.ShowMyDialogAsync("My Dialog Test",
                                                    "Choose an Optiom",
                                                    new List<string>() { "Custom Message1", "Custom Message2", "Custom Message3", "Custom Message4" },
                                                    IconType.Warning);
            lblUser.Content = result.Result + result.SelectedMessage;
        }

        private async void btnCustomInfo_Click(object sender, RoutedEventArgs e)
        {
            var result = await this.ShowMyDialogAsync("My Dialog Test",
                                                                "Choose an Optiom",
                                                                new List<string>() { "Custom Message1", "Custom Message2", "Custom Message3", "Custom Message4" },
                                                                IconType.Info);
            lblUser.Content = result.Result + result.SelectedMessage;
        }



        private string Lorem(int amountOfLines)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < amountOfLines; i++)
                sb.AppendLine("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata ");

            return sb.ToString();

        }

      
    }
}
