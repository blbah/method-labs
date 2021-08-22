using Model;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteRestraurantConsole.UI
{
    class CLI
    {
        protected readonly IDishService dishService;
        protected readonly IDishTypeService dishTypeService;
        protected readonly IMenuService menuService;
        protected readonly IOrderService orderService;

        protected Dictionary<int, string> mainMenu = new Dictionary<int, string>
        {
            { 1, "Show Menu" },
            { 2, "Make Order"},
            { 0, "Exit" }
        };

        protected ConsoleKey pressed;

        public CLI(IDishService dishService, IDishTypeService dishTypeService, IMenuService menuService, IOrderService orderService)
        {
            this.dishService = dishService;
            this.dishTypeService = dishTypeService;
            this.menuService = menuService;
            this.orderService = orderService;
        }

        public void Run()
        {
            do
            {
                PrintMenu();
                pressed = Console.ReadKey().Key;
                Press();
            } while (pressed != ConsoleKey.D0);
        }

        protected void PrintMenu()
        {
            Console.Clear();
            foreach (var pair in mainMenu)
            {
                Console.WriteLine($"{pair.Key}. {pair.Value}");
            }
        }

        protected void Press()
        {
            switch (pressed)
            {
                case ConsoleKey.D1:
                    ShowMenu();
                    break;
                case ConsoleKey.D2:
                    MakeOrder();
                    break;
                case ConsoleKey.D3:
                    break;
                case ConsoleKey.D4:
                    break;
                case ConsoleKey.D5:
                    break;
                case ConsoleKey.D6:
                    break;
                case ConsoleKey.D7:
                    break;
                case ConsoleKey.D8:
                    break;
                case ConsoleKey.D9:
                    break;
                case ConsoleKey.D0:
                default:
                    break;
            }
        }

        protected void ShowMenu()
        {
            Console.Clear();
            foreach (var dish in menuService.GetCurrentMenu().DishList)
            {
                Console.WriteLine($"{dish.Id} {dish.Name}");
            }
            Console.ReadKey();
        }
        protected void MakeOrder()
        {
            var dishes = new List<Dish>();
            var dishList = menuService.GetCurrentMenu().DishList;
            var ordering = true;
            while (ordering)
            {
                Console.Clear();
                Console.WriteLine("Current order:");
                foreach (var dish in dishes)
                {
                    Console.WriteLine(dish.Name);
                }
                Console.WriteLine("Press a to add dish, o to make order");
                var pressed2 = Console.ReadKey().Key;
                switch (pressed2)
                {
                    case ConsoleKey.A:
                        AddDishToOrder();
                        break;
                    case ConsoleKey.O:
                        ordering = false;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine();
            if (dishes.Count > 0)
            {
                try
                {
                    var cookTime = orderService.AddOrder(new Order() { DishList = dishes });
                    Console.WriteLine("Cook time:");
                    foreach (var pair in cookTime)
                    {
                        Console.WriteLine($"{dishTypeService.GetDishType(pair.Key).Name} in {pair.Value:t}");
                    }
                }
                catch(ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Sorry, we have no enaugh cooks...");
                }
            }
            Console.ReadKey();

            void AddDishToOrder()
            {
                Console.Clear();
                Console.WriteLine("Write dish id and press Enter:");
                foreach (var dish in dishList)
                {
                    Console.WriteLine($"{dish.Id} {dish.Name}");
                }
                var stringId = Console.ReadLine();
                if (int.TryParse(stringId, out int id))
                {
                    if (dishList.Any(d => d.Id == id))
                    {
                        dishes.Add(dishList.Single(d => d.Id == id));
                    }
                }
            }
        }
    }
}
