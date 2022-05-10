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

        public MainWindowViewModel()
        {
            ItemsC = GetCryptoList();

            // Verif exist fichier + creation ***
            if (!File.Exists("./DataTransaction.json"))
            {
                File.Create("./DataTransaction.json");
            }

            CurrentTransaction = new TransactionViewModel(new Transaction()
            {
                Id = 1000,
                Av = true,
                Cryptocurrency = new Crypto()
                {
                    Id = 2000,
                    Name = "Bitcoin",
                    Symbol = "BTC",
                    Price = 45300,
                    Volume24H = 32187076510,
                    Change1H = -5.15,
                    Change1D = -7.02,
                    Change1W = -8.29,
                    Marketcap = 726792252422
                },
                Quantity = 500,
                PricePerToken = 45200,
                Fees = 150,
                Date = new DateTime(2022, 04, 26, 22, 17, 48),
                Exchange = "Crypto.com"
            });

            this.ItemsT = new ObservableCollection<TransactionViewModel>();
            this.ItemsT.Add(this.CurrentTransaction);

            this.ItemsT.Add(new TransactionViewModel(new Transaction()
                {
                    Id = 1001,
                    Av = true,
                    Cryptocurrency = new Crypto()
                    {
                        Id = 2001,
                        Name = "Ethereum",
                        Symbol = "ETH",
                        Price = 3000,
                        Volume24H = 32187076510,
                        Change1H = -5.15,
                        Change1D = -7.02,
                        Change1W = -8.29,
                        Marketcap = 726792252422
                    },
                    Quantity = 10,
                    PricePerToken = 2500,
                    Fees = 25,
                    Date = new DateTime(2022, 04, 27, 09, 02, 13),
                    Exchange = "Binance"
                }));

            this.ItemsT.Add(new TransactionViewModel(new Transaction()
            {
                Id = 1002,
                Av = true,
                Cryptocurrency = new Crypto()
                {
                    Id = 2002,
                    Name = "Doge Coin",
                    Symbol = "DOGE",
                    Price = 0.12,
                    Volume24H = 32187076510,
                    Change1H = -5.15,
                    Change1D = -7.02,
                    Change1W = -8.29,
                    Marketcap = 726792252422
                },
                Quantity = 2000,
                PricePerToken = 0.15,
                Fees = 0,
                Date = new DateTime(2022, 04, 27, 09, 03, 33),
                Exchange = "FTX"
            }));
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
                    Price = dobj["data"][i]["quote"]["EUR"]["price"],
                    Volume24H = dobj["data"][i]["quote"]["EUR"]["volume_24h"],
                    Change1H = dobj["data"][i]["quote"]["EUR"]["percent_change_1h"],
                    Change1D = dobj["data"][i]["quote"]["EUR"]["percent_change_24h"],
                    Change1W = dobj["data"][i]["quote"]["EUR"]["percent_change_7d"],
                    Marketcap = dobj["data"][i]["quote"]["EUR"]["market_cap"]
                });

                list.Add(CurrentCrypto);
            }

            return list;
        }
        /*
        private void getCryptoName()
        {

        }*/

        public void Save()
        {
            string jsonS = JsonConvert.SerializeObject(CurrentTransaction, Formatting.Indented);

            //int i = 1;

            var jsonD = JsonConvert.DeserializeObject(jsonS);

            //int j = 1;
        }
    }
}
