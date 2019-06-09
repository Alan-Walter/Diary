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
        public DetailsTodoPage(TodoViewModel todoViewModel)
        {
            InitializeComponent();
            this.BindingContext = todoViewModel;
        }
    }
}