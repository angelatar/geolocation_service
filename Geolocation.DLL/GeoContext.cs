using Microsoft.EntityFrameworkCore;

namespace Geolocation.DAL
{
    public class GeoContext : DbContext
    {
        public DbSet<MaxMind.GeoIP2.Model.Country> Countries { get; set; }

        public GeoContext(DbContextOptions<GeoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CountryConfiguration());
        }
    }
}
