using Model;

namespace ViewModel
{
    public class CryptoDetailsViewModel : ViewModelBase
    {
        public CryptoDetails Model { get; set; }

        public CryptoDetailsViewModel(CryptoDetails c)
        {
            this.Model = c;
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
    }
}
