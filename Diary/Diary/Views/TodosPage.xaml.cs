using Diary.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodosPage : ContentPage
    {
        public TodosPage()
        {
            InitializeComponent();
            BindingContext = new TodosViewModel();
        }
    }
}