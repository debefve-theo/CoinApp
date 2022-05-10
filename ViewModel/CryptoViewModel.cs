// Copyright © 2022 - Theo Debefve

using Model;

namespace ViewModel
{
    public class CryptoViewModel : ViewModelBase
    {
        public Crypto Model { get; set; }

        public CryptoViewModel(Crypto c)
        {
            this.Model = c;
        }

        #region Get/Set

        public double Id
        {
            get => this.Model.Id;
            set
            {
                this.Model.Id = value;
                this.NotifyPropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get => this.Model.Name; 
            set
            {
                this.Model.Name = value;
                this.NotifyPropertyChanged(nameof(Name));
            }
        }

        public string Symbol
        {
            get => this.Model.Symbol; 
            set
            {
                this.Model.Symbol = value;
                this.NotifyPropertyChanged(nameof(Symbol));
            }
        }

        public double Price
        {
            get => this.Model.Price; 
            set
            {
                this.Model.Price = value;
                this.NotifyPropertyChanged(nameof(Price));
            }
        }

        public double Volume24H
        {
            get => this.Model.Volume24H; 
            set
            {
                this.Model.Volume24H = value;
                this.NotifyPropertyChanged(nameof(Volume24H));
            }
        }

        public double Change1H
        {
            get => this.Model.Change1H; 
            set
            {
                this.Model.Change1H = value;
                this.NotifyPropertyChanged(nameof(Change1H));
            }
        }

        public double Change1D
        {
            get => this.Model.Change1D; 
            set
            {
                this.Model.Change1D = value;
                this.NotifyPropertyChanged(nameof(Change1D));
            }
        }

        public double Change1W
        {
            get => this.Model.Change1W; 
            set
            {
                this.Model.Change1W = value;
                this.NotifyPropertyChanged(nameof(Change1W));
            }
        }

        public double Marketcap
        {
            get => this.Model.Marketcap;
            set
            {
                this.Model.Marketcap = value;
                this.NotifyPropertyChanged(nameof(Marketcap));
            }
        }

        #endregion

        #region Methods


        #endregion
    }
}
