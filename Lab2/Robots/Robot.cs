using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Items;
using static Lab2.Game;

namespace Lab2.Robots
{
    public abstract class Robot
    {

        public Robot()
        {
            Pos = new Position();
            _cargo = new List<Item>();
        }
        double _charge;
        double _capacity;
        List<Item> _cargo;
        readonly Player _owner;
        double _currentCapacity;
        double _money;
        Position _pos;

        abstract public double MaxCharge { get; }

        public virtual double Charge
        {
            get
            {
                return _charge;
            }
            set
            {
                if (value <= MaxCharge && value >= 0)
                    _charge = value;
                else EndOfCharge();
            }
        }

        abstract public double MaxCapacity { get; }

        abstract public int DecodingFactor { get; }

        public List<Item> Cargo
        {
            get
            {
                return _cargo;
            }
        }

        internal Player Owner
        {
            get
            {
                return _owner;
            }
        }

        public double CurrentCapacity
        {
            get
            {
                return _currentCapacity;
            }

            set
            {
                if (value <= MaxCapacity && value >= 0)
                    _currentCapacity = value;
                else throw new Exception("Over max capacity");
            }
        }

        public Position Pos
        {
            get
            {
                return _pos;
            }

            set
            {
                _pos = value;
            }
        }

        public double Money
        {
            get
            {
                return _money;
            }

            set
            {
                _money = value;
            }
        }

        public void SetMemento(INarrowRobotMemento memento)
        {
            var mem = (RobotMemento)memento;
            _charge = mem.Charge;
            _currentCapacity = mem.CurrentCapacity;
            _cargo = mem.Cargo;
            _pos = mem.Pos;
            _money = mem.Money;
        }

        public INarrowRobotMemento CreateMemento()
        {
            return new RobotMemento(_pos.Copy(), Charge, CurrentCapacity, Money, Cargo.Select(x => x.Copy()).ToList());
        }

        public bool TakeItem(Item item)
        {
            return item.Influence(this);
        }

        public void Move(MoveSide side)
        {
            MoveRobot?.Invoke(this);
            switch (side)
            {
                case MoveSide.Up:
                    --Pos.Y;
                    Charge -= 1;
                    break;
                case MoveSide.Right:
                    ++Pos.X;
                    Charge -= 1;
                    break;
                case MoveSide.Down:
                    ++Pos.Y;
                    Charge -= 1;
                    break;
                case MoveSide.Left:
                    --Pos.X;
                    Charge -= 1;
                    break;
                default:
                    break;
            }
        }

        public void Kill()
        {
            EndOfCharge();
        }

        public delegate void RobotChargeHandler();
        public delegate void RobotMovementHandler(Robot e);

        public event RobotChargeHandler EndOfCharge;
        public event RobotMovementHandler MoveRobot;

        //public ICommand GetMoveCommand(MoveSide side)
        //{
        //    return new MoveCommand(this, side);
        //}

        //public ICommand GetTakeItemCommand(MoveSide side)
        //{
        //    return new MoveCommand(this, side);
        //}



    }
}
