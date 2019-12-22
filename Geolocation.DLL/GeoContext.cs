using Geolocation.Main.Entities;
using Microsoft.EntityFrameworkCore;

namespace Geolocation.DAL
{
    public class GeoContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Block> Blocks { get; set; }

        public GeoContext()
        { }

        public GeoContext(DbContextOptions<GeoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BlockConfiguration());
            builder.ApplyConfiguration(new LocationConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
