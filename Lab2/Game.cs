using Lab2.Items;
using Lab2.Robots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Game
    {
        public Game(ControlUnit controlUnit, Player player, int width, int hight)
        {
            _player = player;
            _controlUnit = controlUnit;
            _width = width;
            _hight = hight;
            _field = new char[width, hight];
            _items = GenerateItems(_width, hight);

            for (int i = 0; i < hight; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < width; j++)
                {
                    _field[i, j] = '.';
                    Console.Write(" " + _field[i, j] + " ");
                }
            }
        }

        readonly int _width;
        readonly int _hight;
        char[,] _field;
        bool _isEnd;
        Player _player;
        Robot _robot;
        List<Item> _items;
        Item _currentItem;
        ControlUnit _controlUnit;

        public void Start()
        {
            _robot = _player.CreateRobot();
            _robot.EndOfCharge += () => _isEnd = true;
            RefreshField(_robot);
        }

        private void Run(ICommand command)
        {
            _controlUnit.StoreCommand(command);
            _controlUnit.ExecuteCommand();
        }

        public void ClickUp()
        {
            if (_robot.Pos.Y > 0)
            {
                Run(new MoveCommand(this, MoveSide.Up));
                RefreshField(_robot);
            }
        }

        public void ClickRight()
        {
            if (_robot.Pos.X < _width - 1)
            {
                Run(new MoveCommand(this, MoveSide.Right));
                RefreshField(_robot);
            }
        }

        public void ClickDown()
        {
            if (_robot.Pos.Y < _hight - 1)
            {
                Run(new MoveCommand(this, MoveSide.Down));
                RefreshField(_robot);
            }
        }

        public void ClickLeft()
        {
            if (_robot.Pos.X > 0)
            {
                Run(new MoveCommand(this, MoveSide.Left));
                RefreshField(_robot);
            }
        }

        public void Undo(int levels)
        {
            _controlUnit.Undo(levels);
            RefreshField(_robot);
        }
        public void Redo(int levels)
        {
            _controlUnit.Redo(levels);
            RefreshField(_robot);
        }

        public void TakeItem()
        {
            if (_currentItem != null)
            {
                Run(new TakeItemCommand(this, _currentItem));
                RefreshField(_robot);
            }
        }

        List<Item> GenerateItems(int width, int hight)
        {
            int n = (int)(width * hight * 0.2);
            var resList = new List<Item>(n);
            var generator = new ItemGenerator(width, hight);

            int[] counts = new int[] { (int)(n * 0.1), (int)(n * 0.4), (int)(n * 0.1), (int)(n * 0.1), (int)(n * 0.1), (int)(n * 0.1) };

            for (int j = 0; j < counts.Length; j++)
            {
                resList.AddRange(generator.GenerateN(j, counts[j]));
            }
            return resList;

        }

        public void SetMemento(INarrowGameMemento memento)
        {
            var mem = (GameMemento)memento;
            _robot.SetMemento(mem.Robot);
            _items = mem.Items;
            _isEnd = mem.IsEnd;
            //_items.FindAll(item => item is SpoilableItem).ForEach(x => (x as SpoilableItem).StartSpoile(_robot));
        }

        public INarrowGameMemento CreateMemento()
        {
            return new GameMemento(_robot.CreateMemento(), _items.Select(x => x.Copy()).ToList(), _isEnd);
        }

        void RefreshField(Robot robot)
        {
            Console.Clear();
            if (_isEnd)
            {
                Console.WriteLine("The end of game");
                Console.WriteLine(robot.GetType().Name);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Weight: " + robot.CurrentCapacity);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Money: " + robot.Money);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Charge " + robot.Charge);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(robot.GetType().Name);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Weight: " + robot.CurrentCapacity);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Money: " + robot.Money);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Charge " + robot.Charge);
                Console.ResetColor();
                Console.WriteLine();
                for (int i = 0; i < _hight; i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < _width; j++)
                    {
                        var item = _items.Find(x => { return x.Pos.X == j && x.Pos.Y == i; });

                        if (i == robot.Pos.Y && j == robot.Pos.X)
                        {
                            _currentItem = item;
                            if (_currentItem is Bomb)
                                _isEnd = true;
                            _field[i, j] = 'x';
                            Console.Write(" " + _field[i, j] + " ");
                        }
                        else if (item != null)
                        {
                            _field[i, j] = item.GetSymbol();
                            Console.Write(" " + _field[i, j] + " ");
                        }
                        else
                        {
                            _field[i, j] = '.';
                            Console.Write(" " + _field[i, j] + " ");
                        }
                    }
                }
            }
            Console.WriteLine("\nCurrent item " + _currentItem);
        }

        public class MoveCommand : ICommand
        {
            public MoveCommand(Game game, MoveSide side)
            {
                _receiver = game;
                _side = side;
            }

            Game _receiver;
            MoveSide _side;
            INarrowGameMemento _memento;

            public void Execute()
            {
                _memento = _receiver.CreateMemento();
                _receiver._robot.Move(_side);
            }

            public void UnExecute()
            {
                if (_memento != null)
                    _receiver.SetMemento(_memento);
            }
        }

        public class TakeItemCommand : ICommand
        {
            public TakeItemCommand(Game game, Item item)
            {
                _receiver = game;
                _item = item;
            }

            Game _receiver;
            Item _item;
            INarrowGameMemento _memento;
            public void Execute()
            {
                _memento = _receiver.CreateMemento();
                bool wasAdded = _receiver._robot.TakeItem(_item);
                if (wasAdded)
                    _receiver._items.Remove(_item);
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
