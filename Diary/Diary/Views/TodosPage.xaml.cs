using Diary.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodosPage : ContentPage
    {
        readonly TodosViewModel todosViewModel;
        public TodosPage()
        {
            InitializeComponent();
            BindingContext = todosViewModel = new TodosViewModel();
        }

        protected override async void OnAppearing()
        {
            await todosViewModel.LoadAsync();
        }
    }
}