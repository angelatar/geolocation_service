using Geolocation.Main.Models;

namespace Geolocation.Main.Interfaces
{
    public interface IDataUser
    {
        LocationModel GetData(string ipAddress);
    }
}
