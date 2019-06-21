using Diary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Repository
{
    class MoneyRepository : IRepository<Money>
    {
        public async Task CreateAsync(Money item)
        {
            App.Database.Moneys.Add(item);
            await App.Database.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetAsync(id).ConfigureAwait(false);
            if (item == null) return;
            await DeleteAsync(item).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Money item)
        {
            App.Database.Remove(item);
            await App.Database.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Money>> GetAllAsync()
        {
            var moneys = await App.Database.Moneys.Select(i => i).Include(j => j.Category).ToListAsync().ConfigureAwait(false);
            return moneys;
        }

        public async Task<Money> GetAsync(int id)
        {
            var item = await App.Database.Moneys.Where(i => i.Id == id).Include(j => j.Category).FirstOrDefaultAsync().ConfigureAwait(false);
            return item;
        }

        public async Task UpdateAsync(Money item)
        {
            App.Database.Update(item);
            await App.Database.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
