using Diary.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Models
{
    public class ApplicationContext : DbContext
    {
        private readonly string databasePath;

        public DbSet<Money> Moneys { get; set; }

        public ApplicationContext(string databasePath)
        {
            this.databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }
    }
}
