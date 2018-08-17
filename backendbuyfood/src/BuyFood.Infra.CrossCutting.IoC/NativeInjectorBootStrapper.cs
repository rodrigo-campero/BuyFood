using BuyFood.Domain.Interfaces;
using BuyFood.Domain.Interfaces.Repositories;
using BuyFood.Domain.Interfaces.Services;
using BuyFood.Domain.Services;
using BuyFood.Infra.Data.Context;
using BuyFood.Infra.Data.Repositories;
using BuyFood.Infra.Data.UoW;
//using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
namespace BuyFood.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Application
            //services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IDishService, DishService>();


            // Infra - Data
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IDishRepository, DishRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MainContext>();
        }
    }
}
