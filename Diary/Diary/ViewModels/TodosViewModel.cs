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
        TodoRepository repository;
        TodoItemViewModel selectedTodo;

        #region Commands

        public Command AddCommand { get; }
        public Command SaveCommand { get; }
        public Command DeleteCommand { get; }
        public Command SelectCommand { get; }
        public Command CompleteCommand { get; }
        public Command BackCommand { get; }


        #endregion

        #region Properties

        public IList<TodoItemViewModel> TodoViews { get; private set; }

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

        #endregion

        public TodosViewModel()
        {
            AddCommand = new Command(async () => await AddTodoAsync());
            SaveCommand = new Command(async (_) => await SaveTodoAsync(_), (_) => !string.IsNullOrEmpty((_ as TodoItemViewModel)?.Title));
            DeleteCommand = new Command(async (_) => await DeleteTodoAsync(_));
            SelectCommand = new Command(async () => await SelectTodoAsync());
            CompleteCommand = new Command(async (_) => await CompleteTodoAsync(_));
            //  https://metanit.com/sharp/xamarin/11.1.php
        }

        #region Command methods

        public async Task LoadAsync()
        {
            if (repository != null) return;
            IsBusy = true;
            repository = new TodoRepository();
            var todos = await repository.GetAllAsync();
            TodoViews = new ObservableCollection<TodoItemViewModel>(todos.Select(i => new TodoItemViewModel(i, this)));
            IsBusy = false;
        }

        private async Task AddTodoAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            await Shell.Current.Navigation.PushAsync(new TodoDetailsPage(new TodoItemViewModel(new Models.Todo(), this)));
            IsBusy = false;
        }

        private async Task SaveTodoAsync(object obj)
        {
            if (IsBusy) return;
            IsBusy = true;
            var todoViewModel = (obj as TodoItemViewModel);
            if (todoViewModel != null)
            {
                var todo = todoViewModel.Todo;
                if (App.Database.IsItNew(todo))
                {
                    await repository.CreateAsync(todo);
                    TodoViews.Add(todoViewModel);
                }
                else await repository.UpdateAsync(todo);
                
            }
            await Shell.Current.Navigation.PopAsync();
            IsBusy = false;
        }

        private async Task DeleteTodoAsync(object obj)
        {
            if (IsBusy) return;
            bool res = await Shell.Current.DisplayAlert("Confirm action", "Delete this item ?", "Yes", "No");
            if (!res) return;
            IsBusy = true;
            var todoViewModel = (obj as TodoItemViewModel);
            if (todoViewModel != null)
            {
                var todo = todoViewModel.Todo;
                if (!App.Database.IsItNew(todo))
                {
                    await repository.DeleteAsync(todo);
                    TodoViews.Remove(todoViewModel);
                }
            }
            await Shell.Current.Navigation.PopAsync();
            IsBusy = false;
        }

        private async Task SelectTodoAsync()
        {
            if (SelectedTodo == null) return;
            await Shell.Current.Navigation.PushAsync(new TodoDetailsPage(SelectedTodo));
            SelectedTodo = null;
        }

        private async Task CompleteTodoAsync(object todo)
        {
            if (IsBusy) return;
            IsBusy = true;
            if (!(todo is TodoItemViewModel todoitem)) return;
            todoitem.Completed = !todoitem.Completed;
            await repository.UpdateAsync(todoitem.Todo);
            IsBusy = false;
        }

        #endregion
    }
}
