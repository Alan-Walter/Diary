using Diary.Repository;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diary.ViewModels
{
    class CategoriesViewModel : SimpleViewModel
    {
        readonly CategoryRepository categoryRepository;
        CategoryItemViewModel selectedCategory;
        private bool isVisible = false;

        #region Commands

        public Command AddCategoryCommand { get; }
        public Command DeleteCategoryCommand { get; }
        public Command EditCategoryCommand { get; }
        public Command CancelEditCommand { get; }
        public Command SaveCommand { get; }

        #endregion

        #region Properties
        public MoneyViewModel MoneyViewModel { get; }

        public CategoryItemViewModel SelectedCategory
        {
            get => selectedCategory;
            set
            {
                if (value == selectedCategory) return;
                selectedCategory = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<CategoryItemViewModel> CategoryItemViewModels { get; }

        public bool IsVisible
        {
            get => isVisible;
            set
            {
                if (value == isVisible) return;
                isVisible = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        public CategoriesViewModel(MoneyViewModel moneyViewModel)
        {
            MoneyViewModel = moneyViewModel;
            categoryRepository = new CategoryRepository();
            CategoryItemViewModels = new ObservableCollection<CategoryItemViewModel>(MoneyViewModel.Categories.Select(i => new CategoryItemViewModel(i)));

            AddCategoryCommand = new Command(() => AddCategory());
            DeleteCategoryCommand = new Command(async (_) => await DeleteCategoryAsync(_));
            EditCategoryCommand = new Command((_) => EditCategory(_));
            CancelEditCommand = new Command(() => CancelEdit());
            SaveCommand = new Command(async () => await SaveAsync());
        }

        #region Command methods
        private void AddCategory()
        {
            if (IsVisible) return;
            IsVisible = true;
            SelectedCategory = new CategoryItemViewModel(new Models.Category());
        }

        private async Task DeleteCategoryAsync(object obj)
        {
            if (IsVisible || !(obj is CategoryItemViewModel categoryItem)) return;
            bool res = await Shell.Current.DisplayAlert("Confirm action", "Delete this item ?", "Yes", "No");
            if (!res) return;
            await categoryRepository.DeleteAsync(categoryItem.Category);
            MoneyViewModel.Categories.Remove(categoryItem.Category);
            CategoryItemViewModels.Remove(categoryItem);
        }

        private void EditCategory(object obj)
        {
            if (IsVisible || !(obj is CategoryItemViewModel categoryItem)) return;
            SelectedCategory = categoryItem;
            IsVisible = true;
        }

        private void CancelEdit()
        {
            IsVisible = false;
            App.Database.Reset(SelectedCategory.Category);
            SelectedCategory.UpdateProperty();
            SelectedCategory = null;
        }

        private async Task SaveAsync()
        {
            if (string.IsNullOrEmpty(SelectedCategory?.Title)) return;
            IsVisible = false;
            if(App.Database.IsItNew(SelectedCategory.Category))
            {
                MoneyViewModel.Categories.Add(SelectedCategory.Category);
                CategoryItemViewModels.Add(SelectedCategory);
                await categoryRepository.CreateAsync(SelectedCategory.Category);
            }
            else await categoryRepository.UpdateAsync(SelectedCategory.Category);
            SelectedCategory = null;
        }

        #endregion
    }
}
