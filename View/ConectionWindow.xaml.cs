// Copyright © 2022 - Theo Debefve

using System.Windows;
using System.ComponentModel;

namespace View
{
    public partial class ConectionWindow : Window
    {
        private readonly AddPortfolioWindow _windowAdd = new();

        private bool CanClose { get; set; }
        public ConectionWindow()
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

        private void Border_MousseDown(object sender, RoutedEventArgs e)
        {
            DragMove();
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
            
        }
    }
}