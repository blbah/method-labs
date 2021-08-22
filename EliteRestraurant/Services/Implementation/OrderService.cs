using DAccessLayer.Abstract;
using EliteRestraurantMappers;
using Model;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Implementation
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Order> GetOrders()
        {
            return unitOfWork.OrderRepository.GetAll().Select(i => i.toModel()).ToList();
        }

        public Dictionary<int, DateTime> AddOrder(Order order)
        {
            Dictionary<int, List<Dish>> TypeLists = FindOneType(order);
            unitOfWork.OrderRepository.Add(order.toEntity());
            return SetCookWorkTime(TypeLists);
        }

        private Dictionary<int, List<Dish>> FindOneType(Order order)
        {
            Dictionary<int, List<Dish>> TypeLists = new Dictionary<int, List<Dish>>();
            foreach (Dish i in order.DishList)
            {
                if (!TypeLists.ContainsKey(i.DishType.Id))
                {
                    TypeLists.Add(i.DishType.Id, new List<Dish>());
                }
                TypeLists[i.DishType.Id].Add(i);
            }
            return TypeLists;
        }

        private Dictionary<int, DateTime> SetCookWorkTime(Dictionary<int, List<Dish>> typeLists)
        {
            Dictionary<int, DateTime> dishFinishTimes = new Dictionary<int, DateTime>();
            foreach (KeyValuePair<int, List<Dish>> i in typeLists)
            {
                List<Cook> Cooks = unitOfWork.CookRepository.GetByDishType(i.Key, i.Value.Count)
                    .Select(a => a.toModel())
                    .ToList();
                i.Value.OrderBy(j => j.PreparingTime);
                DateTime MaxTime = new DateTime();
                DateTime CurrTime = DateTime.Now;
                for (int k = 0; k < i.Value.Count(); k++)
                {
                    if (Cooks[k].FinishTime < CurrTime && MaxTime < CurrTime + i.Value[k].PreparingTime)
                    {
                        MaxTime = CurrTime + i.Value[k].PreparingTime; 
                    }
                    else if (MaxTime < Cooks[k].FinishTime + i.Value[k].PreparingTime)
                    {
                        MaxTime = Cooks[k].FinishTime + i.Value[k].PreparingTime;
                    }
                }
                foreach(Cook cook in Cooks)
                {
                    cook.FinishTime = MaxTime;
                }
                unitOfWork.SaveChanges();
                dishFinishTimes.Add(i.Key, MaxTime);
            }
            return dishFinishTimes;
        }
    }
}
