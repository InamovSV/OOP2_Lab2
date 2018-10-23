using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Items
{
    class SpoilableItem : Item
    {
        public SpoilableItem(double weight, double price, int delay) : base(weight, price)
        {
            _delay = delay;
            IsSpoiled = false;
        }
        int _delay;
        public bool IsSpoiled { get; set; }

        public override Item Copy()
        {
            var res = new SpoilableItem(Weight, Price, _delay);
            res.IsSpoiled = IsSpoiled;
            return res;
        }

        public async Task StartSpoile()
        {
            await Task.Delay(_delay);
            IsSpoiled = true;
        }
    }
}
