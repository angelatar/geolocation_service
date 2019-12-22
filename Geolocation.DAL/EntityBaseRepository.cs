using Geolocation.Main.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geolocation.DAL
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, new()
    {
        protected readonly GeoContext _geoContext;
        public EntityBaseRepository(GeoContext geoContext)
        {
            _geoContext = geoContext;
        }

        public void Commit()
        {
            _geoContext.SaveChanges();
        }

        public virtual int ExecuteSqlQuery(string query)
        {
            return _geoContext.Database.ExecuteSqlRaw(query);
        }
    }
}
