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
            this.BindingContext = new DiaryTaskViewModel(new Models.Database.DiaryTask());
        }

        public AddEditTaskPage(DiaryTaskViewModel diaryTaskViewModel) : this()
        {
            this.BindingContext = diaryTaskViewModel;
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