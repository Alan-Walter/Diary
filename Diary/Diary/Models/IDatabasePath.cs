using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Models
{
    public interface IDatabasePath
    {
        string GetDatabasePath(string filename);
    }
}
