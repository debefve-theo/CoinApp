using Model;
using System.Collections.ObjectModel;
using ClassLibrary;
using Newtonsoft.Json;

namespace ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public TransactionViewModel CurrentTransaction { get; set; }
        public static CryptoViewModel? CurrentCrypto { get; set; }
        public ObservableCollection<CryptoViewModel> ItemsC { get; set; }
        public ObservableCollection<TransactionViewModel> ItemsT { get; set; }
        public ObservableCollection<CryptoViewModel> ItemsM { get; set; }

        public MainWindowViewModel()
        {
            ItemsC = GetCryptoList();

            // Verif exist fichier + creation ***
            if (!File.Exists("./DataTransaction.json"))
            {
                File.Create("./DataTransaction.json");
            }

            // add test transaction
            this.ItemsT = new ObservableCollection<TransactionViewModel>();
            /*
            this.ItemsT.Add(new TransactionViewModel(new Transaction()
            {
                Id = 1001,
                Av = true,
                Quantity = 10,
                PricePerToken = 2500,
                Fees = 25,
                Date = new DateTime(2022, 04, 27, 09, 02, 13),
                Exchange = "Binance",
                Cryptocurrency = 
            }));

            this.ItemsT.Add(new TransactionViewModel(new Transaction()
            {
                Id = 1002,
                Av = true,
                Quantity = 2000,
                PricePerToken = 0.15,
                Fees = 0,
                Date = new DateTime(2022, 04, 27, 09, 03, 33),
                Exchange = "FTX",
            }));
            */

            this.ItemsM = new ObservableCollection<CryptoViewModel>();

            MainList();
        }

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
            foreach (CryptoViewModel element in ItemsC)
            {
                if (element.Own is not null)  
                {
                    ItemsM.Add(element);
                }
            }
        }

        public void UpdateMainList(double idc)
        {
            ItemsM.Clear();
            MainList();
        }

        public void Save()
        {
            string jsonS = JsonConvert.SerializeObject(CurrentTransaction, Formatting.Indented);
            var jsonD = JsonConvert.DeserializeObject(jsonS);
        }
    }
}
