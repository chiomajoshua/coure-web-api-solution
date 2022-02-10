using CoureWebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoureWebAPI.Data.Configurations
{
    public class CountryMapping : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(b => b.CountryCode)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(b => b.CountryIso)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.HasMany(b => b.CountryDetails)
                .WithOne(b => b.Country)
                .HasForeignKey(b => b.CountryId);

            builder.ToTable("Country");
        }
    }
}