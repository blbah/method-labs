using DAccessLayer;
using EliteRestraurantConsole.UI;
using Microsoft.Extensions.DependencyInjection;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteRestraurantConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.RegisterDAL();
            serviceCollection.RegisterBLL();
            serviceCollection.RegisterPL();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetRequiredService<CLI>().Run();
        }
    }
}
