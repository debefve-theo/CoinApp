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

namespace View
{
    public partial class ConectionWindow : Window
    {
        private readonly ConectionWindow _windowConection = new();
        public ConectionWindow()
        {
            InitializeComponent();
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            _windowConection.Show();
            _windowConection.Focus();
            _windowConection.Activate();
        }
    }
}

