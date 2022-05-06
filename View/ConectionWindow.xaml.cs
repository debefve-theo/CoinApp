// Copyright © 2022 - Theo Debefve

using System.Windows;
using ViewModel;

namespace View
{
    public partial class ConectionWindow : Window
    {
        public ConectionWindowViewModel ViewModel { get; set; }
        public ConectionWindow()
        {
            InitializeComponent();

            ViewModel = new ConectionWindowViewModel();
        }

        private void Border_MousseDown(object sender, RoutedEventArgs e)
        {
            DragMove();
        }

        private bool VerifyUser(string username, string password)
        {
            foreach (UserViewModel item in ViewModel.ItemsU)
            {
                if (item.UserName == username)
                {
                    if (item.Password == password)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void ButtonConection_Click(object sender, RoutedEventArgs e)
        {
            if (VerifyUser(FieldUsr.Text, FieldPswd.Password))
            {
                FieldUsr.Text = "";
                FieldPswd.Password = "";

                MainWindow windowMain = new();
                windowMain.Show();
                Close();
            }
            else
            {
                MessageBox.Show("User or password incorect!");
            }
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            AddPortfolioWindow windowAdd = new(ViewModel);
            windowAdd.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}