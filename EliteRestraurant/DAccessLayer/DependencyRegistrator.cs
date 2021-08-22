using DAccessLayer.Abstract;
using DAccessLayer.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAccessLayer
{
    public static class DependencyRegistrator
    {
        public static void RegisterDAL(this ServiceCollection serviceCollection) 
        {
            serviceCollection.AddScoped<EliteRestraurantContext>();
            serviceCollection.AddScoped<ICookRepository, CookRepository>();
            serviceCollection.AddScoped<IDishRepository, DishRepository>();
            serviceCollection.AddScoped<IDishTypeRepository, DishTypeRepository>();
            serviceCollection.AddScoped<IMenuRepository, MenuRepository>();
            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
            serviceCollection.AddScoped<ISpecializationRepository, SpecializationRepository>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
