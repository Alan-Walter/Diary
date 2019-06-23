using Diary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Repository
{
    class TagRepository : IRepository<Tag>
    {
        public async Task CreateAsync(Tag item)
        {
            App.Database.Tags.Add(item);
            await App.Database.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetAsync(id).ConfigureAwait(false);
            await DeleteAsync(item).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Tag item)
        {
            App.Database.Tags.Remove(item);
            await App.Database.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            var items = await App.Database.Tags.ToListAsync().ConfigureAwait(false);
            return items;
        }

        public async Task<Tag> GetAsync(int id)
        {
            var item = await App.Database.Tags.Where(i => i.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            return item;
        }

        public async Task UpdateAsync(Tag item)
        {
            App.Database.Tags.Update(item);
            await App.Database.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
