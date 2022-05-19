// Copyright © 2022 - Theo Debefve

using System;
using System.Windows;
using System.Windows.Media.Imaging;
using ViewModel;

namespace View
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }

        private bool _reduce = true, _eye = true;

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();
            this.DataContext = ViewModel;
        }

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
            SettingsWindow windowSettings = new();
            windowSettings.ShowDialog();
    }

        private void BtnMenuDeconexion_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Save();
            ConectionWindow windowConection = new();
            windowConection.Show();
            Close();
        }
        #endregion

        #region BUTTON OTHER
        private void BtnAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            AddTransactionWindow windowAddT = new(ViewModel);
            windowAddT.ShowDialog();
        }

        #endregion

        private void BtnBarre_Click(object sender, RoutedEventArgs e)
        {
            if (_reduce == true)
            {
                ColMenu.Width = new GridLength(7, GridUnitType.Star);
                ColContent.Width = new GridLength(93, GridUnitType.Star);
                BtnMenuHomeTxt.Text = null;
                BtnMenuTransactionTxt.Text = null;
                BtnMenuRepartitionTxt.Text = null;
                BtnMenuWatchlistTxt.Text = null;
                BtnMenuParametreTxt.Text = null;
                BtnMenuDeconexionTxt.Text = null;
                _reduce = false;
            }
            else
            {
                ColMenu.Width = new GridLength(20, GridUnitType.Star);
                ColContent.Width = new GridLength(80, GridUnitType.Star);
                BtnMenuHomeTxt.Text = "Home";
                BtnMenuTransactionTxt.Text = "Transaction";
                BtnMenuRepartitionTxt.Text = "Répartition";
                BtnMenuWatchlistTxt.Text = "Watchlist";
                BtnMenuParametreTxt.Text = "Paramètres";
                BtnMenuDeconexionTxt.Text = "Déconexion";
                _reduce = true;
            }
        }

        private void BtnEye_Click(object sender, RoutedEventArgs e)
        {
            if (_eye == true)
            {
                BitmapImage myImage = new BitmapImage(new Uri(@"Img/IconHiden.png", UriKind.Relative));
                EyeImg.Source = myImage;
                _eye = false;

                BoxNow.Text = "***,** €";
                BoxNowPercent.Text = "**,**%";
                BoxTotal.Text = "***,**€";
                BoxTotalLose.Text = "***,**€";
            }
            else
            {
                BitmapImage myImage = new BitmapImage(new Uri(@"Img/IconView.png", UriKind.Relative));
                EyeImg.Source = myImage;
                _eye = true;

                BoxNow.Text = "752,15 €";
                BoxNowPercent.Text = "+ 2,31%";
                BoxTotal.Text = "895,05€";
                BoxTotalLose.Text = "- 150,02€";
            }
        }
    }
}