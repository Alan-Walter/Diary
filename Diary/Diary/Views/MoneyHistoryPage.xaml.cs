using Diary.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoneyHistoryPage : ContentPage
    {
        public MoneyHistoryPage()
        {
            InitializeComponent();
            this.BindingContext = new MoneyHistoryViewModel();
        }
    }
}