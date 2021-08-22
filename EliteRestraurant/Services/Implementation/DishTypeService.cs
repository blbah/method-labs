using DAccessLayer.Abstract;
using EliteRestraurantMappers;
using Model;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class DishTypeService : IDishTypeService
    {
        private IUnitOfWork unitOfWork;

        public DishTypeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public DishType GetDishType(int Id)
        {
            return unitOfWork.DishTypeRepository.Get(Id).toModel();
        }
    }
}
