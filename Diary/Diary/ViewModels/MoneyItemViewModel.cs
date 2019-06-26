using Diary.Models;
using System;

namespace Diary.ViewModels
{
    public class MoneyItemViewModel : SimpleViewModel
    {
        /// <summary>
        /// Объект базы данных
        /// </summary>
        public Money Money { get; private set; }

        /// <summary>
        /// Вью модель всех денег
        /// </summary>
        public MoneyViewModel MoneyViewModel { get; }

        /// <summary>
        /// Описание
        /// </summary>
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

        /// <summary>
        /// Значение
        /// </summary>
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

        /// <summary>
        /// Категория
        /// </summary>
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

        /// <summary>
        /// Информация о деньгах
        /// </summary>
        public string Info => !string.IsNullOrEmpty(Category?.Title) && !string.IsNullOrEmpty(Description) ?
            $"{Category.Title} • {Description}" : $"{Category?.Title}{Description}";

        /// <summary>
        /// Дата и время
        /// </summary>
        public DateTime Date => Money.Date;

        public MoneyItemViewModel(Money money, MoneyViewModel moneyViewModel)
        {
            Money = money;
            MoneyViewModel = moneyViewModel;
        }
    }
}
