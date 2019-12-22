using Geolocation.Main.Interfaces;
using Geolocation.Main.Models;

namespace Geolocation.Main.Functionality
{
    public class DataUser : IDataUser
    {
        private readonly IRepositoryManager _repo;

        public DataUser(IRepositoryManager repo)
        {
            _repo = repo;
        }

        public LocationModel GetData(string ipAddress)
        {
            return _repo.Locations.GetData(ipAddress);
        }
    }
}
