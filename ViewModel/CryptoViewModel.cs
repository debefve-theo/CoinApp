// Copyright © 2022 - Theo Debefve
// Examen JUIN 2022

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
        public CryptoDetails Details
        {
            get => this.Model.Details;
            set
            {
                this.Model.Details = value;
                this.NotifyPropertyChanged(nameof(Details));
            }
        }
        public CryptoOwn Own
        {
            get => this.Model.Own;
            set
            {
                this.Model.Own = value;
                this.NotifyPropertyChanged(nameof(Own));
            }
        }
        #endregion
    }
}
