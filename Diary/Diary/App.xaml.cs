using Diary.Models;
using Diary.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary
{
    public partial class App : Application
    {
        public readonly ApplicationContext DbContext;

        public const string DBFileName = "diaryapp.db";
        public App()
        {
            InitializeComponent();
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(DBFileName);
            DbContext = new ApplicationContext(dbPath);
            // Создаем бд, если она отсутствует
            DbContext.Database.EnsureCreated();
            MainPage = new NavigationPage(new MainPage());
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
