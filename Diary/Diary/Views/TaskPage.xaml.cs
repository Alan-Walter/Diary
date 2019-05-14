using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage : ContentPage
    {
        public TaskPage()
        {
            InitializeComponent();
            TasksListView.ItemsSource = (App.Current as App).DbContext.DiaryTasks.Select(i => i).ToList();
        }



        private async void AddItem_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddTaskPage());
        }
    }
}