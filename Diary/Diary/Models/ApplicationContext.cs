using Diary.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Diary.Models
{
    public class ApplicationContext : DbContext
    {
        private readonly string databasePath;

        public DbSet<Money> Moneys { get; set; }

        public DbSet<DiaryTask> DiaryTasks { get; set; } 

        public ApplicationContext(string databasePath)
        {
            this.databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DiaryTaskConfiguration());
            modelBuilder.ApplyConfiguration(new MoneyConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
