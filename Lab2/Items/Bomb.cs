using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Robots;

namespace Lab2.Items
{
    public class Bomb : Item
    {

        public Bomb() : base(0, 0)
        {

        }

        public override Item Copy()
        {
            var res = new Bomb();
            res.Pos = Pos;
            return res;
        }

        public override string GetName()
        {
            return "Bomb";
        }

        public override char GetSymbol()
        {
            return 'b';
        }

        public override bool Influence(Robot robot, Item item = null)
        {
            robot.Kill();
            return true;
        }
    }
}
