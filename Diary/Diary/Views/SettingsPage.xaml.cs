using Diary.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        readonly SettingsViewModel settingsViewModel;
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = settingsViewModel = new SettingsViewModel();
        }
    }
}