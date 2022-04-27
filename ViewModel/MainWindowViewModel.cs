using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public TransactionViewModel CurrentTransaction { get; set; }

        public ObservableCollection<TransactionViewModel> Items { get; set; }

        public MainWindowViewModel()
        {
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
                    Volume24h = 32187076510,
                    Change1h = -5.15,
                    Change1d = -7.02,
                    Change1w = -8.29,
                    Marketcap = 726792252422
                },
                Quantity = 500,
                PricePerToken = 45200,
                Fees = 150,
                Date = new DateTime(2022, 04, 26, 22, 17, 48),
                Exchange = "Crypto.com"
            });

            this.Items = new ObservableCollection<TransactionViewModel>();
            this.Items.Add(this.CurrentTransaction);

            this.Items.Add(new TransactionViewModel(new Transaction()
                {
                    Id = 1001,
                    Av = true,
                    Cryptocurrency = new Crypto()
                    {
                        Id = 2001,
                        Name = "Ethereum",
                        Symbol = "ETH",
                        Price = 3000,
                        Volume24h = 32187076510,
                        Change1h = -5.15,
                        Change1d = -7.02,
                        Change1w = -8.29,
                        Marketcap = 726792252422
                    },
                    Quantity = 10,
                    PricePerToken = 2500,
                    Fees = 25,
                    Date = new DateTime(2022, 04, 27, 09, 02, 13),
                    Exchange = "Binance"
                }));

            this.Items.Add(new TransactionViewModel(new Transaction()
            {
                Id = 1002,
                Av = true,
                Cryptocurrency = new Crypto()
                {
                    Id = 2002,
                    Name = "Doge Coin",
                    Symbol = "DOGE",
                    Price = 0.12,
                    Volume24h = 32187076510,
                    Change1h = -5.15,
                    Change1d = -7.02,
                    Change1w = -8.29,
                    Marketcap = 726792252422
                },
                Quantity = 2000,
                PricePerToken = 0.15,
                Fees = 0,
                Date = new DateTime(2022, 04, 27, 09, 03, 33),
                Exchange = "FTX"
            }));
        }
    }
}
