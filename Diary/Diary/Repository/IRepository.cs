using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diary.Repository
{
    /// <summary>
    /// Интерфейс репозитория для работы с БД
    /// </summary>
    /// <typeparam name="T">Объект модели</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Асинхронное получение всех объектов
        /// </summary>
        /// <returns>Список объектов модели</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Асинхронное получение объекта по его ID
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Объект модели</returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// Асинхронное создание в базе данных нового объекта
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task CreateAsync(T item);

        /// <summary>
        /// Асинхронное обновление объекта в базе данных
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task UpdateAsync(T item);

        /// <summary>
        /// Асинхронное удаление объекта из базы данных по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Асинхронное удаление объекта из базы данных
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task DeleteAsync(T item);
    }
}
