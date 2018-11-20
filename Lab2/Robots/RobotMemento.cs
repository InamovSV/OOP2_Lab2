using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Items;

namespace Lab2.Robots
{
    public class RobotMemento : INarrowRobotMemento
    {
        public RobotMemento(Position pos, double charge, double currentCapacity, double money, List<Item> cargo)
        {
            Charge = charge;
            CurrentCapacity = currentCapacity;
            Cargo = cargo;
            Pos = pos;
            Money = money;
        }

        public List<Item> Cargo { get; set; }

        public double Charge { get; set; }

        public Position Pos { get; set; }

        public double CurrentCapacity { get; set; }

        public double Money { get; set; }

        public void SetState(Position pos, double charge, double currentCapacity, double money, List<Item> cargo)
        {
            Charge = charge;
            CurrentCapacity = currentCapacity;
            Cargo = cargo;
            Pos = pos;
            Money = money;
        }

    }
}
