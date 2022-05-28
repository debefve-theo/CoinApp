// Copyright © 2022 - Theo Debefve

using Model;
using System.Collections.ObjectModel;
using ClassLibrary;
using Newtonsoft.Json;

namespace ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region VARIABLES
        public TransactionViewModel CurrentTransaction { get; set; }
        public static CryptoViewModel? CurrentCrypto { get; set; }
        public UserViewModel? CurrentUser { get; set; }
        public String FolderPath { get; set; }

        public ObservableCollection<CryptoViewModel> ItemsC { get; set; }
        public ObservableCollection<TransactionViewModel> ItemsT { get; set; }
        public ObservableCollection<CryptoViewModel> ItemsM { get; set; }

        #endregion

        #region MAIN
        public MainWindowViewModel(UserViewModel user)
        {
            CurrentUser = user;

            ItemsC = GetCryptoList();

            // Verif exist fichier + creation ***
            if (!File.Exists("./DataTransaction.json"))
            {
                File.Create("./DataTransaction.json");
            }

            // Crée la liste de transaction
            this.ItemsT = new ObservableCollection<TransactionViewModel>();

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
            CurrentUser.SoldeNow = 0;
            CurrentUser.TotalAchat = 0;

            foreach (CryptoViewModel element in ItemsC)
            {
                if (element.Own is not null)  
                {
                    ItemsM.Add(element);
                    //SoldeNow = SoldeNow + element.Own.BalanceE;
                    CurrentUser.SoldeNow = CurrentUser.SoldeNow + element.Own.BalanceE;
                    //TotalAchat = TotalAchat + element.Own.TotalAchat;
                    CurrentUser.TotalAchat = CurrentUser.TotalAchat + element.Own.TotalAchat;
                }
            }
        }

        public void UpdateMainList()
        {
            ItemsM.Clear();
            MainList();
        }

        public void UpdateTotalAcahat()
        {
            foreach (TransactionViewModel element in ItemsT)
            {
                CurrentUser.TotalAchat = CurrentUser.TotalAchat + element.Total;
            }
        }

        public void Save()
        {
            string jsonS = JsonConvert.SerializeObject(CurrentTransaction, Formatting.Indented);
            var jsonD = JsonConvert.DeserializeObject(jsonS);
        }

        #endregion
    }
}
