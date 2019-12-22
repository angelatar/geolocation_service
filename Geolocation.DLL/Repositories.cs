using Geolocation.Main.Entities;
using Geolocation.Main.Interfaces;
using Geolocation.Main.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;

namespace Geolocation.DAL
{
    public class LocationRepository : EntityBaseRepository<Location>, ILocationRepository
    {
        private readonly GeoContext _geoContext;
        public LocationRepository(GeoContext geoContext) : base(geoContext)
        {
            _geoContext = geoContext;
        }

        public LocationModel GetData(string ipAddress)
        {
            var location = (from loc in _geoContext.Locations
                            join block in _geoContext.Blocks on loc.GeonameId equals block.GeonameId into gr
                            from block in gr.DefaultIfEmpty()
                            where EF.Functions.ContainsOrEqual(block.Network, IPAddress.Parse(ipAddress))
                            select new LocationModel
                            {
                                Country = loc.CountryName,
                                Continent = loc.ContinentName,
                                RegisteredCountry = _geoContext.Locations.Where(x => x.GeonameId == block.RegisteredCountryGeonameId).Select(x => x.CountryName).FirstOrDefault(),
                                RepresentedCountry = _geoContext.Locations.Where(x => x.GeonameId == block.RepresentedCountryGeonameId).Select(x => x.CountryName).FirstOrDefault(),
                                Network = block.Network
                            }).FirstOrDefault();

            return location;
        }
    }

    public class BlockRepository : EntityBaseRepository<Block>, IBlockRepository
    {
        public BlockRepository(GeoContext geoContext) : base(geoContext)
        {
        }
    }
}
