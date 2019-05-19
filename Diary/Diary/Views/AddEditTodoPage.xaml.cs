using Diary.Models;
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
    public partial class AddEditTaskPage : ContentPage
    {
        public AddEditTaskPage()
        {
            InitializeComponent();
            this.BindingContext = new TodoViewModel(new Models.Database.Todo());
        }

        public AddEditTaskPage(TodoViewModel todoViewModel) : this()
        {
            this.BindingContext = todoViewModel;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PopAsync();
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}