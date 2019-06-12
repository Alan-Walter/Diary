using Diary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.ViewModels
{
    class MoneyItemViewModel : SimpleViewModel
    {
        public Money Money { get; private set; }

        public MoneyHistoryViewModel MoneyHistoryViewModel { get; }

        public string Description
        {
            get { return Money.Description; }
            set
            {
                if (value == Description) return;
                Money.Description = value;
                RaisePropertyChanged();
            }
        }

        public Category Category
        {
            get { return Money.Category; }
            set
            {
                if (value == Category) return;
                Money.Category = value;
                RaisePropertyChanged();
            }
        }

        public DateTime Date
        {
            get { return Money.Date; }
        }
    }
}
