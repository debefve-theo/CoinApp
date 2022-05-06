﻿// Copyright © 2022 - Theo Debefve

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

        #endregion
    }
}