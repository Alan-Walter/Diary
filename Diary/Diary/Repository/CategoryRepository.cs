using Diary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Repository
{
    class CategoryRepository : IRepository<Category>
    {
        public Task CreateAsync(Category item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Category item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
