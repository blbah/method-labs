using System;
using System.Collections.Generic;
using System.Text;

namespace EliteRestraurantEntity
{
    public class CookEntity : BaseEntity<int>
    {
        public virtual SpecializationEntity Specialization { get; set; }
        public int SpecializationId { get; set; }
        public DateTime FinishTime { get; set; }
    }
}
