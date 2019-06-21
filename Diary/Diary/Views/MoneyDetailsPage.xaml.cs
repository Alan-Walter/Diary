using Diary.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoneyDetailsPage : ContentPage
    {
        public MoneyDetailsPage(MoneyItemViewModel moneyItemViewModel)
        {
            InitializeComponent();
            this.BindingContext = moneyItemViewModel;
        }
    }
}