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
            SaveCommand = new Command(async (_) => await SaveTodoAsync(_), (_) => !string.IsNullOrEmpty((_ as TodoViewModel)?.Title));
            CancelCommand = new Command(async () => await CancelAsync());
            DeleteCommand = new Command(async (_) => await DeleteTodoAsync(_));
            //  https://metanit.com/sharp/xamarin/11.1.php
        }

        private async Task AddTodoAsync()
        {
            await Shell.Current.Navigation.PushAsync(new DetailsTodoPage(new TodoViewModel(new Models.Todo()) { TodoPageViewModel = this }));
        }

        private async Task SaveTodoAsync(object obj)
        {
            var todoViewModel = (obj as TodoViewModel);
            if (todoViewModel != null)
            {
                var todo = todoViewModel.Todo;
                var db = await repository.GetAsync(todo.Id);
                if (db == null)
                {
                    await repository.CreateAsync(todo);
                    TodoViews.Add(todoViewModel);
                }
                else await repository.UpdateAsync(todo);
                
            }
            await Shell.Current.Navigation.PopAsync();
        }

        private async Task DeleteTodoAsync(object obj)
        {
            var todoViewModel = (obj as TodoViewModel);
            if (todoViewModel != null)
            {
                var todo = todoViewModel.Todo;
                var db = await repository.GetAsync(todo.Id);
                if (db != null)
                    await repository.DeleteAsync(db);
            }
            await Shell.Current.Navigation.PopAsync();
        }

        private async Task CancelAsync()
        {
            await Shell.Current.Navigation.PopAsync();
        }
    }
}
