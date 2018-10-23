using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Items
{
    abstract class Item
    {
        public Item(double weight, double price)
        {
            Price = price;
            Weight = weight;
        }

        double _weight;
        double _price;

        public double Weight
        {
            get
            {
                return _weight;
            }

            set
            {
                _weight = value;
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }

        public abstract Item Copy();
    }
}
