using DAccessLayer.Abstract;
using EliteRestraurantEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAccessLayer.Implementation
{
    public class MenuRepository : GenericRepository<MenuEntity, int>, IMenuRepository
    {
        public MenuRepository(EliteRestraurantContext context) : base(context)
        {
        }
    }
}
