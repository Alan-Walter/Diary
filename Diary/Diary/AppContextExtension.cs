using Microsoft.EntityFrameworkCore;

namespace Diary
{
    public static class AppContextExtension
    {
        public static bool IsItNew(this ApplicationContext context, object entity) => !context.Entry(entity).IsKeySet;

        public static void Reset<T>(this ApplicationContext context, T item)
        {
            context.Entry(item).State = EntityState.Unchanged;
        }
    }
}
