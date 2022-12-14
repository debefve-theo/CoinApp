// Copyright © 2022 - Theo Debefve
// Examen JUIN 2022

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
            ViewModel.ItemsTU.Add(CurrentTransaction);
            UpdateData();
            ViewModel.MainList();
            ViewModel.SaveFileU();
            ViewModel.SaveFileT();
            Close();
        }

        private void BtnAppliquer_Click(object sender, RoutedEventArgs e)
        {
            CurrentTransaction = GetData();
            ViewModel.ItemsT.Add(CurrentTransaction);
            ViewModel.ItemsTU.Add(CurrentTransaction);
            UpdateData();
            ViewModel.MainList();
            ViewModel.SaveFileU();
            ViewModel.SaveFileT();
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
                UserName = ViewModel.CurrentUser.UserName,
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
            if (((CryptoViewModel)FieldCrypto.SelectedItem).Model.Own.OwnB is false)
            {
                if (CurrentTransaction.Av is true) // Impossible de vendre
                {
                    MessageBox.Show("Vous ne possédez pas cette Crypto !");
                }
                else // Possible d'acheter
                {
                    CurrentTransaction.Cryptocurrency.Own.OwnB = true;
                    CurrentTransaction.Cryptocurrency.Own.Balance = CurrentTransaction.Quantity;
                    CurrentTransaction.Cryptocurrency.Own.BalanceE = CurrentTransaction.Quantity * CurrentTransaction.Cryptocurrency.Details.Price;
                    CurrentTransaction.Cryptocurrency.Own.TotalAchat = CurrentTransaction.Total;

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

            foreach (UserViewModel u in ViewModel.ItemsU)
            {
                if (u.UserName == ViewModel.CurrentUser.UserName)
                {
                    u.SoldeNow = ViewModel.CurrentUser.SoldeNow;
                    u.TotalAchat = ViewModel.CurrentUser.TotalAchat;
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

