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
            this.DataContext = ViewModel;
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
                Cryptocurrency = ((CryptoViewModel)FieldCrypto.SelectedItem).Model,
                Quantity = float.Parse(TextBoxQuantity.Text, CultureInfo.InvariantCulture.NumberFormat),
                PricePerToken = float.Parse(TextBoxPrice.Text, CultureInfo.InvariantCulture.NumberFormat),
                Fees = float.Parse(TextBoxFees.Text, CultureInfo.InvariantCulture.NumberFormat),
                Date = new DateTime(FieldDate.SelectedDate.Value.Year, FieldDate.SelectedDate.Value.Month, FieldDate.SelectedDate.Value.Day, int.Parse(FieldHour.Text), int.Parse(FieldMin.Text), 0),
                Exchange = TextBoxExchange.Text
            });

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

