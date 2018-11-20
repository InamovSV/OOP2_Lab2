using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Robots;

namespace Lab2.Items
{
    public class SimpleItem : Item
    {
        public SimpleItem(double weight, double price) : base(weight, price)
        {
            
        }

        public override Item Copy()
        {
            var res = new SimpleItem(Weight, Price);
            res.Pos = Pos;
            return res;
        }

        public override string GetName()
        {
            return "Simple";
        }

        public override char GetSymbol()
        {
            return 'o';
        }

        public override bool Influence(Robot robot, Item item = null)
        {
            try
            {
                if(item == null)
                {
                    robot.CurrentCapacity += this.Weight;
                    robot.Money += this.Price;
                    robot.Cargo.Add(this);
                    return true;
                }
                else
                {
                    robot.CurrentCapacity += item.Weight;
                    robot.Money += item.Price;
                    robot.Cargo.Add(item);
                    return true;
                }
                
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return string.Format("SimpleItem\n\t\t{0}weight {1}\n\t\t{2}price {3}", (char)0x00B7, Weight, (char)0x00B7, Price);
        }
    }
}
