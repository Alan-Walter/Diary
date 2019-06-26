using Diary.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {
        readonly CategoriesViewModel categoriesViewModel;
        public CategoriesPage(MoneyViewModel moneyViewModel)
        {
            InitializeComponent();
            BindingContext = categoriesViewModel = new CategoriesViewModel(moneyViewModel);
        }
    }
}