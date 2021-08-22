using EliteRestraurantEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAccessLayer.Abstract
{
    public interface ICookRepository : IGenericRepository<CookEntity, int>
    {
        List<CookEntity> GetByDishType(int dishType, int cookAmount);
    }
}
