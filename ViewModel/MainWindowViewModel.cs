// Copyright © 2022 - Theo Debefve
// Examen JUIN 2022

using Model;
using System.Collections.ObjectModel;
using ClassLibrary;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region VARIABLES
        public TransactionViewModel CurrentTransaction { get; set; }
        public static CryptoViewModel? CurrentCrypto { get; set; }
        public UserViewModel? CurrentUser { get; set; }

        public ObservableCollection<CryptoViewModel> ItemsC { get; set; }
        public ObservableCollection<TransactionViewModel> ItemsT { get; set; }
        public ObservableCollection<TransactionViewModel> ItemsTU { get; set; }
        public ObservableCollection<UserViewModel> ItemsU { get; set; }
        public ObservableCollection<CryptoViewModel> ItemsM { get; set; }

        public string Path { get; set; }
        #endregion

        #region MAIN
        public MainWindowViewModel(UserViewModel user)
        {
            // User
            CurrentUser = user;
            this.ItemsU = new ObservableCollection<UserViewModel>();

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
            this.ItemsT = new ObservableCollection<TransactionViewModel>();
            this.ItemsTU = new ObservableCollection<TransactionViewModel>();

            if (!File.Exists(Path + "\\dataT.json"))
            {
                File.Create(Path + "\\dataT.json");
            }
            else
            {
                OpenFileT();
            }

            // Crypto
            ItemsC = GetCryptoList();

            CurrentUser.SoldeNow = 0;
            CurrentUser.TotalAchat = 0;

            foreach (TransactionViewModel t in ItemsT)
            {
                if (t.UserName == CurrentUser.UserName)
                {
                    foreach (CryptoViewModel c in ItemsC)
                    {
                        if (t.Cryptocurrency.Id == c.Id)
                        {
                            if (t.Av == false)
                            {
                                c.Own.OwnB = true;
                                c.Own.Balance = c.Own.Balance + t.Quantity;
                                c.Own.BalanceE = c.Own.BalanceE + (t.Quantity * c.Details.Price);
                                c.Own.Balance24 = c.Own.BalanceE * c.Details.Change1D;
                                c.Own.TotalAchat = c.Own.TotalAchat + t.Total;
                                c.Own.Gains = c.Own.BalanceE - c.Own.TotalAchat;
                            }
                            else
                            {
                                c.Own.Balance = c.Own.Balance - t.Quantity;
                                c.Own.BalanceE = c.Own.BalanceE - (t.Quantity * c.Details.Price);
                                c.Own.Balance24 = c.Own.BalanceE * c.Details.Change1D;
                                c.Own.TotalAchat = c.Own.TotalAchat - t.Total;
                                c.Own.Gains = c.Own.BalanceE - c.Own.TotalAchat;
                                if (c.Own.Balance == 0)
                                {
                                    c.Own.OwnB = false;
                                }
                            }
                        }
                    }
                }
            }

            foreach (CryptoViewModel c in ItemsC)
            {
                if (c.Own.OwnB == true)
                {
                    CurrentUser.SoldeNow = CurrentUser.SoldeNow + c.Own.BalanceE;
                    CurrentUser.TotalAchat = CurrentUser.TotalAchat + c.Own.TotalAchat;
                    CurrentUser.Solde24 = CurrentUser.Solde24 + c.Own.Balance24;
                }
            }

            // Liste Acceuil
            this.ItemsM = new ObservableCollection<CryptoViewModel>();
            MainList();

            // Mets en place les valeur de base dans UserOwn

        }
        #endregion

        #region METHODS
        public static ObservableCollection<CryptoViewModel> GetCryptoList()
        {
            ObservableCollection<CryptoViewModel> list = new ObservableCollection<CryptoViewModel>();

            var dobj = ClassApi.MakeApiCAll();

            string codeErreur = dobj["status"]["error_code"];
            string messageErreur = dobj["status"]["error_message"];

            for (var i = 0; i < ClassApi.NbrCrypto; i++)
            {
                CurrentCrypto = new CryptoViewModel(new Crypto()
                {
                    Id = dobj["data"][i]["id"],
                    Name = dobj["data"][i]["name"],
                    Symbol = dobj["data"][i]["symbol"],
                    Details = new CryptoDetails()
                    {
                        Price = dobj["data"][i]["quote"]["EUR"]["price"],
                        Volume24H = dobj["data"][i]["quote"]["EUR"]["volume_24h"],
                        Change1H = dobj["data"][i]["quote"]["EUR"]["percent_change_1h"],
                        Change1D = dobj["data"][i]["quote"]["EUR"]["percent_change_24h"],
                        Change1W = dobj["data"][i]["quote"]["EUR"]["percent_change_7d"],
                        Marketcap = dobj["data"][i]["quote"]["EUR"]["market_cap"]
                    },
                    Own = new CryptoOwn()
                    {
                        Balance = 0,
                        Gains = 0,
                        BalanceE = 0,
                        OwnB = false,
                        TotalAchat = 0
                    }
                });

                list.Add(CurrentCrypto);
            }

            return list;
        }

        public void MainList()
        {
            ItemsM.Clear();

            foreach (CryptoViewModel element in ItemsC)
            {
                if (element.Own.OwnB is true)
                {
                    ItemsM.Add(element);
                }
            }
        }

        public void OpenFileT()
        {
            // File Transaction
            string jsonString = File.ReadAllText(Path + "\\dataT.json");

            if (jsonString != "")
            {
                List<Transaction>? transactions = System.Text.Json.JsonSerializer.Deserialize<List<Transaction>>(jsonString);
                if (transactions != null)
                {
                    foreach (Transaction t in transactions)
                    {
                        ItemsT.Add(new TransactionViewModel(t));
                    }
                }

                foreach (TransactionViewModel t in ItemsT)
                {
                    if (t.UserName == CurrentUser.UserName)
                    {
                        ItemsTU.Add(t);
                    }
                }
            }

            // File User
            string jsonString1 = File.ReadAllText(Path + "\\data.json");

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
            foreach (UserViewModel u in ItemsU)
            {
                u.SoldeNow = 1;
            }

            string jsonString1 = System.Text.Json.JsonSerializer.Serialize(ItemsU);
            File.WriteAllText(Path + "\\data.json", jsonString1);
        }

        public void SaveFileT()
        {
            string jsonString2 = System.Text.Json.JsonSerializer.Serialize(ItemsT);
            File.WriteAllText(Path + "\\dataT.json", jsonString2);
        }
        #endregion
    }
}
