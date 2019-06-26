using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diary.Models
{
    /// <summary>
    /// Модель Todo
    /// </summary>
    public class Todo
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Заметки, описание
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Выполнение задания
        /// </summary>
        public bool Completed { get; set; }
    }

    /// <summary>
    /// Конфигуратор
    /// </summary>
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Title).IsRequired(true);
        }
    }
}
