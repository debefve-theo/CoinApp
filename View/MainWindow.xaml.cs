// Copyright © 2022 - Theo Debefve

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using ViewModel;

namespace View
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }

        private bool _reduce = true, _eye = true;
        
        public MainWindow(UserViewModel user)
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel(user);
            this.DataContext = ViewModel;
        }

        protected override void OnClosed(EventArgs e)
        {
            ViewModel.SaveFileT();
            base.OnClosed(e);
        }

        #region BUTTON MENU
        private void BtnMenuHome_Click(object sender, RoutedEventArgs e)
        {
            ColHome.Width = new GridLength(1, GridUnitType.Star);
            ColTransaction.Width = new GridLength(0);
            ColWatchlist.Width = new GridLength(0);
        }

        private void BtnMenuTransaction_Click(object sender, RoutedEventArgs e)
        {
            ColHome.Width = new GridLength(0);
            ColTransaction.Width = new GridLength(1, GridUnitType.Star);
            ColWatchlist.Width = new GridLength(0);
        }

        private void BtnMenuWatchlist_Click(object sender, RoutedEventArgs e)
        {
            ColHome.Width = new GridLength(0);
            ColTransaction.Width = new GridLength(0);
            ColWatchlist.Width = new GridLength(1, GridUnitType.Star);
        }

        private void BtnMenuAPropos_Click(object sender, RoutedEventArgs e)
        {
            AProposWindow windowAPropos = new();
            windowAPropos.ShowDialog();
        }

        private void BtnMenuParametre_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow windowSettings = new(ViewModel);
            windowSettings.ShowDialog();
    }

        private void BtnMenuDeconexion_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.Save();
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
                BtnMenuWatchlistTxt.Text = null;
                BtnMenuAProposTxt.Text = null;
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
                BtnMenuWatchlistTxt.Text = "Watchlist";
                BtnMenuAProposTxt.Text = "A Propos";
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

                Binding myBinding1 = new Binding("SoldeNow");
                myBinding1.Source = ViewModel.CurrentUser;
                myBinding1.StringFormat = "{0:N2} €";
                BoxNow.SetBinding(TextBlock.TextProperty, myBinding1);

                /*Binding myBinding2 = new Binding("");
                myBinding2.Source = ViewModel.CurrentUser;
                myBinding2.StringFormat = "{0:N2} %";
                BoxNowPercent.SetBinding(TextBlock.TextProperty, myBinding2);*/
                BoxNowPercent.Text = "+ 0.00 %";

                Binding myBinding3 = new Binding("TotalAchat");
                myBinding3.Source = ViewModel.CurrentUser;
                myBinding3.StringFormat = "{0:N2} €";
                BoxTotal.SetBinding(TextBlock.TextProperty, myBinding3);

                Binding myBinding4 = new Binding("GainPerte");
                myBinding4.Source = ViewModel.CurrentUser;
                myBinding4.StringFormat = "{0:N2} €";
                BoxTotalLose.SetBinding(TextBlock.TextProperty, myBinding4);
            }
        }
    }
}