// Copyright © 2022 - Theo Debefve
// Examen JUIN 2022

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

        private void ButtonConection_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CurrentUser = VerifyUser(FieldUsr.Text, FieldPswd.Password);

            if (ViewModel.CurrentUser is not null)
            {
                MainWindow windowMain = new(ViewModel.CurrentUser);
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

        private UserViewModel VerifyUser(string username, string password)
        {
            foreach (UserViewModel item in ViewModel.ItemsU)
            {
                if (item.UserName == username)
                {
                    if (item.Password == password)
                    {
                        return item;
                    }
                }
            }

            return null;
        }
    }
}