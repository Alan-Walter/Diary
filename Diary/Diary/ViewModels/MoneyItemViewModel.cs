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
                RaisePropertyChanged("Info");
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
                MoneyViewModel.SaveMoneyCommand.ChangeCanExecute();
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
                RaisePropertyChanged("Info");
            }
        }

        public string Info => !string.IsNullOrEmpty(Category?.Title) && !string.IsNullOrEmpty(Description) ?
            $"{Category.Title} • {Description}" : $"{Category?.Title}{Description}";

        public DateTime Date => Money.Date;

        public MoneyItemViewModel(Money money, MoneyViewModel moneyViewModel)
        {
            Money = money;
            MoneyViewModel = moneyViewModel;
        }
    }
}
