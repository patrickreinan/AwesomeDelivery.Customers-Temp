using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeDelivery.Customers.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeDelivery.Customers.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            services
                .AddApplicationServices();

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}