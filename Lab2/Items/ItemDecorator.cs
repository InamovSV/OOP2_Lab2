using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Robots;

namespace Lab2.Items
{
    public abstract class ItemDecorator : Item
    {
        public ItemDecorator(double weight, double price) : base(weight, price)
        {
        }

        public Item Component { protected get; set; }

        public override Item Copy()
        {
            if (Component != null)
                return Component.Copy();
            else throw new NullReferenceException();
        }

        public override bool Influence(Robot robot, Item item = null)
        {
            if (Component != null)
                return Component.Influence(robot);
            else throw new NullReferenceException();
        }
       
    }
}
