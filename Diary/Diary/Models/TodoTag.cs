using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Models
{
    public class TodoTag
    {
        public Todo Todo { get; set; }
        public int TodoId { get; set; }

        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }

    public class TodoTagConfiguration : IEntityTypeConfiguration<TodoTag>
    {
        public void Configure(EntityTypeBuilder<TodoTag> builder)
        {
            builder.HasKey(i => new { i.TodoId, i.TagId } );

            builder.HasOne(i => i.Tag)
            .WithMany(s => s.TodoTags)
            .HasForeignKey(i => i.TagId);

            builder.HasOne(i => i.Todo)
            .WithMany(s => s.TodoTags)
            .HasForeignKey(i => i.TodoId);
        }
    }
}
