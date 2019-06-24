using Diary.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
