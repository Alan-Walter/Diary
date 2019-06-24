using Diary.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public ObservableCollection<CategoryItemViewModel> CategoryItemViewModels { get; }

        public CategoriesViewModel(MoneyViewModel moneyViewModel)
        {
            MoneyViewModel = moneyViewModel;
            categoryRepository = new CategoryRepository();
            CategoryItemViewModels = new ObservableCollection<CategoryItemViewModel>(MoneyViewModel.Categories.Select(i => new CategoryItemViewModel(i)));
        }
    }
}
