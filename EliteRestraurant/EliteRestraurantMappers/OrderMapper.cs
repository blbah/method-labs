using EliteRestraurantEntity;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EliteRestraurantMappers
{
    public static class OrderMapper
    {
        public static OrderEntity toEntity(this Order model)
        {
            List<DishEntity> Dishes = new List<DishEntity>();
            model.DishList.ForEach(i => Dishes.Add(i.toEntity()));
            return new OrderEntity { DishList = Dishes, Id = model.Id };
        }

        public static Order toModel(this OrderEntity entity)
        {
            List<Dish> Dishes = new List<Dish>();
            entity.DishList.ForEach(i => Dishes.Add(i.toModel()));
            return new Order { DishList = Dishes, Id = entity.Id };
        }
    }
}
