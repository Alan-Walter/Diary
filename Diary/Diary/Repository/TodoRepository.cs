using Diary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Repository
{
    class TodoRepository : IRepository<Todo>
    {
        readonly ApplicationContext dbContext;

        public TodoRepository()
        {
            dbContext = App.Database;
        }

        public async Task CreateAsync(Todo item)
        {
            dbContext.Todos.Add(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var todo = await GetAsync(id);
            if (todo == null) return;
            dbContext.Todos.Remove(todo);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Todo item)
        {
            dbContext.Todos.Remove(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Todo> GetAsync(int id)
        {
            var todo = await dbContext.Todos.Where(i => i.Id == id).FirstOrDefaultAsync();
            return todo;
        }

        public async Task<IEnumerable<Todo>> GetListAsync()
        {
            var list = await dbContext.Todos.ToListAsync();
            return list;
        }

        public async Task UpdateAsync(Todo item)
        {
            dbContext.Todos.Update(item);
            await dbContext.SaveChangesAsync();
        }
    }
}
