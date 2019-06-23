using Diary.Models;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace Diary
{
    public class ApplicationContext : DbContext
    {
        private const string DBFileName = "diaryapp.db";

        public DbSet<Money> Moneys { get; set; }

        public DbSet<Todo> Todos { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public ApplicationContext()
        {
            // Создаем бд, если она отсутствует
            //this.Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IDatabasePath>().GetDatabasePath(DBFileName);
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoConfiguration());
            modelBuilder.ApplyConfiguration(new MoneyConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new TodoTagConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
