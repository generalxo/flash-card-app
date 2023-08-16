﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace flash_card_app.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {

        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;
        [ObservableProperty]
        string title;
        public bool IsNotBusy => !IsBusy;
    }
}
