using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Items
{
    abstract class ItemDecorator : Item
    {
        public ItemDecorator(double weight, double price) : base(weight, price)
        {
        }

        public Item Component { get; set; }
    }
}
