using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Lab2.Robots;

namespace Lab2
{
    public class Player
    {
        Bitmap _avatar;
        string _name;
        string _legend;
        Robot _robot;

        public Player()
        {
            
        }

        public Player(string name, string legend)
        {
            _name = name;
            _legend = legend;
        }

        public Bitmap Avatar
        {
            get
            {
                return _avatar;
            }

            set
            {
                _avatar = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Legend
        {
            get
            {
                return _legend;
            }

            set
            {
                _legend = value;
            }
        }

        internal Robot Robot
        {
            get
            {
                return _robot;
            }

            set
            {
                _robot = value;
            }
        }

        public Robot CreateRobot()
        {
            int rand = new Random().Next(100);

            if (rand >= 0 && rand < 20)
            {
                _robot = new Smart();
                return _robot;
            }
            else if (rand >= 20 && rand < 50)
            {
                _robot = new Kiborg();
                return _robot;
            }
            else
            {
                _robot = new Worker();
                return _robot;
            }

        }
    }
}
