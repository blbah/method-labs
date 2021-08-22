using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstract
{
    public interface IMenuService
    {
        List<Menu> GetMenus();
        Menu GetCurrentMenu();
        void SetCurrent(int current);
    }
}
