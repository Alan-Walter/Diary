using Diary.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Diary.ViewModels
{
    class TodoPageViewModel : SimpleViewModel
    {
        TodoViewModel selectedTodo;

        public IList<TodoViewModel> TodoViews { get; private set; }

        public TodoViewModel SelectedTodo
        {
            get
            {
                return selectedTodo;
            }
            set
            {
                SetPropertyValue(ref selectedTodo, value);
            }
        }

        public TodoPageViewModel()
        {
            using (var dbContext = new ApplicationContext())
            {
                TodoViews = new ObservableCollection<TodoViewModel>(dbContext.Todos.Select(i => new TodoViewModel(i)));
            }
        }
    }
}
