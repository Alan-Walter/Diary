using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Models
{
    public interface IPath
    {
        string GetDatabasePath(string filename);
    }
}
