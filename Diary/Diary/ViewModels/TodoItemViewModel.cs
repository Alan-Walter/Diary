using Diary.Models;

namespace Diary.ViewModels
{
    /// <summary>
    /// View model для Todo
    /// </summary>
    public class TodoItemViewModel : SimpleViewModel
    {
        /// <summary>
        /// Объект базы данных
        /// </summary>
        public Todo Todo { get; private set; }

        /// <summary>
        /// View Model со всеми todo
        /// </summary>
        public TodosViewModel TodoPageViewModel { get; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title
        {
            get { return Todo.Title; }
            set
            {
                if (value == Title) return;
                Todo.Title = value;
                RaisePropertyChanged();
                TodoPageViewModel.SaveCommand.ChangeCanExecute();
            }
        }

        /// <summary>
        /// Заметки
        /// </summary>
        public string Notes
        {
            get { return Todo.Notes; }
            set
            {
                if (value == Todo.Notes) return;
                Todo.Notes = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Выполнение задания
        /// </summary>
        public bool Completed
        {
            get { return Todo.Completed; }
            set
            {
                if (value == Todo.Completed) return;
                Todo.Completed = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="todo"></param>
        /// <param name="todoPageViewModel"></param>
        public TodoItemViewModel(Todo todo, TodosViewModel todoPageViewModel)
        {
            this.Todo = todo;
            this.TodoPageViewModel = todoPageViewModel;
        }
    }
}
