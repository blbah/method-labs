using DAccessLayer.Abstract;
using EliteRestraurantEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAccessLayer.Implementation
{
    public class DishTypeRepository : GenericRepository<DishTypeEntity, int>, IDishTypeRepository
    {
        public DishTypeRepository(EliteRestraurantContext context) : base(context)
        {
        }
    }
}
