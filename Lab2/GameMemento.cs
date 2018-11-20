using Lab2.Items;
using Lab2.Robots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class GameMemento : INarrowGameMemento
    {
        public GameMemento(INarrowRobotMemento robot, List<Item> items, bool isEnd)
        {
            Robot = robot;
            Items = items;
            IsEnd = isEnd;
        }

        public List<Item> Items { get; set; }

        public INarrowRobotMemento Robot { get; set; }

        public bool IsEnd { get; set; }

        public void SetState(INarrowRobotMemento robot, List<Item> items, bool isEnd)
        {
            Robot = robot;
            Items = items;
            IsEnd = isEnd;
        }
    }
}
