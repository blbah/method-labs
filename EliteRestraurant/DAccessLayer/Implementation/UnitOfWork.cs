using DAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAccessLayer.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private EliteRestraurantContext context;
        private bool isDisposed;

        public UnitOfWork(EliteRestraurantContext context,
            ICookRepository cookRepository,
            IDishRepository dishRepository,
            IDishTypeRepository dishTypeRepository,
            IMenuRepository menuRepository,
            IOrderRepository orderRepository,
            ISpecializationRepository specializationRepository)
        {
            this.context = context;
            this.isDisposed = false;
            CookRepository = cookRepository;
            DishRepository = dishRepository;
            DishTypeRepository = dishTypeRepository;
            MenuRepository = menuRepository;
            OrderRepository = orderRepository;
            SpecializationRepository = specializationRepository;
        }

        ~UnitOfWork() { Dispose(false); }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public void Dispose() 
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if(isDisposed) { return; }
            if(disposing) { context.Dispose(); }
            isDisposed = true;
        }
        public ICookRepository CookRepository { get; private set; }
        public IDishRepository DishRepository { get; private set; }
        public IDishTypeRepository DishTypeRepository { get; private set; }
        public IMenuRepository MenuRepository { get; private set; }
        public IOrderRepository OrderRepository { get; private set; }
        public ISpecializationRepository SpecializationRepository { get; private set; }
    }
}
