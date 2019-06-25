using Diary.Models;

namespace Diary.ViewModels
{
    public class CategoryItemViewModel : SimpleViewModel
    {
        public Category Category { get; }

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
