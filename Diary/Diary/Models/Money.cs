using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Diary.Models
{
    /// <summary>
    /// Модель сущности денег
    /// </summary>
    public class Money
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Категория
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Дата и время
        /// </summary>
        public DateTime Date { get; set; }
    }

    /// <summary>
    /// Конфигуратор
    /// </summary>
    public class MoneyConfiguration : IEntityTypeConfiguration<Money>
    {
        public void Configure(EntityTypeBuilder<Money> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Date).HasDefaultValueSql("datetime('now')").ValueGeneratedOnAdd();
        }
    }
}
