using Lab2.Robots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Items
{
    public class SpoilableItem : ItemDecorator
    {
        public SpoilableItem(double weight, double price, int countOfSteps, Item component = null) : base(weight, price)
        {
            _steps = countOfSteps;
            IsSpoiled = false;
            if (component != null)
                Component = component;
            else
                Component = new SimpleItem(weight, price);
        }
        int _steps;
        public bool IsSpoiled { get; set; }

        public override Item Copy()
        {
            var res = new SpoilableItem(Weight, Price, _steps);
            res.Pos = Pos;
            res.IsSpoiled = IsSpoiled;
            res.Component = Component.Copy();
            return res;
        }

        public override bool Influence(Robot robot, Item item = null)
        {
            try
            {
                robot.MoveRobot += Robot_MoveRobot;
                return base.Influence(robot, this);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void Robot_MoveRobot(Robot e)
        {
            if (_steps > 1)
                --_steps;
            else if(_steps == 1)
            {
                --_steps;
                //e.MoveRobot -= Robot_MoveRobot;
                Spoile(e);
            }
        }

        public override char GetSymbol()
        {
            return 'o';
        }

        public void Spoile(Robot robot)
        {
            IsSpoiled = true;
            Price *= 0.25;
            robot.Money -= Price * 0.75;
        }

        public override string ToString()
        {
            if (Component != null &&  Component.GetName() != "Simple")
                return string.Format(Component.GetName() + "SpoilableItem\n\t\t{0}weight {1}\n\t\t{2}price {3}\n\t\t{4}time to spoile {5}", (char)0x00B7, Weight, (char)0x00B7, Price, (char)0x00B7, _steps);
            else return string.Format("SpoilableItem\n\t\t{0}weight {1}\n\t\t{2}price {3}\n\t\t{4}time to spoile {5}", (char)0x00B7, Weight, (char)0x00B7, Price, (char)0x00B7, _steps);
        }

        public override string GetName()
        {
            if (Component != null && Component.GetName() != "Simple")
                return Component.GetName() + "Spoilable";
            else return "Spoilable";
        }
    }
}
