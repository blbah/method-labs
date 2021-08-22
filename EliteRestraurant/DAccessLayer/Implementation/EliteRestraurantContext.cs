using EliteRestraurantEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAccessLayer.Implementation
{
    public class EliteRestraurantContext : DbContext
    {
        public EliteRestraurantContext() : base("EliteBD") //{ }
        {
            //db seed
            if (DishTypes.Count() == 0)
            {
                DishTypes.Add(new DishTypeEntity() { Name = "Beverage" });
                DishTypes.Add(new DishTypeEntity() { Name = "Salad" });
                SaveChanges();
            }
            if (Menus.Count() == 0)
            {
                var menu = Menus.Add(new MenuEntity());
                var d1 = Dishes.Add(new DishEntity() { Name = "Coca-Cola", PreparingTime = TimeSpan.FromMinutes(1), DishTypeId = 1, Menus = new List<MenuEntity> {menu} });
                var d2 = Dishes.Add(new DishEntity() { Name = "Capuccino", PreparingTime = TimeSpan.FromMinutes(5), DishTypeId = 1, Menus = new List<MenuEntity> { menu } });
                var d3 = Dishes.Add(new DishEntity() { Name = "Red Bull", PreparingTime = TimeSpan.FromMinutes(3), DishTypeId = 1, Menus = new List<MenuEntity> { menu } });
                var d4 = Dishes.Add(new DishEntity() { Name = "Ceasar", PreparingTime = TimeSpan.FromMinutes(5), DishTypeId = 2, Menus = new List<MenuEntity> { menu } });
                var d5 = Dishes.Add(new DishEntity() { Name = "Greece", PreparingTime = TimeSpan.FromMinutes(5), DishTypeId = 2, Menus = new List<MenuEntity> { menu } });

                menu.DishList = new List<DishEntity>() { d1, d2, d3, d4, d5 };
                SaveChanges();
            }
            if (Specializations.Count() == 0)
            {
                var spec1 = Specializations.Add(new SpecializationEntity() 
                { 
                    Name = "Barman", 
                    DishTypes = new List<DishTypeEntity>() { DishTypes.First(dt => dt.Name == "Beverage") },
                    Cooks = new List<CookEntity> { }
                });
                var spec2 = Specializations.Add(new SpecializationEntity()
                {
                    Name = "Salad Chief",
                    DishTypes = new List<DishTypeEntity>() { DishTypes.First(dt => dt.Name == "Salad") },
                    Cooks = new List<CookEntity> { }
                });
                SaveChanges();

            }
            if (Cooks.Count() == 0)
            {
                var c1 = Cooks.Add(new CookEntity() { SpecializationId = 1, FinishTime = DateTime.Now });
                var c2 = Cooks.Add(new CookEntity() { SpecializationId = 1, FinishTime = DateTime.Now });
                var c3 = Cooks.Add(new CookEntity() { SpecializationId = 1, FinishTime = DateTime.Now });
                var c4 = Cooks.Add(new CookEntity() { SpecializationId = 1, FinishTime = DateTime.Now });
                var c5 = Cooks.Add(new CookEntity() { SpecializationId = 1, FinishTime = DateTime.Now });
                var c6 = Cooks.Add(new CookEntity() { SpecializationId = 2, FinishTime = DateTime.Now });
                var c7 = Cooks.Add(new CookEntity() { SpecializationId = 2, FinishTime = DateTime.Now });
                var c8 = Cooks.Add(new CookEntity() { SpecializationId = 2, FinishTime = DateTime.Now });
                SaveChanges();
            }
        }
        public DbSet<CookEntity> Cooks { get; set; }
        public DbSet<DishTypeEntity> DishTypes { get; set; }
        public DbSet<DishEntity> Dishes { get; set; }
        public DbSet<MenuEntity> Menus { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<SpecializationEntity> Specializations { get; set; }
    }
}
