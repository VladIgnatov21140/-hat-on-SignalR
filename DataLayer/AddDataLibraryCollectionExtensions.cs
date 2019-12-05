using DataLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer
{
    /// <summary>
    /// Class for adding data layer services dependency injection
    /// </summary>
    public static class AddDataLibraryCollectionExtensions
    {
        /// <summary>
        /// Method for adding data layer services dependency injection
        /// </summary>
        /// <param name="service">App services</param>
        public static IServiceCollection AddDataLibraryCollection(this IServiceCollection service, string connectionString = "ConnectionString")
        {
            service.AddTransient<IDataServices, DataServices>(provider => new DataServices(connectionString));
            return service;
        }

    }
}
