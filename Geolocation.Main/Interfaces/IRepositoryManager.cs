using System;
using System.Threading.Tasks;

namespace Geolocation.Main.Interfaces
{
    public interface IRepositoryManager : IDisposable
    {
        ILocationRepository Locations { get; }
        IBlockRepository Blocks { get; }

        int Complete();
        Task<int> CompleteAsync();
    }

}
