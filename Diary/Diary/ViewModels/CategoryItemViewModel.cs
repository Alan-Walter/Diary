using Diary.Models;

namespace Diary.ViewModels
{
    public class CategoryItemViewModel : SimpleViewModel
    {
        /// <summary>
        /// Объект базы данных
        /// </summary>
        public Category Category { get; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title
        {
            get => Category.Title;
            set
            {
                if (value == Category.Title) return;
                Category.Title = value;
                RaisePropertyChanged();
            }
        }

        public CategoryItemViewModel(Category category)
        {
            Category = category;
        }

        public void UpdateProperty()
        {
            RaisePropertyChanged("Title");
        }
    }
}
