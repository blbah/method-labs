using DAccessLayer.Abstract;
using EliteRestraurantEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAccessLayer.Implementation
{
    public class CookRepository : GenericRepository<CookEntity, int>, ICookRepository
    {
        public CookRepository(EliteRestraurantContext context) : base(context) { }

        public List<CookEntity> GetByDishType(int dishTypeId, int cookAmount)
        {
            return context.Cooks.Where(i => i.Specialization.DishTypes.Any(dt => dt.Id == dishTypeId))
                .OrderByDescending(i => i.FinishTime)
                .Take(cookAmount)
                .ToList();
        }
    }
}
