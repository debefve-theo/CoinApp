// Copyright © 2022 - Theo Debefve

using System;
using Model;
using ViewModel;

namespace ViewModel
{
    public class CryptoViewModel : ViewModelBase
    {
        private Crypto _model;

        public CryptoViewModel(Crypto c)
        {
            this._model = c;
        }

        #region Get/Set

        private double Id
        {
            get => this._model.Id;
            set
            {
                this._model.Id = value;
                this.NotifyPropertyChanged(nameof(Id));
            }
        }

        private string Name
        {
            get => this._model.Name; 
            set
            {
                this._model.Name = value;
                this.NotifyPropertyChanged(nameof(Name));
            }
        }

        private string Symbol
        {
            get => this._model.Symbol; 
            set
            {
                this._model.Symbol = value;
                this.NotifyPropertyChanged(nameof(Symbol));
            }
        }

        private double Price
        {
            get => this._model.Price; 
            set
            {
                this._model.Price = value;
                this.NotifyPropertyChanged(nameof(Price));
            }
        }

        private double Volume24h
        {
            get => this._model.Volume24h; 
            set
            {
                this._model.Volume24h = value;
                this.NotifyPropertyChanged(nameof(Volume24h));
            }
        }

        private double Change1h
        {
            get => this._model.Change1h; 
            set
            {
                this._model.Change1h = value;
                this.NotifyPropertyChanged(nameof(Change1h));
            }
        }

        private double Change1d
        {
            get => this._model.Change1d; 
            set
            {
                this._model.Change1d = value;
                this.NotifyPropertyChanged(nameof(Change1d));
            }
        }

        private double Change1w
        {
            get => this._model.Change1w; 
            set
            {
                this._model.Change1w = value;
                this.NotifyPropertyChanged(nameof(Change1w));
            }
        }

        private double Marketcap
        {
            get => this._model.Marketcap;
            set
            {
                this._model.Marketcap = value;
                this.NotifyPropertyChanged(nameof(Marketcap));
            }
        }

        #endregion
    }
}
