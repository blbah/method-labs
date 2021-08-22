using EliteRestraurantEntity;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EliteRestraurantMappers
{
    public static class DishTypeMapper
    {
        public static DishTypeEntity toEntity(this DishType model)
        {
            return new DishTypeEntity { Name = model.Name, Id = model.Id };
        }

        public static DishType toModel(this DishTypeEntity entity)
        {
            return new DishType { Name = entity.Name, Id = entity.Id };
        }
    }
}
