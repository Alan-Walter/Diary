using Diary.Models;
using Diary.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsTodoPage : ContentPage
    {
        public DetailsTodoPage()
        {
            InitializeComponent();
            this.BindingContext = new TodoViewModel(new Todo());
        }

        public DetailsTodoPage(TodoViewModel todoViewModel) : this()
        {
            this.BindingContext = todoViewModel;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//todo/collection");
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.SendBackButtonPressed();
        }
    }
}