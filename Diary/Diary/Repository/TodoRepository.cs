using Diary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Repository
{
    /// <summary>
    /// Репозиторий Todo
    /// </summary>
    class TodoRepository : IRepository<Todo>
    {
        public async Task CreateAsync(Todo item)
        {
            App.Database.Todos.Add(item);
            await App.Database.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(int id)
        {
            var todo = await GetAsync(id).ConfigureAwait(false);
            if (todo == null) return;
            await DeleteAsync(todo).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Todo item)
        {
            App.Database.Todos.Remove(item);
            await App.Database.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<Todo> GetAsync(int id)
        {
            var todo = await App.Database.Todos.Where(i => i.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            return todo;
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            var list = await App.Database.Todos.ToListAsync().ConfigureAwait(false);
            return list;
        }

        public async Task UpdateAsync(Todo item)
        {
            App.Database.Todos.Update(item);
            await App.Database.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
