using Diary.Models;
using Diary.Models.Database;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diary.ViewModels
{
    public class TodoViewModel : SimpleViewModel
    {
        readonly Todo todo;

        public Command SaveCommand { get; }

        public string Title
        {
            get { return todo.Title; }
            set
            {
                if (value == Title) return;
                todo.Title = value;
                RaisePropertyChanged();
                SaveCommand.ChangeCanExecute();
            }
        }

        public string Notes
        {
            get { return todo.Notes; }
            set
            {
                if (value == todo.Notes) return;
                todo.Notes = value;
                RaisePropertyChanged();
            }
        }

        public bool Completed
        {
            get { return todo.Completed; }
            set
            {
                if (value == todo.Completed) return;
                todo.Completed = value;
                RaisePropertyChanged();
            }
        }

        public TodoViewModel(Todo todo)
        {
            this.todo = todo;
            SaveCommand = new Command(async () => await Save(), 
                () => !string.IsNullOrEmpty(Title));
        }

        private async Task Save()
        {
            using(var dbContext = new ApplicationContext())
            {
                dbContext.Todos.Add(todo);
                await dbContext.SaveChangesAsync();
            }
            Shell.Current.SendBackButtonPressed();
        }
    }
}
