using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Items;

namespace Lab2.Robots
{
    public class Kiborg : Robot
    {
        readonly double _maxCapacity;
        readonly int _decodingFactor;
        readonly double _maxCharge;
        readonly Random rand;

        public Kiborg()
        {
            _maxCapacity = 300;
            _maxCharge = 75;
            _decodingFactor = 60;
            Charge = MaxCharge;
            rand = new Random();
        }

        public override double Charge
        {
            get
            {
                return base.Charge;
            }

            set
            {
                if (CurrentCapacity > MaxCapacity * 0.75 && rand.Next(100) < 25)
                    base.Charge = value*2;
                else
                    base.Charge = value;
            }
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

    }
}
