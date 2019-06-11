using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diary.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public bool Completed { get; set; }
    }

    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Title).IsRequired(true);
        }
    }
}
