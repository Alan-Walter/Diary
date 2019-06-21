﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diary.ViewModels
{
    class SettingsViewModel : SimpleViewModel
    {
        public int Cyberpunk => (new DateTime(2020, 04, 16) - DateTime.Now.Date).Days;

        public Command DropDBCommand { get; }

        public SettingsViewModel()
        {
            DropDBCommand = new Command(async () => await DropDbAsync());
        }

        private async Task DropDbAsync()
        {
            bool res = await Shell.Current.DisplayAlert("Confirm action", "Drop Database ?", "Yes", "No");
            if (!res) return;
            IsBusy = true;
            await App.Database.Database.EnsureDeletedAsync();
            await App.Database.Database.EnsureCreatedAsync();
            IsBusy = false;
        }
    }
}
