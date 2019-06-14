using Diary.Models;
using Diary.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Diary.ViewModels
{
    class MoneyHistoryViewModel : SimpleViewModel
    {
        readonly IRepository<Money> repository;

        MoneyItemViewModel selectedMoneyItem;

        public List<Category> CategoryList { get; }

        public Command AddCommand { get; }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command DeleteCommand { get; }

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
            var moneys = repository.GetAllAsync().Result;
            MoneyItemViewModels = new ObservableCollection<MoneyItemViewModel>(moneys.Select(i => new MoneyItemViewModel(i, this)));
            CategoryList = new CategoryRepository().GetAllAsync().Result.ToList();
        }
    }
}
