using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Items;

namespace Lab2.Robots
{
    class Worker : Robot
    {
        readonly double _maxCapacity;
        readonly double _decodingFactor;
        readonly double _maxCharge;

        public Worker()
        {
            _maxCapacity = 100;
            _maxCharge = 100;
            _decodingFactor = 10;
        }

        public override double MaxCapacity
        {
            get
            {
                return _maxCapacity;
            }

        }


        public override double DecodingFactor
        {
            get
            {
                return _decodingFactor;
            }
        }

        public override double MaxCharge
        {
            get
            {
                return _maxCharge;
            }
        }

        public override void TakeItem(Item item)
        {
            if(item is SimpleItem)
            {
                Cargo.Add(item);
                CurrentCapacity += item.Weight;
            }
        }
    }
}
