using EliteRestraurantEntity;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EliteRestraurantMappers
{
    public static class SpecializationMapper
    {
        public static SpecializationEntity toEntity(this Specialization model)
        {
            List<DishTypeEntity> DishTypes = new List<DishTypeEntity>();
            model.DishTypes?.ForEach(i => DishTypes.Add(i.toEntity()));
            return new SpecializationEntity { DishTypes = DishTypes, Name = model.Name, Id = model.Id };
        }

        public static Specialization toModel(this SpecializationEntity entity)
        {
            List<DishType> DishTypes = new List<DishType>();
            entity.DishTypes?.ForEach(i => DishTypes.Add(i.toModel()));
            return new Specialization { DishTypes = DishTypes, Name = entity.Name, Id = entity.Id };
        }
    }
}
