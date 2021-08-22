using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Model
{
    public class Dish : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan PreparingTime { get; set; }
        public DishType DishType { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
