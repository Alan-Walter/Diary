using Diary.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Diary.ViewModels
{
    class TaskPageViewModel : SimpleViewModel
    {
        DiaryTaskViewModel selectedDiaryTask;

        public IList<DiaryTaskViewModel> DiaryTaskViews { get; private set; }

        public DiaryTaskViewModel SelectedDiaryTask
        {
            get
            {
                return selectedDiaryTask;
            }
            set
            {
                SetPropertyValue(ref selectedDiaryTask, value);
            }
        }

        public TaskPageViewModel()
        {
            using (var dbContext = new ApplicationContext())
            {
                DiaryTaskViews = new ObservableCollection<DiaryTaskViewModel>(dbContext.DiaryTasks.Select(i => new DiaryTaskViewModel(i)));
            }
        }
    }
}
