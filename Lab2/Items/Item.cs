using Lab2.Robots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Items
{
    public abstract class Item
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

        public abstract string GetName();

        public abstract bool Influence(Robot robot, Item item = null);

        public Position Pos { get; set; }

        public abstract Item Copy();

        public abstract char GetSymbol();

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var item = obj as Item;
            if (item != null)
                return Pos == item.Pos && Price == item.Price && Weight == item.Weight;
            else return false;
        }
    }
}
