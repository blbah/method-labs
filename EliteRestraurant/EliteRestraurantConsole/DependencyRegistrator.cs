using EliteRestraurantConsole.UI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteRestraurantConsole
{
    static class DependencyRegistrator
    {
        public static void RegisterPL(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<CLI>();
        }
    }
}
