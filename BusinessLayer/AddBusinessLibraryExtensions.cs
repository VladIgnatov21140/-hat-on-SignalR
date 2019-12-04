using BusinessLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public static class AddBusinessLibraryExtensions
    {
        public static IServiceCollection AddBusinessLibraryCollection(this IServiceCollection service)
        {
            service.AddTransient<IBusinessServices, BusinessServices>();
            return service;
        }
    }
}
