using Diary.Models.Database;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace Diary.Models
{
    public class ApplicationContext : DbContext
    {
        private const string DBFileName = "diaryapp.db";

        public DbSet<Money> Moneys { get; set; }

        public DbSet<DiaryTask> DiaryTasks { get; set; } 

        public ApplicationContext()
        {
            // Создаем бд, если она отсутствует
            //this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IDatabasePath>().GetDatabasePath(DBFileName);
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DiaryTaskConfiguration());
            modelBuilder.ApplyConfiguration(new MoneyConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
