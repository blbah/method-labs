using System;
using System.Collections.Generic;
using System.Text;

namespace EliteRestraurantEntity
{
    public class SpecializationEntity : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<DishTypeEntity> DishTypes { get; set; }
        public virtual List<CookEntity> Cooks { get; set; }
    }
}
