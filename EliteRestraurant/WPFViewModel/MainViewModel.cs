using Model;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IDishService dserv;
        private readonly IOrderService oserv;
        private readonly IMenuService mserv;
        private readonly IDishTypeService tserv;
       
        public ICommand AddDishCommand { get; private set; }
        public ICommand AddOrderCommand { get; private set; }

        private List<Dish> dishes;

        private Dish selectedDish;

        private string message;
        public string Message {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }
        public List<Dish> Dishes
        {
            get { return dishes; }
            set
            {
                dishes = value;
                OnPropertyChanged("Dishes");
            }
        }
        public Dish SelectedDish
        {
            get { return selectedDish; }
            set
            {
                selectedDish = value;
                OnPropertyChanged("selectedDish");
            }
        }

        private Order order;
        public Order Order
        {
            get { return order; }
            set
            {
                order = value;
                OnPropertyChanged("order");
            }
        }

        public ObservableCollection<Dish> ordered { get; set; }

        public ObservableCollection<Dish> Ordered
        {
            get { return ordered; }
            set
            {
                ordered = new ObservableCollection<Dish>(Order.DishList);
                OnPropertyChanged("ordered");
            }
        }

        public MainViewModel(IDishService dserv, IDishTypeService tserv, IOrderService oserv, IMenuService mserv)
        {
            this.dserv = dserv;
            this.oserv = oserv;
            this.tserv = tserv;
            this.mserv = mserv;
            this.order = new Order();
            ordered = new ObservableCollection<Dish>(order.DishList);

            AddDishCommand = new Command(obj => AddDishToOrder(),
                                         obj => AddDishToOrderCanExecute());
            AddOrderCommand = new Command(obj => AddOrder(),
                                         obj => AddOrderCanExecute());
            Dishes = mserv.GetCurrentMenu().DishList;
        }

        private void AddDishToOrder()
        {
            if (selectedDish != null)
            {
                Order.DishList.Add(selectedDish);
                Ordered = new ObservableCollection<Dish>(order.DishList);
            }
        }

        private bool AddDishToOrderCanExecute()
        {
            return selectedDish != null;
        }

        private void AddOrder()
        {
            string CurrMessage = "";
            try
            {
                var cookTime = oserv.AddOrder(order);
                CurrMessage += "Cook time:\n";
                foreach (var pair in cookTime)
                {
                    CurrMessage += $"{tserv.GetDishType(pair.Key).Name} in {pair.Value:t}\n";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                CurrMessage = "Sorry, we have no enaugh cooks...";
            }
            this.Message = CurrMessage;
            CurrMessage = "";
            Order = new Order();
            Ordered = new ObservableCollection<Dish>();

        }

        private bool AddOrderCanExecute()
        {
            return Order.DishList.Count > 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
