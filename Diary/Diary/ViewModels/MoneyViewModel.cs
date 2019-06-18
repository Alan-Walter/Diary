using Diary.Models;
using Diary.Repository;
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

        public double Balance => MoneyItemViewModels?.Sum(i => i.Value) ?? 0;

        public double Income => MoneyItemViewModels?.Where(i => i.Value > 0
            && i.Date.Month == DateTime.Now.Month && i.Date.Year == DateTime.Now.Year).Sum(j => j.Value) ?? 0;
        public double Expense => MoneyItemViewModels?.Where(i => i.Value < 0 
            && i.Date.Month == DateTime.Now.Month && i.Date.Year == DateTime.Now.Year).Sum(j => j.Value) ?? 0;

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

        public Command AddCategoryCommand { get; }
        public Command AddMoneyCommand { get; }
        public Command ShowHistoryCommand { get; }

        #endregion

        public MoneyViewModel()
        {
            categoryRepository = new CategoryRepository();
            moneyRepository = new MoneyRepository();
        }

        public async Task LoadDataAsync()
        {
            if (moneyItemViewModels != null) return;
            var moneys = await moneyRepository.GetAllAsync();
            MoneyItemViewModels = new ObservableCollection<MoneyItemViewModel>(moneys.Select(i => new MoneyItemViewModel(i, this)));
            var categories = await categoryRepository.GetAllAsync();
            CategoryList = categories.ToList();
        }

    }
}
