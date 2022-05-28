// Copyright © 2022 - Theo Debefve

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using Microsoft.Win32;
using ViewModel;
using MessageBox = System.Windows.MessageBox;

namespace View
{
    public partial class SettingsWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }

        public SettingsWindow(MainWindowViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.DataContext = ViewModel;

            TextBlockFile.Text = ViewModel.FolderPath;
        }

        private void BtnAppliquer_Click(object sender, RoutedEventArgs e)
        {

            bool cp = ChangePassword();

            if (cp)
            {
                // réécrire dans le fichier
                int i = 0;
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {

            bool cp = ChangePassword();

            if (cp)
            {
                // réécrire dans le fichier
                int i = 0;
            }

            Close();
        }

        private void BtnAnuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool ChangePassword()
        {
            if (OldPassField.Password != "" && NewPassField.Password != "" && NewPassConfField.Password != "")
            {
                if (Equals(OldPassField.Password, ViewModel.CurrentUser.Password))
                {
                    if (Equals(NewPassField.Password, NewPassConfField.Password))
                    {
                        ViewModel.CurrentUser.Password = NewPassField.Password;
                        MessageBox.Show("Ok !" + "--" + ViewModel.CurrentUser.Password + "--");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Le nouveau mot de passe et la confirmation du mot de passe ne sont pas les mêmes !");
                    }
                }
                else
                {
                    MessageBox.Show("Ancien mot de passe incorecte !");
                }
            }
            else
            {
                MessageBox.Show("Vide !");
            }

            return false;
        }

        private void FileButton_Click(object sender, RoutedEventArgs e)
        {
            /*OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Nullable<bool> result = openFileDialog.ShowDialog();*/

            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
            DialogResult result = openFolderDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string directoryName = openFolderDialog.SelectedPath;
                ViewModel.FolderPath = directoryName;

                if (directoryName.Length >= 33)
                {
                    directoryName = directoryName.Substring(directoryName.Length - 30, 30);
                    directoryName = "... " + directoryName;
                }

                TextBlockFile.Text = directoryName;
            }
            else
            {

            }
        }
    }
}
