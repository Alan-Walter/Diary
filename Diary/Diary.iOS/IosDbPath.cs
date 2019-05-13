using System;
using Xamarin.Forms;
using System.IO;
using Diary.iOS;

[assembly: Dependency(typeof(IosDbPath))]
namespace Diary.iOS
{
    public class IosDbPath : IPath
    {
        public string GetDatabasePath(string sqliteFilename)
        {
            // определяем путь к бд
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", sqliteFilename);
        }
    }
}