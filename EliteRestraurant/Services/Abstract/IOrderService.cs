using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstract
{
    public interface IOrderService
    {
        List<Order> GetOrders();
        Dictionary<int, DateTime> AddOrder(Order order);
        //Dictionary<int, List<Dish>> FindOneType(Order order);
        //Dictionary<int, DateTime> SetCookWorkTime(Dictionary<int, List<Dish>> typeLists);
    }
}
