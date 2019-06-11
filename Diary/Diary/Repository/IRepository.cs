using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(); // получение всех объектов
        Task<T> GetAsync(int id); // получение одного объекта по id
        Task CreateAsync(T item); // создание объекта
        Task UpdateAsync(T item); // обновление объекта
        Task DeleteAsync(int id); // удаление объекта по id
        Task DeleteAsync(T item);  //  удаление объекта
    }
}
