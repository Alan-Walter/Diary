using System.ComponentModel;
using Xamarin.Forms;

namespace Diary.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            //  https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/app-fundamentals/shell/navigation
            Routing.RegisterRoute("//todo/details", typeof(DetailsTodoPage));
        }
    }
}
