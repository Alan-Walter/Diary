using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Diary.Models
{
    public class Money
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public DateTime Date { get; set; }
    }

    public class MoneyConfiguration : IEntityTypeConfiguration<Money>
    {
        public void Configure(EntityTypeBuilder<Money> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Date).HasDefaultValueSql("getdate()").ValueGeneratedOnAdd();
            //builder.Property(i => i.Category).IsRequired();
        }
    }
}
