using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diary.ViewModels
{
    class TodoPageViewModel : SimpleViewModel
    {
        TodoViewModel selectedTodo;

        public IList<TodoViewModel> TodoViews { get; private set; }
        public Command AddCommand { get; }

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
            AddCommand = new Command(async () => await AddTodoAsync());
        }

        private async Task AddTodoAsync()
        {
            await Shell.Current.GoToAsync("//todo/details");
        }
    }
}
