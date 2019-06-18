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
    public class TodosViewModel : SimpleViewModel
    {
        IRepository<Todo> repository;
        bool isBusy = false;
        TodoItemViewModel selectedTodo;

        public IList<TodoItemViewModel> TodoViews { get; private set; }
        public Command AddCommand { get; }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command DeleteCommand { get; }
        public Command SelectCommand { get; }

        public TodoItemViewModel SelectedTodo
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

        public TodosViewModel()
        {
            AddCommand = new Command(async () => await AddTodoAsync());
            SaveCommand = new Command(async (_) => await SaveTodoAsync(_), (_) => !string.IsNullOrEmpty((_ as TodoItemViewModel)?.Title));
            CancelCommand = new Command(async () => await CancelAsync());
            DeleteCommand = new Command(async (_) => await DeleteTodoAsync(_));
            SelectCommand = new Command(async () => await Select());
            //  https://metanit.com/sharp/xamarin/11.1.php
        }

        public async Task LoadAsync()
        {
            if (repository != null) return;
            repository = new TodoRepository();
            var todos = await repository.GetAllAsync();
            TodoViews = new ObservableCollection<TodoItemViewModel>(todos.Select(i => new TodoItemViewModel(i, this)));
        }

        private async Task AddTodoAsync()
        {
            if (isBusy) return;
            isBusy = true;
            await Shell.Current.Navigation.PushAsync(new TodoDetailsPage(new TodoItemViewModel(new Models.Todo(), this)));
            isBusy = false;
        }

        private async Task SaveTodoAsync(object obj)
        {
            if (isBusy) return;
            isBusy = true;
            var todoViewModel = (obj as TodoItemViewModel);
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
            //await Shell.Current.Navigation.PopToRootAsync();
            await Shell.Current.Navigation.PopAsync();
            isBusy = false;
        }

        private async Task DeleteTodoAsync(object obj)
        {
            if (isBusy) return;
            isBusy = true;
            var todoViewModel = (obj as TodoItemViewModel);
            if (todoViewModel != null)
            {
                var todo = todoViewModel.Todo;
                var db = await repository.GetAsync(todo.Id);
                if (db != null)
                    await repository.DeleteAsync(db);
                TodoViews.Remove(todoViewModel);
            }
            //await Shell.Current.Navigation.PopToRootAsync();
            await Shell.Current.Navigation.PopAsync();
            isBusy = false;
        }

        private async Task CancelAsync()
        {
            if (isBusy) return;
            isBusy = true;
            //await Shell.Current.Navigation.PopToRootAsync();
            await Shell.Current.Navigation.PopAsync();
            isBusy = false;
        }

        private async Task Select()
        {
            if (SelectedTodo == null) return;
            await Shell.Current.Navigation.PushAsync(new TodoDetailsPage(SelectedTodo));
            SelectedTodo = null;
        }
    }
}
