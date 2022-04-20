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
using WindowSettings;
using WindowAddTransaction;

namespace WindowMain
{
    public partial class MainWindow : Window
    {
        #region WINDOW
        private readonly WindowSettings.MainWindow WindowSettings = new();
        private readonly WindowMain.AddTransactionWindow WindowMain = new();
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
            WindowSettings.Show();
            WindowSettings.Focus();
            WindowSettings.Activate();
        }

        private void BtnMenuDeconexion_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region
        private void BtnAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            WindowMain.Show();
            WindowMain.Focus();
            WindowMain.Activate();
        }
        #endregion
    }
}
