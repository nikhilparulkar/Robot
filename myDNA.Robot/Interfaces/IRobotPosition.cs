using System;
using System.Collections.Generic;
using System.Text;

namespace myDNA.Robot.Interfaces
{


    public interface IRobotPosition
    {
        void left();
        void move();
        void right();
        string report();
        void place(int x, int y, string direction);
    }
}
