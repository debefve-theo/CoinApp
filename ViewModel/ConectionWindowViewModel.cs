﻿// Copyright © 2022 - Theo Debefve

using System.Collections.ObjectModel;
using Model;

namespace ViewModel
{
    public class ConectionWindowViewModel : ViewModelBase
    {
        public UserViewModel CurrentUser { get; set; }
        public ObservableCollection<UserViewModel> ItemsU { get; set; }

        public ConectionWindowViewModel()
        {
            // Verif exist fichier + creation ***
            if (!File.Exists("./UserData.json"))
            {
                File.Create("./UserData.json");
            }

            // Serialize
            /*
            UserViewModel U1 = new UserViewModel(new User()
                {
                    Id = 1,
                    UserName = "Admin",
                    Password = "Password"
                }
            );

            string jsonString1 = JsonConvert.SerializeObject(U1);

            UserViewModel U2 = new UserViewModel(new User()
                {
                    Id = 2,
                    UserName = "Theo",
                    Password = "Ethereum"
                }
            );

            string jsonString2 = JsonConvert.SerializeObject(U2);

            ObservableCollection<UserViewModel> list = new ObservableCollection<UserViewModel>();

            list.Add(U1);
            list.Add(U2);

            String collectionResult = JsonConvert.SerializeObject(list);
            */

            // Deserialize
            /*
            ObservableCollection<UserViewModel> newList = JsonConvert.DeserializeObject<ObservableCollection<UserViewModel>>(collectionResult);
            */

            // Test Data
            UserViewModel U1 = new UserViewModel(new User()
            {
                Id = 1,
                UserName = "Admin",
                Password = "Password"
            }
            );

            UserViewModel U2 = new UserViewModel(new User()
            {
                Id = 2,
                UserName = "Theo",
                Password = "Ethereum"
            }
            );

            this.ItemsU = new ObservableCollection<UserViewModel>();

            this.ItemsU.Add(U1);
            this.ItemsU.Add(U2);

            // 

        }
    }
}