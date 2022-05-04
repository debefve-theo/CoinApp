// Copyright © 2022 - Theo Debefve

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Model;
using ViewModel;

namespace View
{
    public partial class AddTransactionWindow : Window
    {
        private bool CanClose { get; set; }

        public MainWindowViewModel ViewModel { get; set; }

        public delegate void Notify(object sender, TransactionEventArgs e);
        public event Notify AddTransactionCompleted;

        public AddTransactionWindow()
        {
            InitializeComponent();

            CanClose = true;
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

        private void OnAddTransactionChange(object sender, TransactionEventArgs e)
        {
            AddTransactionCompleted(this, e);
        }

        private void BtnAppliquer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AddTransactionCompleted != null)
                {
                    OnAddTransactionChange(this, new TransactionEventArgs(GetData()));
                }

                Hide();
            }
            catch
            {
                System.Windows.MessageBox.Show("Erreur");
            }
        }

        private void BtnAnuler_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private TransactionViewModel GetData()
        {
            TransactionViewModel CurrentTransaction;

            CurrentTransaction = new TransactionViewModel(new Transaction()
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

            return CurrentTransaction;
        }

    }
}

