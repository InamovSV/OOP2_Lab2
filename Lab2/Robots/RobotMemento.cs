using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Items;

namespace Lab2.Robots
{
    class RobotMemento: INarrowMemento
    {
        public RobotMemento(Robot.Position pos, double charge, double currentCapacity, List<Item> cargo)
        {
            Charge = charge;
            CurrentCapacity = currentCapacity;
            Cargo = cargo;
            Pos = pos;
        }

        public List<Item> Cargo { get; set; }

        public double Charge { get; set; }

        public Robot.Position Pos { get; set; }

        public double CurrentCapacity { get; set; }

        public void SetState(Robot.Position pos, double charge, double currentCapacity, List<Item> cargo)
        {
            Charge = charge;
            CurrentCapacity = currentCapacity;
            Cargo = cargo;
            Pos = pos;
        }

    }
}
