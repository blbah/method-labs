using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EliteRestraurantEntity
{
    public class DishTypeEntity : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<SpecializationEntity> Specializations { get; set; }
    }
}
