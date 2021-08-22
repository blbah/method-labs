using System;
using System.Collections.Generic;
using System.Text;

namespace EliteRestraurantEntity
{
    public class OrderEntity : BaseEntity<int>
    {
        public virtual List<DishEntity> DishList { get; set; }
    }
}
