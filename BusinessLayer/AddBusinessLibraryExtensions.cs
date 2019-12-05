using BusinessLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer
{
    /// <summary>
    /// Class for adding business layer services dependency injection
    /// </summary>
    public static class AddBusinessLibraryExtensions
    {
        /// <summary>
        /// Method for adding business layer services dependency injection
        /// </summary>
        /// <param name="service">App services</param>
        public static IServiceCollection AddBusinessLibraryCollection(this IServiceCollection service)
        {
            service.AddTransient<IBusinessServices, BusinessServices>();
            return service;
        }
    }
}
