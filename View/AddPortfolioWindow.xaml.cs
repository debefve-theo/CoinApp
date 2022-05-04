// Copyright © 2022 - Theo Debefve

using System.ComponentModel;
using System.Windows;

namespace View
{
    public partial class AddPortfolioWindow : Window
    {
        private bool CanClose { get; set; }
        public AddPortfolioWindow()
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
