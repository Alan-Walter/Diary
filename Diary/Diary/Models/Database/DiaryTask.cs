using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diary.Models.Database
{
    public class DiaryTask
    {
        public int Id { get; set; }

        public string Headline { get; set; }

        public string Description { get; set; }

        public bool IsComplete { get; set; }
    }

    public class DiaryTaskConfiguration : IEntityTypeConfiguration<DiaryTask>
    {
        public void Configure(EntityTypeBuilder<DiaryTask> builder)
        {
            builder.HasKey(i => i.Id);
        }
    }
}
