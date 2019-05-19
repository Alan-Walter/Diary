using Diary.Models;
using Diary.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Diary.ViewModels
{
    public class DiaryTaskViewModel : SimpleViewModel
    {
        DiaryTask diaryTask;

        public string Title
        {
            get { return diaryTask.Title; }
            set
            {
                if (value == Title) return;
                diaryTask.Title = value;
                RaisePropertyChanged();
            }
        }

        public string Description
        {
            get { return diaryTask.Description; }
            set
            {
                if (value == diaryTask.Description) return;
                diaryTask.Description = value;
                RaisePropertyChanged();
            }
        }

        public bool IsComplete
        {
            get { return diaryTask.IsComplete; }
            set
            {
                if (value == diaryTask.IsComplete) return;
                diaryTask.IsComplete = value;
                RaisePropertyChanged();
            }
        }

        public DiaryTaskViewModel(DiaryTask diaryTask)
        {
            this.diaryTask = diaryTask;
        }
    }
}
