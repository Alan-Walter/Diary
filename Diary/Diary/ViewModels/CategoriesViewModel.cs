using Diary.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Diary.ViewModels
{
    class CategoriesViewModel : SimpleViewModel
    {
        readonly CategoryRepository categoryRepository;

        public Command SelectCategoryCommand { get; }

        public MoneyViewModel MoneyViewModel { get; }

        public CategoryItemViewModel SelectedCategory { get; set; }

        public ObservableCollection<CategoryItemViewModel> CategoryItemViewModels
        {
            get => MoneyViewModel.CategoryItemViewModels;
            set
            {
                if (value == MoneyViewModel.CategoryItemViewModels) return;
                MoneyViewModel.CategoryItemViewModels = value;
                RaisePropertyChanged();
            }
        }

        public CategoriesViewModel(MoneyViewModel moneyViewModel)
        {
            MoneyViewModel = moneyViewModel;
            categoryRepository = new CategoryRepository();
        }
    }
}
