using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Services
{
    public interface IDataStore<T>
    {
        Task<List<T>> GetItemsAsync();

        Task<List<T>> GetItemsNotDoneAsync();

        Task<T> GetItemAsync(int id);

        Task<bool> SaveItemAsync(T item);

        Task<bool> DeleteItemAsync(T item);
    }
}
