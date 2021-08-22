using DAccessLayer.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstract;
using Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public static class DependencyRegistrator
    {
        public static void RegisterBLL(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<EliteRestraurantContext>();
            serviceCollection.AddScoped<IDishService, DishService>();
            serviceCollection.AddScoped<IDishTypeService, DishTypeService>();
            serviceCollection.AddScoped<IMenuService, MenuService>();
            serviceCollection.AddScoped<IOrderService, OrderService>();
        }
    }
}
