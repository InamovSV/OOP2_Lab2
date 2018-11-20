using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Robots;

namespace Lab2.Items
{
    public class ToxicItem : ItemDecorator
    {
        public ToxicItem(double weight, double price, Item component = null) : base(weight, price)
        {
            if (component != null)
                Component = component;
            else
                Component = new SimpleItem(weight, price);
        }

        public override Item Copy()
        {
            var res = new ToxicItem(Weight, Price);
            res.Pos = Pos;
            res.Component = Component.Copy();
            return res;
        }

        public override string GetName()
        {
            if (Component != null && Component.GetName() != "Simple")
                return Component.GetName() + "Toxic";
            else return "Toxic";
        }

        public override char GetSymbol()
        {
            return 'o';
        }

        public override bool Influence(Robot robot, Item item = null)
        {

            if (robot is Kiborg)
                return false;
            try
            {
                return base.Influence(robot, this);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ToString()
        {
            if(Component!= null && Component.GetName() != "Simple")
                return string.Format(Component.GetName() + "ToxicItem\n\t\t{0}weight {1}\n\t\t{2}tprice {3}", (char)0x00B7, Weight, (char)0x00B7, Price);
            else return string.Format("ToxicItem\n\t\t{0}weight {1}\n\t\t{2}price {3}", (char)0x00B7, Weight, (char)0x00B7, Price);
        }
    }
}
