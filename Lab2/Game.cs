using Lab2.Robots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Game
    {
        public Game(ControlUnit controlUnit, Player player, int width, int hight)
        {
            _player = player;
            _controlUnit = controlUnit;
            _width = width;
            _hight = hight;
            _field = new char[width, hight];
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

        int _width;
        int _hight;
        char[,] _field;
        Player _player;
        Robot _robot;
        ControlUnit _controlUnit;


        public void Start()
        {
            _robot = _player.CreateRobot();
            ChangeRobotPos(_robot.Pos);
        }

        private void Run(ICommand command)
        {
            _controlUnit.StoreCommand(command);
            _controlUnit.ExecuteCommand();
        }

        public void ClickUp()
        {
            Run(_robot.GetMoveCommand(Robot.MoveSide.Up));
            ChangeRobotPos(_robot.Pos);
        }

        public void ClickRight()
        {
            Run(_robot.GetMoveCommand(Robot.MoveSide.Right));
            ChangeRobotPos(_robot.Pos);
        }

        public void ClickDown()
        {
            Run(_robot.GetMoveCommand(Robot.MoveSide.Down));
            ChangeRobotPos(_robot.Pos);
        }

        public void ClickLeft()
        {
            Run(_robot.GetMoveCommand(Robot.MoveSide.Left));
            ChangeRobotPos(_robot.Pos);
        }

        public void Undo(int levels)
        {
            _controlUnit.Undo(levels);
            ChangeRobotPos(_robot.Pos);
        }
        public void Redo(int levels)
        {
            _controlUnit.Redo(levels);
            ChangeRobotPos(_robot.Pos);
        }

        void ChangeRobotPos(Robot.Position pos)
        {
            Console.Clear();
            for (int i = 0; i < _hight; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < _width; j++)
                {
                    if (i == pos.Y && j == pos.X)
                    {
                        _field[i, j] = 'x';
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
    }
}
