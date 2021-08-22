using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstract
{
    public interface IDishTypeService
    {
        DishType GetDishType(int Id);
    }
}
