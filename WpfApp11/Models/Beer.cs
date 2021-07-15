using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11.Models
{
    public class Beer : Entity, INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public double Volume { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        private int count = 1;

        public int Count
        {
            get { return count; }
            set { count = value; OnPropertyChanged(); }
        }
        protected void OnPropertyChanged([CallerMemberName]string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
