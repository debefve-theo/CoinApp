// Copyright © 2022 - Theo Debefve

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
        public string Path { get; set; }

        public ObservableCollection<CryptoViewModel> ItemsC { get; set; }
        public ObservableCollection<TransactionViewModel> ItemsT { get; set; }
        public ObservableCollection<CryptoViewModel> ItemsM { get; set; }

        #endregion

        #region MAIN
        public MainWindowViewModel(UserViewModel user)
        {
            CurrentUser = user;

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

            ItemsC = GetCryptoList();

            // Verif exist fichier + creation ***
            if (!File.Exists(Path + "\\dataT.json"))
            {
                File.Create(Path + "\\dataT.json");
            }

            // Transaction
            this.ItemsT = new ObservableCollection<TransactionViewModel>();

            //string jsonString = File.ReadAllText(Path + "dataT.json");

            /*List<Transaction>? transactions = JsonSerializer.Deserialize<List<Transaction>>(jsonString);
            if (transactions != null)
            {
                foreach (Transaction t in transactions)
                {
                    ItemsT.Add(new TransactionViewModel(t));
                }
            }*/

            // Crée la liste de résumé
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
                if (element.Own is not null)
                {
                    ItemsM.Add(element);
                }
            }
        }

        public void Save()
        {
            /*string jsonString = JsonSerializer.Serialize(ItemsT);
            File.WriteAllText("./DataTransaction.json", jsonString);*/
        }

        #endregion
    }
}
