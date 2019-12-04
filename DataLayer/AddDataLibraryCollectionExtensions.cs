using DataLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace DataLayer
{
    public static class AddDataLibraryCollectionExtensions
    {
        public static IServiceCollection AddDataLibraryCollection(this IServiceCollection service, string connectionString = "ConnectionString")
        {
            service.AddTransient<IDataServices, DataServices>(provider => new DataServices());//connectionString
            return service;
        }

    }
}
