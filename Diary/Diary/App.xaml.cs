using Diary.Views;
using Xamarin.Forms;

namespace Diary
{
    public partial class App : Application
    {
        /// <summary>
        /// Объект для работы с базой данных
        /// </summary>
        static ApplicationContext database;

        public static ApplicationContext Database
        {
            get
            {
                if (database == null)
                    database = new ApplicationContext();
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
