using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoneyPage : ContentPage
    {
        public MoneyPage()
        {
            InitializeComponent();
            MoneyListView.ItemsSource = (App.Current as App).DbContext.Moneys.Select(i => i).ToArray();
         }
    }
}