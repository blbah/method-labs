using System;
using System.Collections.Generic;
using System.Text;

namespace EliteRestraurantEntity
{
    public class MenuEntity : BaseEntity<int>
    {
        public virtual List<DishEntity> DishList { get; set; }
    }
}
