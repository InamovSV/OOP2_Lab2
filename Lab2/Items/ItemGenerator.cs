using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Items
{
    public class ItemGenerator
    {
        public List<Position> Positions { get; set; }

        public ItemGenerator(int width, int hight)
        {
            _width = width;
            _hight = hight;
            Positions = new List<Position>();
        }

        int _width;
        int _hight;

        private Position GetNewPosition()
        {
            var rand = new Random();
            var pos = new Position();

            while (pos.X == 0 && pos.Y == 0 || Positions.Contains(pos))
            {
                pos = new Position(rand.Next(_width - 1), rand.Next(_hight - 1));
            }
            Positions.Add(pos);
            return pos;
        }

        public Item GetBomb()
        {
            var res = new Bomb();
            res.Pos = GetNewPosition();
            return res;
        }

        public Item GetSimple(double weight, double price)
        {
            var res = new SimpleItem(weight, price);

            res.Pos = GetNewPosition();
            return res;
        }

        public Item GetCoded(double weight, double price)
        {
            var pos = GetNewPosition();
            var component = new SimpleItem(weight, price);
            component.Pos = pos;
            var res = new CodedItem(weight, price);
            res.Component = component;
            res.Pos = pos;
            return res;
        }

        public Item GetToxic(double weight, double price)
        {
            var pos = GetNewPosition();
            var component = new SimpleItem(weight, price);
            component.Pos = pos;
            var res = new ToxicItem(weight, price);
            res.Component = component;
            res.Pos = pos;
            return res;
        }

        public Item GetSpoiled(double weight, double price, int delay)
        {
            var pos = GetNewPosition();
            var component = new SimpleItem(weight, price);
            component.Pos = pos;
            var res = new SpoilableItem(weight, price, delay);
            res.Component = component;
            res.Pos = pos;
            return res;
        }

        public Item GetToxicSpoiled(double weight, double price, int delay)
        {
            var pos = GetNewPosition();
            var component = new SimpleItem(weight, price);
            component.Pos = pos;
            
            var toxic = new ToxicItem(weight, price);
            toxic.Pos = pos;

            var spoiled = new SpoilableItem(weight, price, delay);
            spoiled.Pos = pos;

            toxic.Component = component;
            spoiled.Component = toxic;
            return spoiled;
        }

        public List<Item> GenerateN(int itemType, int n)
        {
            var rand = new Random();
            var res = new List<Item>();
            for (int i = 0; i < n; i++)
            {
                switch ((Type)itemType)
                {
                    case Type.Bomb:
                        res.Add(GetBomb());
                        break;
                    case Type.Simple:
                        res.Add(GetSimple(rand.Next(10, 100), rand.Next(10, 100)));
                        break;
                    case Type.Coded:
                        res.Add(GetCoded(rand.Next(10, 150), rand.Next(100, 1000)));
                        break;
                    case Type.Toxic:
                        res.Add(GetCoded(rand.Next(10, 100), rand.Next(50, 500)));
                        break;
                    case Type.Spoiled:
                        var delay0 = rand.Next(5, 20);
                        res.Add(GetSpoiled(rand.Next(10, 70), rand.Next(500, 5000) / delay0, delay0));
                        break;
                    case Type.ToxicSpoiled:
                        var delay1 = rand.Next(5, 20);
                        res.Add(GetToxicSpoiled(rand.Next(10, 50), rand.Next(1000, 10000) / delay1, delay1));
                        break;
                    default:
                        break;
                }
            }
            return res;
        }

        public enum Type
        {
            Bomb,
            Simple,
            Coded,
            Toxic,
            Spoiled,
            ToxicSpoiled
        }
    }
}
