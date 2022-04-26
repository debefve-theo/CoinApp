// Copyright © 2022 - Theo Debefve

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
using System.IO;

namespace View
{
    public partial class MainWindow : Window
    {
        #region WINDOW
        private readonly SettingsWindow _windowSettings = new();
        private readonly AddTransactionWindow _windowMain = new();

        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region BUTTON MENU
        private void BtnMenuHome_Click(object sender, RoutedEventArgs e)
        {
            ColHome.Width = new GridLength(1, GridUnitType.Star);
            ColTransaction.Width = new GridLength(0);
            ColRepartition.Width = new GridLength(0);
            ColWatchlist.Width = new GridLength(0);
        }

        private void BtnMenuTransaction_Click(object sender, RoutedEventArgs e)
        {
            ColHome.Width = new GridLength(0);
            ColTransaction.Width = new GridLength(1, GridUnitType.Star);
            ColRepartition.Width = new GridLength(0);
            ColWatchlist.Width = new GridLength(0);
        }

        private void BtnMenuRepartition_Click(object sender, RoutedEventArgs e)
        {
            ColHome.Width = new GridLength(0);
            ColTransaction.Width = new GridLength(0);
            ColRepartition.Width = new GridLength(1, GridUnitType.Star);
            ColWatchlist.Width = new GridLength(0);
        }

        private void BtnMenuWatchlist_Click(object sender, RoutedEventArgs e)
        {
            ColHome.Width = new GridLength(0);
            ColTransaction.Width = new GridLength(0);
            ColRepartition.Width = new GridLength(0);
            ColWatchlist.Width = new GridLength(1, GridUnitType.Star);
        }

        private void BtnMenuParametre_Click(object sender, RoutedEventArgs e)
        {
            _windowSettings.Show();
            _windowSettings.Focus();
            _windowSettings.Activate();
        }

        private void BtnMenuDeconexion_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region
        private void BtnAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            _windowMain.Show();
            _windowMain.Focus();
            _windowMain.Activate();
        }
        #endregion
    }
}
