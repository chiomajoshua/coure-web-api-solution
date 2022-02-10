using CoureWebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoureWebAPI.Data.Configurations
{
    public class CountryDetailsMapping : IEntityTypeConfiguration<CountryDetails>
    {
        public void Configure(EntityTypeBuilder<CountryDetails> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CountryId)
                .IsRequired();

            builder.Property(x => x.OperatorCode)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Operator)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("CountryDetails");
        }
    }
}