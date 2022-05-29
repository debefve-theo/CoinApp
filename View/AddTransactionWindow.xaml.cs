// Copyright © 2022 - Theo Debefve

using System;
using System.Globalization;
using System.Windows;
using Model;
using ViewModel;

namespace View
{
    public partial class AddTransactionWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }
        public static TransactionViewModel? CurrentTransaction { get; set; }

        public AddTransactionWindow(MainWindowViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.DataContext = ViewModel;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            CurrentTransaction = GetData();
            ViewModel.ItemsT.Add(CurrentTransaction);
            UpdateData();
            ViewModel.MainList();
            Close();
        }

        private void BtnAppliquer_Click(object sender, RoutedEventArgs e)
        {
            CurrentTransaction = GetData();
            ViewModel.ItemsT.Add(CurrentTransaction);
            UpdateData();
            ViewModel.MainList();
            CleanField();
        }

        private void BtnAnuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private TransactionViewModel GetData()
        {
            TransactionViewModel currentTransaction = new TransactionViewModel(new Transaction()
            {
                Id = 1000,
                Av = (bool)RadioButtonV.IsChecked,
                Quantity = float.Parse(TextBoxQuantity.Text, CultureInfo.InvariantCulture.NumberFormat),
                PricePerToken = float.Parse(TextBoxPrice.Text, CultureInfo.InvariantCulture.NumberFormat),
                Fees = float.Parse(TextBoxFees.Text, CultureInfo.InvariantCulture.NumberFormat),
                Date = new DateTime(FieldDate.SelectedDate.Value.Year, FieldDate.SelectedDate.Value.Month, FieldDate.SelectedDate.Value.Day, int.Parse(FieldHour.Text), int.Parse(FieldMin.Text), 0),
                Exchange = TextBoxExchange.Text,
                Cryptocurrency = ((CryptoViewModel)FieldCrypto.SelectedItem).Model
            });

            return currentTransaction;
        }

        private void UpdateData()
        {
            if (((CryptoViewModel)FieldCrypto.SelectedItem).Model.Own is null)
            {
                if (CurrentTransaction.Av is true) // Impossible de vendre
                {
                    MessageBox.Show("Vous ne possédez pas cette Crypto !");
                }
                else // Possible d'acheter
                {
                    double i = CurrentTransaction.Quantity * CurrentTransaction.Cryptocurrency.Details.Price;
                    //CurrentTransaction.Cryptocurrency.Own = CryptoOwn(true, CurrentTransaction.Quantity, i, CurrentTransaction.Total, 0, 0);
                    CurrentTransaction.Cryptocurrency.Own.OwnB = true;
                    CurrentTransaction.Cryptocurrency.Own.Balance = CurrentTransaction.Quantity;
                    CurrentTransaction.Cryptocurrency.Own.BalanceE = i;
                    CurrentTransaction.Cryptocurrency.Own.TotalAchat = CurrentTransaction.Total;
                    // ********
                    ViewModel.CurrentUser.SoldeNow = ViewModel.CurrentUser.SoldeNow + (CurrentTransaction.Quantity * CurrentTransaction.Cryptocurrency.Details.Price);
                    ViewModel.CurrentUser.TotalAchat = ViewModel.CurrentUser.TotalAchat + CurrentTransaction.Total;
                }
            }
            else
            {
                if (CurrentTransaction.Av is true) // Possible de vendre
                {
                    CurrentTransaction.Cryptocurrency.Own.Balance = CurrentTransaction.Cryptocurrency.Own.Balance - CurrentTransaction.Quantity;
                    CurrentTransaction.Cryptocurrency.Own.BalanceE = CurrentTransaction.Cryptocurrency.Own.BalanceE - (CurrentTransaction.Quantity * CurrentTransaction.Cryptocurrency.Details.Price);
                    ViewModel.CurrentUser.SoldeNow = ViewModel.CurrentUser.SoldeNow - (CurrentTransaction.Quantity * CurrentTransaction.Cryptocurrency.Details.Price);
                    ViewModel.CurrentUser.TotalAchat = ViewModel.CurrentUser.TotalAchat - CurrentTransaction.Total;
                }
                else // Possible d'acheter
                {
                    CurrentTransaction.Cryptocurrency.Own.Balance = CurrentTransaction.Cryptocurrency.Own.Balance + CurrentTransaction.Quantity;
                    CurrentTransaction.Cryptocurrency.Own.BalanceE = CurrentTransaction.Cryptocurrency.Own.BalanceE + (CurrentTransaction.Quantity * CurrentTransaction.Cryptocurrency.Details.Price);
                    CurrentTransaction.Cryptocurrency.Own.TotalAchat = CurrentTransaction.Cryptocurrency.Own.TotalAchat + CurrentTransaction.Total;
                    ViewModel.CurrentUser.SoldeNow = ViewModel.CurrentUser.SoldeNow + (CurrentTransaction.Quantity * CurrentTransaction.Cryptocurrency.Details.Price);
                    ViewModel.CurrentUser.TotalAchat = ViewModel.CurrentUser.TotalAchat + CurrentTransaction.Total;
                }
            }
        }

        private void CleanField()
        {
            RadioButtonA.IsChecked = true;
            FieldCrypto.SelectedItem = null;
            FieldDate.SelectedDate = DateTime.Now;
            FieldHour.Text = "";
            FieldMin.Text = "";
            TextBoxQuantity.Text = "";
            TextBoxPrice.Text = "";
            TextBoxFees.Text = "";
            TextBoxExchange.Text = "";
        }
    }
}

