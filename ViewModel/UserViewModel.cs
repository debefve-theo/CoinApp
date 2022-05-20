// Copyright © 2022 - Theo Debefve

using Model;

namespace ViewModel
{
    public class UserViewModel : ViewModelBase
    {
        private readonly User _model;

        public UserViewModel(User u)
        {
            this._model = u;
        }

        #region Get/set

        public int Id
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

        public string Password
        {
            get => this._model.Password;
            set
            {
                this._model.Password = value;
                this.NotifyPropertyChanged(nameof(Password));
            }
        }

        public UserOwn Own
        {
            get => this._model.Own;
            set
            {
                this._model.Own = value;
                this.NotifyPropertyChanged(nameof(Own));
            }
        }
        /*
        public double SoldeNow
        {
            get => this._model.SoldeNow;
            set
            {
                this._model.SoldeNow = value;
                this.NotifyPropertyChanged(nameof(SoldeNow));
            }
        }

        public double TotalAchat
        {
            get => this._model.TotalAchat;
            set
            {
                this._model.TotalAchat = value;
                this.NotifyPropertyChanged(nameof(TotalAchat));
            }
        }

        public double GainPerte
        {
            get => this._model.GainPerte;
            set
            {
                this._model.GainPerte = value;
                this.NotifyPropertyChanged(nameof(GainPerte));
            }
        }
        */
        #endregion
    }
}