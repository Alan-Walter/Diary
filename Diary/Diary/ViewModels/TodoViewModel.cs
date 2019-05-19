using Diary.Models;
using Diary.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Diary.ViewModels
{
    public class TodoViewModel : SimpleViewModel
    {
        Todo todo;

        public string Title
        {
            get { return todo.Title; }
            set
            {
                if (value == Title) return;
                todo.Title = value;
                RaisePropertyChanged();
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
        }
    }
}
