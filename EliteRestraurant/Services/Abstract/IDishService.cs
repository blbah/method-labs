using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstract
{
    public interface IDishService
    {
        void AddDish(Dish dish, Order order);
        
    }
}
