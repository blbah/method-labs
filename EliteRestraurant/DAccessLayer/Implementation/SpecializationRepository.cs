using DAccessLayer.Abstract;
using EliteRestraurantEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAccessLayer.Implementation
{
    public class SpecializationRepository : GenericRepository<SpecializationEntity, int>, ISpecializationRepository
    {
        public SpecializationRepository(EliteRestraurantContext context) : base(context)
        {
        }
    }
}
