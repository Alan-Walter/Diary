using Diary.Models;
using Diary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.ViewModels
{
    class MoneyHistoryViewModel : SimpleViewModel
    {
        readonly IRepository<Money> repository;

    }
}
