using Geolocation.DAL;
using Geolocation.Main.Functionality;
using Geolocation.Main.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Geolocation.API
{
    public static class DependancyConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            foreach (var item in Functionalities)
            {
                services.Add(new ServiceDescriptor(item.Key, item.Value, ServiceLifetime.Transient));
            }

            foreach (var item in Repositories)
            {
                services.Add(new ServiceDescriptor(item.Key, item.Value, ServiceLifetime.Transient));
            }
        }
        private static readonly Dictionary<Type, Type> Repositories = new Dictionary<Type, Type>
        {
            {typeof(ILocationRepository),typeof(LocationRepository)},
            {typeof(IBlockRepository), typeof(BlockRepository)}
        };

        private static readonly Dictionary<Type, Type> Functionalities = new Dictionary<Type, Type>
        {
            {typeof(IDataUser), typeof(DataUser)},
            {typeof(IRepositoryManager), typeof(RepositoryManager)}
        };
    }
}
