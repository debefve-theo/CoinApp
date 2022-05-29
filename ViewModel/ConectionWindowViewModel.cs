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
            if (!File.Exists(Path + "\\dataU.json"))
            {
                File.Create(Path + "\\dataU.json");
            }

            // Création de la liste
            this.ItemsU = new ObservableCollection<UserViewModel>();

            OpenFileU();

            /*
            UserViewModel U1 = new UserViewModel(new User()
                {
                    Id = 1,
                    UserName = "Admin",
                    Password = "Password",
                    SoldeNow = 0,
                    TotalAchat = 0
                }
            );

            this.ItemsU.Add(U1);

            UserViewModel U2 = new UserViewModel(new User()
            {
                Id = 2,
                UserName = "Theo",
                Password = "Ethereum",
                TotalAchat = 0,
                SoldeNow = 0
            });

            this.ItemsU.Add(U2);
            */
        }

        public void OpenFileU()
        {
            string jsonString1 = File.ReadAllText(Path + "\\dataU.json");

            if (jsonString1 != "")
            {
                List<User>? users = System.Text.Json.JsonSerializer.Deserialize<List<User>>(jsonString1);
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
            string jsonString2 = System.Text.Json.JsonSerializer.Serialize(ItemsU);
            File.WriteAllText(Path + "\\dataU.json", jsonString2);
        }
    }
}