using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Position
    {

        public Position(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public Position Copy()
        {
            return new Position(X, Y);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var pos = obj as Position;
            if (pos != null)
                return X == pos.X && Y == pos.Y;
            else return false;
        }
    }
}
