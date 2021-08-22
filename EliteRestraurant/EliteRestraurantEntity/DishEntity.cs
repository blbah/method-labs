using System;
using System.Collections.Generic;
using System.Text;

namespace EliteRestraurantEntity
{
    public class DishEntity : BaseEntity<int>
    {
        public string Name { get; set; }
        public TimeSpan PreparingTime { get; set; }
        public virtual DishTypeEntity DishType { get; set; }
        public int DishTypeId { get; set; }
        public virtual List<MenuEntity> Menus { get; set; }
        public virtual List<OrderEntity> Orders { get; set; }
    }
}
