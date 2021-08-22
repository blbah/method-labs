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
    public class MenuService : IMenuService
    {
        private IUnitOfWork unitOfWork;
        private int current = 0;

        public MenuService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void SetCurrent(int current)
        {
            if(current <= GetMenus().Count)
            {
                this.current = current;
            }
        }
        public List<Menu> GetMenus()
        {
            return unitOfWork.MenuRepository.GetAll().Select(i => i.toModel()).ToList();
        }
        public Menu GetCurrentMenu()
        {
            return GetMenus()[current];
        }
    }
}
