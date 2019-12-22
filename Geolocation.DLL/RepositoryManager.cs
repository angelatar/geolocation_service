using Geolocation.Main.Interfaces;
using System;
using System.Threading.Tasks;

namespace Geolocation.DAL
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly GeoContext _context;

        public RepositoryManager(IServiceProvider serviceProvider, GeoContext context)
        {
            _serviceProvider = serviceProvider;
            _context = context;
        }

        private ILocationRepository _locations;
        public ILocationRepository Locations => _locations ?? (_locations = _serviceProvider.GetService(typeof(ILocationRepository)) as ILocationRepository);

        private IBlockRepository _blocks;
        public IBlockRepository Blocks => _blocks ?? (_blocks = _serviceProvider.GetService(typeof(IBlockRepository)) as IBlockRepository);

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
