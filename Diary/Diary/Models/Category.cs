using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Diary.Models
{
    /// <summary>
    /// Модель сущности категории
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заголовок категории
        /// </summary>
        public string Title { get; set; }

        public List<Money> Moneys { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }

    /// <summary>
    /// Конфигуратор модели
    /// </summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Title).IsRequired(true);
            builder.HasData(
                new Category() { Id = 1, Title = "Transport" },
                new Category() { Id = 2, Title = "Food" },
                new Category() { Id = 3, Title = "Games"},
                new Category() { Id = 4, Title = "House" },
                new Category() { Id = 5, Title = "Clothes" },
                new Category() { Id = 6, Title = "Communications" },
                new Category() { Id = 7, Title = "Health" },
                new Category() { Id = 8, Title = "Sports" },
                new Category() { Id = 9, Title = "PayDay"}
            );
        }
    }
}
