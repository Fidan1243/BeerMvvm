using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11.Models
{
    public class Payment: Entity
    {
        public string BeerName { get; set; }
        public double TotalPrice { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
        public override string ToString()
        {
            return $"{BeerName} - {Count} - {TotalPrice} azn - {Date.ToShortDateString()}";
        }
    }
}
