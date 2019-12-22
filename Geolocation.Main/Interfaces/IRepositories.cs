using Geolocation.Main.Entities;
using Geolocation.Main.Models;

namespace Geolocation.Main.Interfaces
{
    public interface ILocationRepository : IEntityBaseRepository<Location>
    {
        LocationModel GetData(string ipAddress);
    }

    public interface IBlockRepository : IEntityBaseRepository<Block>
    {
    }
}
