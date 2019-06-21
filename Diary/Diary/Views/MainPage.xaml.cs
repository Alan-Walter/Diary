using Diary.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Diary.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : Shell
    {
        readonly MoneyViewModel moneyViewModel;
        public MainPage()
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
