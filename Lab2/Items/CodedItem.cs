using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Robots;

namespace Lab2.Items
{
    public class CodedItem : ItemDecorator
    {
        public CodedItem(double weight, double price, Item component = null) : base(weight, price)
        {
            if (component != null)
                Component = component;
            else
                Component = new SimpleItem(weight, price);
        }

        public override Item Copy()
        {
            var res = new CodedItem(Weight, Price);
            res.Pos = Pos;
            res.Component = Component.Copy();
            return res;
        }

        public Item Decode(int factor)
        {
            var rand = new Random().Next(100);
            if (rand <= factor)
                return Component;
            else return null;
        }

        public override bool Influence(Robot robot, Item item = null)
        {
            var decItem = Decode(robot.DecodingFactor);
            robot.Charge -= 5;
            if (decItem != null)
            {
                try
                {
                    return base.Influence(robot);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else return false;  
        }

        public override char GetSymbol()
        {
            return 'o';
        }

        public override string ToString()
        {
            if (Component != null && Component.GetName() != "Simple")
                return string.Format(Component.GetName() + "CodedItem\n\t\t{0}weight {1}\n\t\t{2}tprice {3}", (char)0x00B7, Weight, (char)0x00B7, Price);
            else return string.Format("CodedItem\n\t\t{0}weight {1}\n\t\t{2}price {3}", (char)0x00B7, Weight, (char)0x00B7, Price);
        }

        public override string GetName()
        {
            if (Component != null && Component.GetName() != "Simple")
                return Component.GetName() + "Coded";
            else return "Coded";
        }
    }
}
