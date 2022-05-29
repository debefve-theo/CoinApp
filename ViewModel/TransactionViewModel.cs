// Copyright © 2022 - Theo Debefve

using Model;

namespace ViewModel
{
    public class TransactionViewModel : ViewModelBase
    {
        private Transaction _model;

        public TransactionViewModel(Transaction t)
        {
            this._model = t;
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

        public string UserName
        {
            get => this._model.UserName;
            set
            {
                this._model.UserName = value;
                this.NotifyPropertyChanged(nameof(UserName));
            }
        }

        public bool Av
        {
            get => this._model.Av;
            set
            {
                this._model.Av = value;
                this.NotifyPropertyChanged(nameof(Av));
            }
        }

        public double Quantity
        {
            get => this._model.Quantity;
            set
            {
                this._model.Quantity = value;
                this.NotifyPropertyChanged(nameof(Quantity));
                this.NotifyPropertyChanged(nameof(Price));
                this.NotifyPropertyChanged(nameof(Total));
            }
        }

        public double PricePerToken
        {
            get => this._model.PricePerToken;
            set
            {
                this._model.PricePerToken = value;
                this.NotifyPropertyChanged(nameof(PricePerToken));
                this.NotifyPropertyChanged(nameof(Price));
                this.NotifyPropertyChanged(nameof(Total));
            }
        }

        public double Fees
        {
            get => this._model.Fees;
            set
            {
                this._model.Fees = value;
                this.NotifyPropertyChanged(nameof(Fees));
                this.NotifyPropertyChanged(nameof(Total));
            }
        }

        public DateTime Date
        {
            get => this._model.Date;
            set
            {
                this._model.Date = value;
                this.NotifyPropertyChanged(nameof(Date));
            }
        }

        public string Exchange
        {
            get => this._model.Exchange;
            set
            {
                this._model.Exchange = value;
                this.NotifyPropertyChanged(nameof(Exchange));
            }
        }

        public Crypto Cryptocurrency
        {
            get => this._model.Cryptocurrency;
            set
            {
                this._model.Cryptocurrency = value;
                this.NotifyPropertyChanged(nameof(Cryptocurrency));
            }
        }

        public double Price
        {
            get { return _model.Price; }
        }

        public double Total
        {
            get { return _model.Total; }
        }

        #endregion
    }
}
