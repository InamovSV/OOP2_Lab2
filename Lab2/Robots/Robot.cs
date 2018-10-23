using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Items;

namespace Lab2.Robots
{
    abstract class Robot
    {

        public Robot()
        {
            Pos = new Position();
            _cargo = new List<Item>();
        }
        double _charge;
        double _capacity;
        List<Item> _cargo;
        double _decodingFactor;
        readonly Player _owner;
        double _currentCapacity;
        Position _pos;

        abstract public double MaxCharge { get; }

        public double Charge
        {
            get
            {
                return _charge;
            }
            set
            {
                if (value <= MaxCharge && value >= 0)
                    _charge = value;
                else throw new Exception();
            }
        }

        abstract public double MaxCapacity { get; }

        abstract public double DecodingFactor { get; }

        internal List<Item> Cargo
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
                if (value <= MaxCapacity && value > 0)
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

        public void SetMemento(INarrowMemento memento)
        {
            var mem = (RobotMemento)memento;
            _charge = mem.Charge;
            _currentCapacity = mem.CurrentCapacity;
            _cargo = mem.Cargo;
            _pos = mem.Pos;
        }

        public INarrowMemento CreateMemento()
        {
            return new RobotMemento(_pos.Copy(), Charge, CurrentCapacity, Cargo.Select(x => x.Copy()).ToList());
        }

        public abstract void TakeItem(Item item);

        public void Move(MoveSide side)
        {
            switch (side)
            {
                case MoveSide.Up:
                    --Pos.Y;
                    break;
                case MoveSide.Right:
                    ++Pos.X;
                    break;
                case MoveSide.Down:
                    ++Pos.Y;
                    break;
                case MoveSide.Left:
                    --Pos.X;
                    break;
                default:
                    break;
            }
        }

        public ICommand GetMoveCommand(MoveSide side)
        {
            return new MoveCommand(this, side);
        }

        public class MoveCommand : ICommand
        {
            public MoveCommand(Robot robot, MoveSide side)
            {
                _receiver = robot;
                _side = side;
            }

            Robot _receiver;
            MoveSide _side;
            INarrowMemento _memento;

            public void Execute()
            {
                _memento = _receiver.CreateMemento();
                _receiver.Move(_side);
            }

            public void UnExecute()
            {
                if (_memento != null)
                    _receiver.SetMemento(_memento);
            }
        }

        public enum MoveSide
        {
            Up,
            Right,
            Down,
            Left
        }

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
        }
    }
}
