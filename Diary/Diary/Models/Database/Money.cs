using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Models.Database
{
    public class Money
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }

    public class MoneyConfiguration : IEntityTypeConfiguration<Money>
    {
        public void Configure(EntityTypeBuilder<Money> builder)
        {
            builder.HasKey(i => i.Id);
        }
    }
}
