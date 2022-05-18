using Model;

namespace ViewModel
{
    public class CryptoOwnViewModel : ViewModelBase
    {
        public CryptoOwn Model { get; set; }

        public CryptoOwnViewModel(CryptoOwn c)
        {
            this.Model = c;
        }

        public bool OwnB
        {
            get => this.Model.OwnB;
            set
            {
                this.Model.OwnB = value;
                this.NotifyPropertyChanged(nameof(OwnB));
            }
        }
        public double Balance
        {
            get => this.Model.Balance;
            set
            {
                this.Model.Balance = value;
                this.NotifyPropertyChanged(nameof(Balance));
            }
        }
        public double Gains
        {
            get => this.Model.Gains;
            set
            {
                this.Model.Gains = value;
                this.NotifyPropertyChanged(nameof(Gains));
            }
        }
        public double Allocation
        {
            get => this.Model.Allocation;
            set
            {
                this.Model.Allocation = value;
                this.NotifyPropertyChanged(nameof(Allocation));
            }
        }
    }
}
