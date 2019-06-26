using Microsoft.EntityFrameworkCore;

namespace Diary
{
    /// <summary>
    /// Расширение класса ApplicationContext
    /// </summary>
    public static class AppContextExtension
    {
        /// <summary>
        /// Проверка существования объекта в базе данных
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool IsItNew(this ApplicationContext context, object entity) => !context.Entry(entity).IsKeySet;

        /// <summary>
        /// Сброс объекта базы данных
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="item"></param>
        public static void Reset<T>(this ApplicationContext context, T item)
        {
            context.Entry(item).State = EntityState.Unchanged;
        }
    }
}
