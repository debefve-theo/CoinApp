using System.ComponentModel;
using System.Windows;

namespace View
{
    public partial class SettingsWindow : Window
    {
        private bool CanClose { get; set; }
        public SettingsWindow()
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
