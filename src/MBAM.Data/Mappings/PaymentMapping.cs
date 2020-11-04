using MBAM.Business.Models.Payment;
using MBAM.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MBAM.Data.Mappings
{
    public class PaymentMapping : EntityTypeConfiguration<Payment>
    {
        public override void Map(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("varchar(2000)");

            builder.Property(p => p.Type)
                .IsRequired()
                .HasColumnType("varchar(7)");

            builder.ToTable("Payments");
        }
    }
}
