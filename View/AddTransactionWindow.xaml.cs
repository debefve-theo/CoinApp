// Copyright © 2022 - Theo Debefve

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using Model;
using ViewModel;

namespace View
{
    public partial class AddTransactionWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }

        public AddTransactionWindow(MainWindowViewModel vm)
        {
            InitializeComponent();

            ViewModel = vm;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ItemsT.Add(GetData());
            Close();
        }

        private void BtnAppliquer_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ItemsT.Add(GetData());
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
                Cryptocurrency = new Crypto()
                {
                    Id = 2000,
                    Name = "Bitcoin",
                    Symbol = "BTC",
                    Price = 45300,
                    Volume24H = 32187076510,
                    Change1H = -5.15,
                    Change1D = -7.02,
                    Change1W = -8.29,
                    Marketcap = 726792252422
                },
                Quantity = float.Parse(TextBoxQuantity.Text, CultureInfo.InvariantCulture.NumberFormat),
                PricePerToken = float.Parse(TextBoxPrice.Text, CultureInfo.InvariantCulture.NumberFormat),
                Fees = float.Parse(TextBoxFees.Text, CultureInfo.InvariantCulture.NumberFormat),
                Date = new DateTime(2022, 04, 26, 22, 17, 48),
                Exchange = TextBoxExchange.Text
            });

            return currentTransaction;
        }

        private void CleanField()
        {
            RadioButtonV.IsChecked = true;
            // Crypto
            DatePicker.DisplayDate = DateTime.Now;
            TextBoxQuantity.Text = "";
            TextBoxPrice.Text = "";
            TextBoxFees.Text = "";
            TextBoxExchange.Text = "";
        }
    }
}

