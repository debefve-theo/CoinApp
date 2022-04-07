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
using System.ComponentModel;

namespace WindowSettings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool CanClose { get; set; }
        public MainWindow()
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
    }
}
