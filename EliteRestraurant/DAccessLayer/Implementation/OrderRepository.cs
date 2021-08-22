using DAccessLayer.Abstract;
using EliteRestraurantEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAccessLayer.Implementation
{
    public class OrderRepository : GenericRepository<OrderEntity, int>, IOrderRepository
    {
        public OrderRepository(EliteRestraurantContext context) : base(context)
        {
        }
        ///hui
        public override void Add(OrderEntity order)
        {
            order.DishList = order.DishList.Select(dish => context.Dishes.Find(dish.Id)).ToList();
            context.Orders.Add(order);
        }
    }
}
