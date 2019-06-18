using Diary.Models;
using System;

namespace Diary.ViewModels
{
    public class MoneyItemViewModel : SimpleViewModel
    {
        public Money Money { get; private set; }

        public MoneyViewModel MoneyViewModel { get; }

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

        public double Value
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

        public MoneyItemViewModel(Money money, MoneyViewModel moneyViewModel)
        {
            Money = money;
            MoneyViewModel = moneyViewModel;
        }
    }
}
