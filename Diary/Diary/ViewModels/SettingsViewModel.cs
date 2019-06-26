using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diary.ViewModels
{
    class SettingsViewModel : SimpleViewModel
    {
        /// <summary>
        /// Время до выхода
        /// </summary>
        public int Cyberpunk => (new DateTime(2020, 04, 16) - DateTime.Now.Date).Days;

        /// <summary>
        /// Команда удаления базы данных
        /// </summary>
        public Command DropDBCommand { get; }

        public SettingsViewModel()
        {
            DropDBCommand = new Command(async () => await DropDbAsync());
        }

        /// <summary>
        /// Удаление и создание базы данных
        /// </summary>
        /// <returns></returns>
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
