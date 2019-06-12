using Diary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Repository
{
    class MoneyRepository : IRepository<Money>
    {
        readonly ApplicationContext dbContext;

        public MoneyRepository()
        {
            dbContext = App.Database;
        }


        public async Task CreateAsync(Money item)
        {
            dbContext.Moneys.Add(item);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetAsync(id).ConfigureAwait(false);
            if (item == null) return;
            await DeleteAsync(item).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Money item)
        {
            dbContext.Remove(item);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Money>> GetAllAsync()
        {
            var moneys = await dbContext.Moneys.Select(i => i).Include(j => j.Category).ToListAsync().ConfigureAwait(false);
            return moneys;
        }

        public async Task<Money> GetAsync(int id)
        {
            var item = await dbContext.Moneys.Where(i => i.Id == id).Include(j => j.Category).FirstOrDefaultAsync().ConfigureAwait(false);
            return item;
        }

        public async Task UpdateAsync(Money item)
        {
            dbContext.Update(item);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
