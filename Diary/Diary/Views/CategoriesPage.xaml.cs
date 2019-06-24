using Diary.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {
        public CategoriesPage(MoneyViewModel moneyViewModel)
        {
            InitializeComponent();
            BindingContext = new CategoriesViewModel(moneyViewModel);
        }
    }
}