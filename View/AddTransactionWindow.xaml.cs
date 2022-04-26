// Copyright © 2022 - Theo Debefve

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
using System.Windows.Shapes;

namespace View
{
    public partial class AddTransactionWindow : Window
    {
        private bool CanClose { get; set; }
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

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void ButtonAppliquer_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void ButtonAnuler_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}

