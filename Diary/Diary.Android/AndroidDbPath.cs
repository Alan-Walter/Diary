using System;
using Diary.Droid;
using System.IO;
using Xamarin.Forms;
using Diary.Models;

[assembly: Dependency(typeof(AndroidDbPath))]
namespace Diary.Droid
{
    class AndroidDbPath : IPath
    {
        public string GetDatabasePath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename);
        }
    }
}