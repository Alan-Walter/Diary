using Diary.Models;
using Diary.Repository;
using Diary.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diary.ViewModels
{
    public class MoneyHistoryViewModel : SimpleViewModel
    {
        readonly IRepository<Money> repository;

        MoneyItemViewModel selectedMoneyItem;
       
        public Command AddCommand { get; }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command DeleteCommand { get; }
        public Command SelectCommand { get; }

        public List<Category> CategoryList { get; private set; }

        public IList<MoneyItemViewModel> MoneyItemViewModels { get; private set; }

        public MoneyItemViewModel SelectedMoneyItem
        {
            get { return selectedMoneyItem; }
            set
            {
                SetPropertyValue(ref selectedMoneyItem, value);
            }
        }

        public MoneyHistoryViewModel()
        {
            repository = new MoneyRepository();
            AddCommand = new Command(async _ => await AddAsync());
            SaveCommand = new Command(async (_) => await SaveAsync(_));
            CancelCommand = new Command(async () => await CancelAsync());
            DeleteCommand = new Command(async (_) => await DeleteAsync(_));
            SelectCommand = new Command(async () => await SelectAsync());
            LoadAsync().Wait();
        }

        private async Task LoadCategories()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var categories = await categoryRepository.GetAllAsync();
            this.CategoryList = categories.ToList();
        }

        private async Task AddAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            await LoadCategories();
            await Shell.Current.Navigation.PushAsync(new MoneyDetailsPage(new MoneyItemViewModel(new Money(), this)));
            IsBusy = false;
        }

        /// <summary>
        /// сделать загрузку
        /// </summary>
        /// <returns></returns>
        private async Task LoadAsync()
        {
            var moneys = await repository.GetAllAsync();
            MoneyItemViewModels = new ObservableCollection<MoneyItemViewModel>(moneys.Select(i => new MoneyItemViewModel(i, this)));
        }

        private async Task SaveAsync(object obj)
        {
            if (IsBusy) return;
            IsBusy = true;
            var moneyItemViewModel = (obj as MoneyItemViewModel);
            if (moneyItemViewModel != null)
            {
                var money = moneyItemViewModel.Money;
                var db = await repository.GetAsync(money.Id);
                if (db == null)
                {
                    await repository.CreateAsync(money);
                    MoneyItemViewModels.Add(moneyItemViewModel);
                }
                else await repository.UpdateAsync(money);

            }
            await Shell.Current.Navigation.PopAsync();
            IsBusy = false;
        }

        private async Task DeleteAsync(object obj)
        {
            if (IsBusy) return;
            IsBusy = true;
            var moneyItemViewModel = (obj as MoneyItemViewModel);
            if (moneyItemViewModel != null)
            {
                var todo = moneyItemViewModel.Money;
                var db = await repository.GetAsync(todo.Id);
                if (db != null)
                    await repository.DeleteAsync(db);
                MoneyItemViewModels.Remove(moneyItemViewModel);
            }
            await Shell.Current.Navigation.PopAsync();
            IsBusy = false;
        }

        private async Task CancelAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            await Shell.Current.Navigation.PopAsync();
            IsBusy = false;
        }

        private async Task SelectAsync()
        {
            if (SelectedMoneyItem == null) return;
            await LoadCategories();
            await Shell.Current.Navigation.PushAsync(new MoneyDetailsPage(SelectedMoneyItem));
            SelectedMoneyItem = null;
        }
    }
}
