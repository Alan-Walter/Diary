using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Diary.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<TodoTag> TodoTags { get; set; }

        public Tag()
        {
            TodoTags = new List<TodoTag>();
        }
    }

    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Title).IsRequired(true);
        }
    }
}
