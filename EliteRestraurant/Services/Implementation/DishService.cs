using DAccessLayer.Abstract;
using Model;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class DishService : IDishService
    {
        private IUnitOfWork unitOfWork;

        public DishService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        void IDishService.AddDish(Dish dish, Order order)
        {
            order.DishList.Add(dish);
        }
    }
}
