using DAccessLayer.Abstract;
using EliteRestraurantEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAccessLayer.Implementation
{
    public class DishRepository : GenericRepository<DishEntity, int>, IDishRepository
    {
        public DishRepository(EliteRestraurantContext context) : base(context)
        {
        }
    }
}
