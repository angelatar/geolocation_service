using Geolocation.Main.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geolocation.DAL
{
    public class BlockConfiguration : IEntityTypeConfiguration<Block>
    {
        public void Configure(EntityTypeBuilder<Block> builder)
        {
            builder.ToTable("Blocks", "public");
            builder.HasNoKey();
        }
    }

    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations", "public");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Latitude).HasColumnType("numeric(6,4)");
            builder.Property(x => x.Longitude).HasColumnType("numeric(7,4)");
        }
    }
}
