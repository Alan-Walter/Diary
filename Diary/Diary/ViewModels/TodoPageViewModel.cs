using Diary.Models;
using Diary.Repository;
using Diary.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diary.ViewModels
{
    public class TodoPageViewModel : SimpleViewModel
    {
        readonly IRepository<Todo> repository;
        TodoViewModel selectedTodo;

        public IList<TodoViewModel> TodoViews { get; private set; }
        public Command AddCommand { get; }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command DeleteCommand { get; }

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
            repository = new TodoRepository();
            TodoViews = new ObservableCollection<TodoViewModel>(repository.GetListAsync().Result.Select(i => new TodoViewModel(i)));
            AddCommand = new Command(async () => await AddTodoAsync());
            SaveCommand = new Command(async (_) => await SaveTodoAsync(_));  //  добавить проверку CanExecute
        }

        private async Task AddTodoAsync()
        {
            await Shell.Current.Navigation.PushAsync(new DetailsTodoPage(new TodoViewModel(new Models.Todo()) { TodoPageViewModel = this }));
        }

        private async Task SaveTodoAsync(object obj)
        {
            var todoViewModel = (obj as TodoViewModel);
            if (todoViewModel == null) return;
            var todo = todoViewModel.Todo;
            var db = await repository.GetAsync(todo.Id);
            if (db == null)
                await repository.CreateAsync(todo);
            else await repository.UpdateAsync(todo);
            TodoViews.Add(todoViewModel);
            await Shell.Current.Navigation.PopAsync();
        }
    }
}
