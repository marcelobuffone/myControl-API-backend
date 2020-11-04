using MBAM.Business.Models.Archive;
using MBAM.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MBAM.Data.Mappings
{
    public class ArchiveMapping : EntityTypeConfiguration<Archive>
    {
        public override void Map(EntityTypeBuilder<Archive> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Path)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Archives");
        }
    }
}
