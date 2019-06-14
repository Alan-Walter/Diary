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

        public Command LoadCommand { get; }

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
            LoadCommand = new Command(async _ => await Load());
        }

        private async Task AddAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            CategoryRepository categoryRepository = new CategoryRepository();
            var categories = await categoryRepository.GetAllAsync();
            this.CategoryList = categories.ToList();
            await Shell.Current.Navigation.PushAsync(new MoneyDetailsPage(new MoneyItemViewModel(new Money(), this)));
            IsBusy = false;
        }

        private async Task Load()
        {
            var moneys = await repository.GetAllAsync();
            MoneyItemViewModels = new ObservableCollection<MoneyItemViewModel>(moneys.Select(i => new MoneyItemViewModel(i, this)));
        }
    }
}
