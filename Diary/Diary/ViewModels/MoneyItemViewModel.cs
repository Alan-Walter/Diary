using Diary.Models;
using System;

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

        public int Value
        {
            get { return Money.Value; }
            set
            {
                if (value == Value) return;
                Money.Value = value;
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

        public MoneyItemViewModel(Money money, MoneyHistoryViewModel moneyHistoryViewModel)
        {
            Money = money;
            MoneyHistoryViewModel = moneyHistoryViewModel;
        }
    }
}
