using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Items;

namespace Lab2.Robots
{
    public class Smart : Robot
    {
        readonly double _maxCapacity;
        readonly int _decodingFactor;
        readonly double _maxCharge;

        public Smart()
        {
            _maxCapacity = 200;
            _maxCharge = 50;
            _decodingFactor = 100;
            Charge = MaxCharge;
        }

        public override double MaxCapacity
        {
            get
            {
                return _maxCapacity;
            }

        }


        public override int DecodingFactor
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

        public override string ToString()
        {
            var items = new StringBuilder();
            foreach (var item in Cargo)
            {
                items.Append("\t" + item.ToString() + "\n");
            }
            return "Smart\n\tCargo: " + items.ToString();
        }

    }
}
