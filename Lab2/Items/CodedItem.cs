using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Items
{
    class CodedItem : Item
    {
        public CodedItem(double weight, double price) : base(weight, price)
        {
        }

        public override Item Copy()
        {
            return new CodedItem(Weight, Price);
        }

        public SimpleItem Decode()
        {
            return new SimpleItem(this.Weight, this.Price);
        }
    }
}
