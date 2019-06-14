using Diary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Repository
{
    class CategoryRepository : IRepository<Category>
    {
        public async Task CreateAsync(Category item)
        {
            App.Database.Categories.Add(item);
            await App.Database.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(int id)
        {
            var cat = await GetAsync(id).ConfigureAwait(false);
            await DeleteAsync(cat).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Category item)
        {
            App.Database.Categories.Remove(item);
            await App.Database.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var res = await App.Database.Categories.ToListAsync().ConfigureAwait(false);
            return res;
        }

        public async Task<Category> GetAsync(int id)
        {
            var item = await App.Database.Categories.Where(i => i.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            return item;
        }

        public async Task UpdateAsync(Category item)
        {
            App.Database.Categories.Update(item);
            await App.Database.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
