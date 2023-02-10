﻿using MahApps.Metro.Controls;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnMessage_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("Example Message", "Your message here");
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
           var result = await this.ShowMyDialogAsync("My Dialog Test", "Messsage");
            lblUser.Content = result.Result; 

        }

     
    }
}
