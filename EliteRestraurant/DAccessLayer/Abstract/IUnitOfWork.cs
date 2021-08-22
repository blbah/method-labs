using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAccessLayer.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        ICookRepository CookRepository { get; }
        IDishRepository DishRepository { get; }
        IDishTypeRepository DishTypeRepository { get; }
        IMenuRepository MenuRepository { get; }
        IOrderRepository OrderRepository { get; }
        ISpecializationRepository SpecializationRepository { get; }
    }
}
