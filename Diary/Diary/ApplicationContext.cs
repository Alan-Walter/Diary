using Diary.Models;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace Diary
{
    /// <summary>
    /// База данных
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Имя файла
        /// </summary>
        private const string DBFileName = "diaryapp.db";

        /// <summary>
        /// Множество объектов Money
        /// </summary>
        public DbSet<Money> Moneys { get; set; }

        /// <summary>
        /// Множество объектов Todo
        /// </summary>
        public DbSet<Todo> Todos { get; set; }

        /// <summary>
        /// Множество категорий
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        public ApplicationContext()
        {
            // Создаем бд, если она отсутствует
            Database.EnsureCreated();
        }

        /// <summary>
        /// Конфигурация базы данных
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IDatabasePath>().GetDatabasePath(DBFileName);
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

        /// <summary>
        /// Создание модели базы данных
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoConfiguration());
            modelBuilder.ApplyConfiguration(new MoneyConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
