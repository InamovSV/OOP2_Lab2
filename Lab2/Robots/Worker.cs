using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Items;

namespace Lab2.Robots
{
    public class Worker : Robot
    {
        readonly double _maxCapacity;
        readonly int _decodingFactor;
        readonly double _maxCharge;

        public Worker()
        {
            _maxCapacity = 400;
            _maxCharge = 100;
            _decodingFactor = 10;
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
            return "Worker\n\tCargo: " + items.ToString();
        }
    }
}
