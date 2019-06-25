using Diary.Models;
using Diary.Repository;
using Diary.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diary.ViewModels
{
    public class MoneyViewModel : SimpleViewModel
    {
        ObservableCollection<MoneyItemViewModel> moneyItemViewModels;
        MoneyItemViewModel selectedMoneyItem;

        #region Repository

        readonly MoneyRepository moneyRepository;

        #endregion

        #region Properties

        public double Balance => MoneyItemViewModels?
            .Sum(i => i.Value) ?? 0;

        public double Income => MoneyItemViewModels?
            .Where(i => i.Value > 0 && i.Date.Month == DateTime.Now.Month && i.Date.Year == DateTime.Now.Year)
            .Sum(j => j.Value) ?? 0;
        public double Expense => MoneyItemViewModels?
            .Where(i => i.Value < 0 && i.Date.Month == DateTime.Now.Month && i.Date.Year == DateTime.Now.Year)
            .Sum(j => j.Value) ?? 0;

        public double AverageIncome => MoneyItemViewModels?
            .Where(j => j.Value > 0)
            .GroupBy(i => new { month = i.Date.Month, year = i.Date.Year })
            .Select(k => k.Sum(i => i.Value))
            .DefaultIfEmpty()
            .Average() ?? 0;

        public double AverageExpense => MoneyItemViewModels?
            .Where(j => j.Value < 0)
            .GroupBy(i => new { month = i.Date.Month, year = i.Date.Year })
            .Select(k => k.Sum(i => i.Value))
            .DefaultIfEmpty()
            .Average() ?? 0;

        public ObservableCollection<MoneyItemViewModel> MoneyItemViewModels
        {
            get => moneyItemViewModels;
            set
            {
                if (value == moneyItemViewModels) return;
                moneyItemViewModels = value;
                RaiseAllPropertiesChanged();
            }
        }

        public MoneyItemViewModel SelectedMoneyItem
        {
            get => selectedMoneyItem;
            set
            {
                if (value == selectedMoneyItem) return;
                selectedMoneyItem = value;
                RaisePropertyChanged();
            }
        }

        public List<Category> Categories { get; private set; }
        #endregion

        #region Commands

        public Command AddMoneyCommand { get; }
        public Command SaveMoneyCommand { get; }
        public Command DeleteMoneyCommand { get; }
        public Command SelectMoneyCommand { get; }
        public Command ShowCategoriesCommand { get; }
        public Command BackCommand { get; }

        #endregion

        public MoneyViewModel()
        {
            moneyRepository = new MoneyRepository();

            AddMoneyCommand = new Command(async _ => await AddMoneyAsync());
            SaveMoneyCommand = new Command(async (_) => await SaveMoneyAsync(_), (_) => (_ as MoneyItemViewModel)?.Value != 0);
            DeleteMoneyCommand = new Command(async (_) => await DeleteMoneyAsync(_));
            SelectMoneyCommand = new Command(async () => await SelectMoneyAsync());
            ShowCategoriesCommand = new Command(async () => await ShowCategoriesAsync());
        }

        #region Command methods

        public async Task LoadDataAsync()
        {
            if (moneyItemViewModels != null) return;
            IsBusy = true;
            var moneys = await moneyRepository.GetAllAsync();
            MoneyItemViewModels = new ObservableCollection<MoneyItemViewModel>(moneys.OrderByDescending(y => y.Date)
                .Select(i => new MoneyItemViewModel(i, this)));
            CategoryRepository categoryRepository = new CategoryRepository(); 
            var categories = await categoryRepository.GetAllAsync();
            Categories = categories.ToList();
            IsBusy = false;
        }

        private async Task AddMoneyAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            await Shell.Current.Navigation.PushAsync(new MoneyDetailsPage(new MoneyItemViewModel(new Money(), this)));
            IsBusy = false;
        }

        private async Task SaveMoneyAsync(object obj)
        {
            if (IsBusy) return;
            IsBusy = true;
            var moneyItemViewModel = (obj as MoneyItemViewModel);
            if (moneyItemViewModel != null)
            {
                var money = moneyItemViewModel.Money;
                if (App.Database.IsItNew(money))
                {
                    await moneyRepository.CreateAsync(money);
                    MoneyItemViewModels.Insert(0, moneyItemViewModel);
                }
                else
                    await moneyRepository.UpdateAsync(money);
                RaiseAllPropertiesChanged();

            }
            await Shell.Current.Navigation.PopAsync();
            IsBusy = false;
        }

        private async Task DeleteMoneyAsync(object obj)
        {
            if (IsBusy) return;
            bool res = await Shell.Current.DisplayAlert("Confirm action", "Delete this item ?", "Yes", "No");
            if (!res) return;
            IsBusy = true;
            var moneyItemViewModel = (obj as MoneyItemViewModel);
            if (moneyItemViewModel != null)
            {
                var todo = moneyItemViewModel.Money;
                if (!App.Database.IsItNew(todo))
                {
                    await moneyRepository.DeleteAsync(todo);
                    MoneyItemViewModels.Remove(moneyItemViewModel);
                    RaiseAllPropertiesChanged();
                }
            }
            await Shell.Current.Navigation.PopAsync();
            IsBusy = false;
        }

        private async Task SelectMoneyAsync()
        {
            if (SelectedMoneyItem == null) return;
            await Shell.Current.Navigation.PushAsync(new MoneyDetailsPage(SelectedMoneyItem));
            SelectedMoneyItem = null;
        }

        private async Task ShowCategoriesAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            await Shell.Current.Navigation.PushAsync(new CategoriesPage(this));
            IsBusy = false;
        }

        #endregion
    }
}
