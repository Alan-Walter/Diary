using Diary.Repository;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diary.ViewModels
{
    /// <summary>
    /// View Model категорий
    /// </summary>
    class CategoriesViewModel : SimpleViewModel
    {
        /// <summary>
        /// Репозиторий категорий
        /// </summary>
        readonly CategoryRepository categoryRepository;
        /// <summary>
        /// Выбранный объект категории
        /// </summary>
        CategoryItemViewModel selectedCategory;
        /// <summary>
        /// Видимость строки ввода
        /// </summary>
        private bool isVisible = false;

        #region Commands
        /// <summary>
        /// Добавление категории
        /// </summary>
        public Command AddCategoryCommand { get; }
        /// <summary>
        /// Удаление категории
        /// </summary>
        public Command DeleteCategoryCommand { get; }
        /// <summary>
        /// Редактирование категории
        /// </summary>
        public Command EditCategoryCommand { get; }
        /// <summary>
        /// Отмена редактирования категории
        /// </summary>
        public Command CancelEditCommand { get; }
        /// <summary>
        /// Сохранение категории
        /// </summary>
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

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="moneyViewModel"></param>
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
        /// <summary>
        /// Добавление категории
        /// </summary>
        private void AddCategory()
        {
            if (IsVisible) return;
            IsVisible = true;
            SelectedCategory = new CategoryItemViewModel(new Models.Category());
        }

        /// <summary>
        /// Удаление категории
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private async Task DeleteCategoryAsync(object obj)
        {
            if (IsVisible || !(obj is CategoryItemViewModel categoryItem)) return;
            bool res = await Shell.Current.DisplayAlert("Confirm action", "Delete this item ?", "Yes", "No");
            if (!res) return;
            await categoryRepository.DeleteAsync(categoryItem.Category);
            MoneyViewModel.Categories.Remove(categoryItem.Category);
            CategoryItemViewModels.Remove(categoryItem);
        }

        /// <summary>
        /// Изменение категории
        /// </summary>
        /// <param name="obj"></param>
        private void EditCategory(object obj)
        {
            if (IsVisible || !(obj is CategoryItemViewModel categoryItem)) return;
            SelectedCategory = categoryItem;
            IsVisible = true;
        }

        /// <summary>
        /// Завершение изменения
        /// </summary>
        private void CancelEdit()
        {
            IsVisible = false;
            ResetDbActiveItem();
            SelectedCategory.UpdateProperty();
            SelectedCategory = null;
        }

        /// <summary>
        /// Асинхронное сохранение
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Сброс объекта базы данных
        /// </summary>
        private void ResetDbActiveItem()
        {
            if (SelectedCategory != null && !App.Database.IsItNew(SelectedCategory.Category))
                App.Database.Reset(SelectedCategory.Category);
        }
    }
}
