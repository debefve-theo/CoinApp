// Copyright © 2022 - Theo Debefve
// Examen JUIN 2022

using System.Windows;
using Model;
using ViewModel;

namespace View
{
    public partial class AddPortfolioWindow : Window
    {
        public ConectionWindowViewModel ViewModel { get; set; }

        public AddPortfolioWindow(ConectionWindowViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
        }

        private bool VerifyNewUser(string username, string password)
        {
            foreach (UserViewModel item in ViewModel.ItemsU)
            {
                if (item.UserName == username)
                {
                    return false;
                }

                if (username == null || password == null)
                {
                    return false;
                }
            }

            return true;
        }

        private void BtnAppliquer_Click(object sender, RoutedEventArgs e)
        {
            string usr = FieldUsr.Text;
            string pswd = FieldPswd.Password;

            if (VerifyNewUser(usr, pswd))
            {
                UserViewModel U = new UserViewModel(new User()
                {
                    Id = 999,
                    UserName = usr,
                    Password = pswd,
                    TotalAchat = 0,
                    SoldeNow = 1,
                    Solde24 = 0,
                });

                ViewModel.ItemsU.Add(U);

                ViewModel.SaveFileU();

                Close();
            }
            else
            {
                MessageBox.Show("User or password incorect!");
            }
        }

        private void BtnAnuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
