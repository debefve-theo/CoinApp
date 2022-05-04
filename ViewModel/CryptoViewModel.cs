// Copyright © 2022 - Theo Debefve

using Model;

namespace ViewModel
{
    public class CryptoViewModel : ViewModelBase
    {
        private readonly Crypto _model;

        public CryptoViewModel(Crypto c)
        {
            this._model = c;
        }

        #region Get/Set

        public double Id
        {
            get => this._model.Id;
            set
            {
                this._model.Id = value;
                this.NotifyPropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get => this._model.Name; 
            set
            {
                this._model.Name = value;
                this.NotifyPropertyChanged(nameof(Name));
            }
        }

        public string Symbol
        {
            get => this._model.Symbol; 
            set
            {
                this._model.Symbol = value;
                this.NotifyPropertyChanged(nameof(Symbol));
            }
        }

        public double Price
        {
            get => this._model.Price; 
            set
            {
                this._model.Price = value;
                this.NotifyPropertyChanged(nameof(Price));
            }
        }

        public double Volume24H
        {
            get => this._model.Volume24H; 
            set
            {
                this._model.Volume24H = value;
                this.NotifyPropertyChanged(nameof(Volume24H));
            }
        }

        public double Change1H
        {
            get => this._model.Change1H; 
            set
            {
                this._model.Change1H = value;
                this.NotifyPropertyChanged(nameof(Change1H));
            }
        }

        public double Change1D
        {
            get => this._model.Change1D; 
            set
            {
                this._model.Change1D = value;
                this.NotifyPropertyChanged(nameof(Change1D));
            }
        }

        public double Change1W
        {
            get => this._model.Change1W; 
            set
            {
                this._model.Change1W = value;
                this.NotifyPropertyChanged(nameof(Change1W));
            }
        }

        public double Marketcap
        {
            get => this._model.Marketcap;
            set
            {
                this._model.Marketcap = value;
                this.NotifyPropertyChanged(nameof(Marketcap));
            }
        }

        #endregion

        #region Methods


        #endregion
    }
}
