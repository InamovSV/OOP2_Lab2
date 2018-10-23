using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Lab2.Robots;

namespace Lab2
{
    class Player
    {
        Bitmap _avatar;
        string _name;
        string _legend;
        Robot _robot;

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
    }
}
