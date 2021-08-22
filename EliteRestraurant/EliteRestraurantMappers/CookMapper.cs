using EliteRestraurantEntity;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EliteRestraurantMappers
{
    public static class CookMapper
    {
        public static CookEntity toEntity(this Cook model)
        {
            return new CookEntity { FinishTime = model.FinishTime, SpecializationId = model.Specialization.Id, Id = model.Id };
        }

        public static Cook toModel(this CookEntity entity)
        {
            return new Cook { FinishTime = entity.FinishTime, Specialization = entity.Specialization.toModel(), Id = entity.Id };
        }
    }
}
