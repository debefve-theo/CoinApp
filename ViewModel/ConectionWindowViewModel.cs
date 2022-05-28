// Copyright © 2022 - Theo Debefve

using System.Collections.ObjectModel;
using Model;
using Newtonsoft.Json;

namespace ViewModel
{
    public class ConectionWindowViewModel : ViewModelBase
    {
        public UserViewModel CurrentUser { get; set; }
        public ObservableCollection<UserViewModel> ItemsU { get; set; }

        public ConectionWindowViewModel()
        {
            // Verif exist fichier + creation ***
            if (!File.Exists("./DataUser.json"))
            {
                File.Create("./DataUser.json");
            }

            // Création de la liste
            this.ItemsU = new ObservableCollection<UserViewModel>();

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

            // Serialize
            //string jsonString = JsonSerializer.Serialize(ItemsU);

            // Deserialize
            /*List<User>? users = JsonSerializer.Deserialize<List<User>>(jsonString);
            if (users != null)
            {
                foreach (User u in users)
                {
                    ItemsU.Add(new UserViewModel(u));
                }
            }*/
        }
    }
}