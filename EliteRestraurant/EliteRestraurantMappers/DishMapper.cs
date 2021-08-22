using EliteRestraurantEntity;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EliteRestraurantMappers
{
    public static class DishMapper
    {
        public static DishEntity toEntity(this Dish model)
        {
            return new DishEntity { Name = model.Name, PreparingTime = model.PreparingTime, Id = model.Id, DishType = model.DishType.toEntity()};
        }

        public static Dish toModel(this DishEntity entity)
        {
            return new Dish { Name = entity.Name, PreparingTime = entity.PreparingTime, Id = entity.Id, DishType = entity.DishType.toModel() };
        }
    }
}
