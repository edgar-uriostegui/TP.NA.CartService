using Carter;
using CartService.Application.Abstractions.Repository;
using CartService.Application.Queries.Cart;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Application.Extensions
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddCarter();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }

        /// <summary>
        /// Method to configure AutoMapper
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigAutoMapper(this IServiceCollection builder)
        {
            builder.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
