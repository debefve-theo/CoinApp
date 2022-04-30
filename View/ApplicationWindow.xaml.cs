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
using Model;
using ViewModel;
using System.ComponentModel;

namespace View
{
    public partial class ApplicationWindow : Window
    {
        private bool CanClose { get; set; }

        public MainWindowViewModel ViewModel { get; set; }

        /*private readonly SettingsWindow _windowSettings = new();
        private readonly AddTransactionWindow _windowAddT = new();
        private readonly MainWindow _windowMain = new();*/

        private bool _reduce = true, _eye = true;

        public ApplicationWindow()
        {
            InitializeComponent();

            CanClose = true;

            ViewModel = new MainWindowViewModel();

            this.DataContext = ViewModel;
        }
        public void CloseWindow()
        {
            CanClose = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = CanClose;
            base.OnClosing(e);
            Hide();
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
            /*_windowSettings.ShowDialog();
            _windowSettings.Focus();
            _windowSettings.Activate();*/
        }

        private void BtnMenuDeconexion_Click(object sender, RoutedEventArgs e)
        {
            /*_windowMain.Show();
            _windowMain.Focus();
            _windowMain.Activate();*/
        }
        #endregion

        #region BUTTON OTHER
        private void BtnAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            /*_windowAddT.ShowDialog();
            _windowAddT.Focus();
            _windowAddT.Activate();*/
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
            }
            else
            {
                BitmapImage myImage = new BitmapImage(new Uri(@"Img/IconView.png", UriKind.Relative));
                EyeImg.Source = myImage;
                _eye = true;
            }
        }
    }
}