using Diary.ViewModels;
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
            BindingContext = new TodoPageViewModel();
        }

        private async void AddItem_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEditTaskPage());
        }

        private void Todo_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            TodoViewModel todo = (TodoViewModel)e.Item;
            Navigation.PushAsync(new AddEditTaskPage(todo), true);
        }
    }
}