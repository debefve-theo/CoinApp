// Copyright © 2022 - Theo Debefve

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
    public partial class MainWindow : Window
    {
        private readonly AddPortfolioWindow _windowAdd = new();
        private readonly ApplicationWindow _windowApplication = new();

        private bool CanClose { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            CanClose = false;
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

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            _windowAdd.Show();
            _windowAdd.Focus();
            _windowAdd.Activate();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonConection_Click(object sender, RoutedEventArgs e)
        {
            _windowApplication.Show();
            _windowApplication.Focus();
            _windowApplication.Activate();
            Hide();
        }
    }
}