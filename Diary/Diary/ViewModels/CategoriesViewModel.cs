using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.ViewModels
{
    class CategoriesViewModel : SimpleViewModel
    {
        public MoneyViewModel MoneyViewModel { get; }

        public CategoriesViewModel(MoneyViewModel moneyViewModel)
        {
            MoneyViewModel = moneyViewModel;
        }
    }
}
