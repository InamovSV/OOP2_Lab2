using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Items
{
    class SimpleItem : Item
    {
        public SimpleItem(double weight, double price) : base(weight, price)
        {
            
        }

        public override Item Copy()
        {
            return new SimpleItem(Weight, Price);
        }
    }
}
