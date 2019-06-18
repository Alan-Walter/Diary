using Diary.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoneyPage : ContentPage
    {
        readonly MoneyViewModel moneyViewModel;
        public MoneyPage()
        {
            InitializeComponent();
            BindingContext = moneyViewModel = new MoneyViewModel();
        }

        protected override async void OnAppearing()
        {
            await moneyViewModel.LoadDataAsync();
        }
    }
}