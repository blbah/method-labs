using EliteRestraurantEntity;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EliteRestraurantMappers
{
    public static class MenuMapper
    {
        public static MenuEntity toEntity(this Menu model)
        {
            List<DishEntity> Dishes = new List<DishEntity>();
            model.DishList.ForEach(i => Dishes.Add(i.toEntity()));
            return new MenuEntity { DishList = Dishes, Id = model.Id };
        }

        public static Menu toModel(this MenuEntity entity)
        {
            List<Dish> Dishes = new List<Dish>();
            entity.DishList.ForEach(i => Dishes.Add(i.toModel()));
            return new Menu { DishList = Dishes, Id = entity.Id };
        }
    }
}
