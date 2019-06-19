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

        #region Repository

        readonly CategoryRepository categoryRepository;
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
            get { return moneyItemViewModels; }
            set
            {
                if (value == moneyItemViewModels) return;
                moneyItemViewModels = value;
                RaiseAllPropertiesChanged();
            }
        }

        public List<Category> CategoryList { get; private set; }

        #endregion

        #region Commands

        public Command CategoriesCommand { get; }
        public Command AddMoneyCommand { get; }
        public Command HistoryCommand { get; }
        public Command SaveMoneyCommand { get; }

        #endregion

        public MoneyViewModel()
        {
            categoryRepository = new CategoryRepository();
            moneyRepository = new MoneyRepository();
            IsBusy = true;
            AddMoneyCommand = new Command(async _ => await AddMoneyAsync());
            SaveMoneyCommand = new Command(async (_) => await SaveMoneyAsync(_));
        }

        public async Task LoadDataAsync()
        {
            if (moneyItemViewModels != null) return;
            var moneys = await moneyRepository.GetAllAsync();
            MoneyItemViewModels = new ObservableCollection<MoneyItemViewModel>(moneys.Select(i => new MoneyItemViewModel(i, this)));
            var categories = await categoryRepository.GetAllAsync();
            CategoryList = categories.ToList();
            MoneyItemViewModels.CollectionChanged += (sender, e) => RaiseAllPropertiesChanged();
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
                var db = await moneyRepository.GetAsync(money.Id);
                if (db == null)
                {
                    await moneyRepository.CreateAsync(money);
                    MoneyItemViewModels.Add(moneyItemViewModel);
                }
                else await moneyRepository.UpdateAsync(money);

            }
            await Shell.Current.Navigation.PopAsync();
            IsBusy = false;
        }
    }
}
