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
        double _charge;
        double _capacity;
        List<Item> _cargo;
        double _decodingFactor;
        readonly Player _owner;
        double _currentCapacity;

        abstract public double MaxCharge { get; }

        abstract public double Charge { get; set; }

        abstract public double MaxCapacity { get; }

        abstract public double DecodingFactor { get; }

        internal List<Item> Cargo
        {
            get
            {
                return _cargo;
            }

            set
            {
                _cargo = value;
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
                _currentCapacity = value;
            }
        }

        public void SetMemento(INarrowMemento memento)
        {
            var mem = (RobotMemento)memento;
            Charge = mem.Charge;
            CurrentCapacity = mem.CurrentCapacity;
            Cargo = mem.Cargo;
        }

        public INarrowMemento CreateMemento()
        {
            return new RobotMemento(Charge, CurrentCapacity, Cargo.Select(x => x.Copy()).ToList());
        }

        public void Move(MoveSide side)
        {

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
    }
}
