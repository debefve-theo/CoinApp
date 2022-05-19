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
            ViewModel.UpdateMainList(CurrentTransaction.Cryptocurrency.Id);
            Close();
        }

        private void BtnAppliquer_Click(object sender, RoutedEventArgs e)
        {
            CurrentTransaction = GetData();
            ViewModel.ItemsT.Add(CurrentTransaction);
            ViewModel.UpdateMainList(CurrentTransaction.Cryptocurrency.Id);
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

            double i = currentTransaction.Quantity * ((CryptoViewModel)FieldCrypto.SelectedItem).Model.Details.Price;

            if (((CryptoViewModel)FieldCrypto.SelectedItem).Model.Own is null)
            {
                if ((bool)RadioButtonV.IsChecked)
                {
                    // impossible possède pas cette crypto
                }
                else
                {
                    ((CryptoViewModel)FieldCrypto.SelectedItem).Model.Own = new CryptoOwn(true, currentTransaction.Quantity, i, currentTransaction.Total, 0, 0);
                }
            }
            else
            {
                if ((bool)RadioButtonV.IsChecked)
                {
                    ((CryptoViewModel)FieldCrypto.SelectedItem).Model.Own.Balance = ((CryptoViewModel)FieldCrypto.SelectedItem).Model.Own.Balance - currentTransaction.Quantity;
                    ((CryptoViewModel)FieldCrypto.SelectedItem).Model.Own.BalanceE = ((CryptoViewModel)FieldCrypto.SelectedItem).Model.Own.BalanceE - (currentTransaction.Quantity * ((CryptoViewModel)FieldCrypto.SelectedItem).Model.Details.Price);
                    ((CryptoViewModel)FieldCrypto.SelectedItem).Model.Own.TotalAchat = ((CryptoViewModel)FieldCrypto.SelectedItem).Model.Own.TotalAchat - currentTransaction.Total;
                }
                else
                {
                    ((CryptoViewModel)FieldCrypto.SelectedItem).Model.Own.Balance = ((CryptoViewModel)FieldCrypto.SelectedItem).Model.Own.Balance + currentTransaction.Quantity;
                    ((CryptoViewModel)FieldCrypto.SelectedItem).Model.Own.BalanceE = ((CryptoViewModel)FieldCrypto.SelectedItem).Model.Own.BalanceE + (currentTransaction.Quantity * ((CryptoViewModel)FieldCrypto.SelectedItem).Model.Details.Price);
                    ((CryptoViewModel)FieldCrypto.SelectedItem).Model.Own.TotalAchat = ((CryptoViewModel)FieldCrypto.SelectedItem).Model.Own.TotalAchat + currentTransaction.Total;
                }
            }

            return currentTransaction;
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

