// Copyright © 2022 - Theo Debefve

using System.Collections.ObjectModel;
using Microsoft.Win32;
using Model;
using Newtonsoft.Json;
using System.Text.Json;

namespace ViewModel
{
    public class ConectionWindowViewModel : ViewModelBase
    {
        public UserViewModel CurrentUser { get; set; }
        public string Path { get; set; }
        public ObservableCollection<UserViewModel> ItemsU { get; set; }

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

            // Verif exist fichier + creation ***
            if (!File.Exists(Path + "\\data.json"))
            {
                File.Create(Path + "\\data.json");
            }

            // Création de la liste
            this.ItemsU = new ObservableCollection<UserViewModel>();

            OpenFileU();

            int i = 1 + 1;
        }

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
            string jsonString1 = System.Text.Json.JsonSerializer.Serialize(ItemsU);
            File.WriteAllText(Path + "\\data.json", jsonString1);
        }
    }
}