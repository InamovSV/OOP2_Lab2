using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Items;

namespace Lab2.Robots
{
    class Kiborg : Robot
    {
        readonly double _maxCapacity;
        readonly double _decodingFactor;
        readonly double _maxCharge;

        public Kiborg()
        {
            _maxCapacity = 700;
            _maxCharge = 75;
            _decodingFactor = 60;
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
            
        }
    }
}
