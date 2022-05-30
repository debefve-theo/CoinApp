// Copyright © 2022 - Theo Debefve
// Examen JUIN 2022

using System.Collections.ObjectModel;
using Microsoft.Win32;
using Model;

namespace ViewModel
{
    public class ConectionWindowViewModel : ViewModelBase
    {
        #region VARIABLES
        public UserViewModel CurrentUser { get; set; }
        public string Path { get; set; }
        public ObservableCollection<UserViewModel> ItemsU { get; set; }
        #endregion

        #region MAIN
        public ConectionWindowViewModel()
        {
            // Registre
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software");
            RegistryKey PathKey = rk.CreateSubKey("CoinApp");

            RegistryKey pk = PathKey;

            if (pk.GetValue("Path") == null)
            {
                pk.SetValue("Path", "./");
                Path = pk.GetValue("Path").ToString();
            }
            else
            {
                Path = pk.GetValue("Path").ToString();
            }

            // Création de la liste
            this.ItemsU = new ObservableCollection<UserViewModel>();

            // Verif exist fichier + creation ***
            if (!File.Exists(Path + "\\data.json"))
            {
                File.Create(Path + "\\data.json");
            }
            else
            {
                OpenFileU();
            }
        }
        #endregion

        #region METHODS
        public void OpenFileU()
        {
            string jsonString = File.ReadAllText(Path + "\\data.json");

            if (jsonString != "")
            {
                List<User>? users = System.Text.Json.JsonSerializer.Deserialize<List<User>>(jsonString);
                if (users != null)
                {
                    foreach (User u in users)
                    {
                        ItemsU.Add(new UserViewModel(u));
                    }
                }
            }
        }

        public void SaveFileU()
        {
            foreach (UserViewModel u in ItemsU)
            {
                u.SoldeNow = 1;
            }

            string jsonString1 = System.Text.Json.JsonSerializer.Serialize(ItemsU);
            File.WriteAllText(Path + "\\data.json", jsonString1);
        }
        #endregion
    }
}