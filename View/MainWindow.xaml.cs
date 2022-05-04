using System;
using System.Windows;
using System.Windows.Media.Imaging;
using ViewModel;
using System.ComponentModel;
using System.Windows.Controls;

namespace View
{
    public partial class MainWindow : Window
    {
        private bool CanClose { get; set; }

        public MainWindowViewModel ViewModel { get; set; }

        private readonly ConectionWindow _windowConection = new();
        private readonly SettingsWindow _windowSettings = new();
        private readonly AddTransactionWindow _windowAddT = new();

        private bool _reduce = true, _eye = true;

        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainWindowViewModel();

            this.DataContext = ViewModel;

            _windowAddT.AddTransactionCompleted += AddTransactionWindow_Completed;
        }

        private void AddTransactionWindow_Completed(object sender, TransactionEventArgs e)
        {
            if (sender is AddTransactionWindow)
            {
                ViewModel.ItemsT.Add(e.Transaction);
            }
        }
        
        private void Dispose()
        {
            _windowAddT.AddTransactionCompleted -= AddTransactionWindow_Completed;
        }

        protected override void OnClosed(EventArgs e)
        {
            _windowAddT.CloseWindow();
            _windowSettings.CloseWindow();
            _windowConection.CloseWindow();
            Dispose();
            _windowAddT.Close();
            _windowSettings.Close();
            _windowConection.Close();
            base.OnClosed(e);
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
            _windowSettings.ShowDialog();
            _windowSettings.Focus();
            _windowSettings.Activate();
        }

        private void BtnMenuDeconexion_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            _windowConection.Show();
            _windowConection.Focus();
            _windowConection.Activate();
        }
        #endregion

        #region BUTTON OTHER
        private void BtnAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            //TransactionViewModel t = _windowAddT.DataIci;
            //ViewModel.ItemsT.Add(t);

            _windowAddT.ShowDialog();
            _windowAddT.Focus();
            _windowAddT.Activate();
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

        private void DG1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            _windowAddT.ShowDialog();
            _windowAddT.Focus();
            _windowAddT.Activate();
        }
    }
}