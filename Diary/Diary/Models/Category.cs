using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Diary.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Money> Moneys { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Title).IsRequired(true);
            builder.HasData(
                new Category() { Id = 1, Title= "Public Transport" },
                new Category() { Id = 2, Title = "Food" },
                new Category() { Id = 3, Title = "Games"}
            );
        }
    }
}
