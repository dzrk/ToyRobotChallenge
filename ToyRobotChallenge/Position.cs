using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotChallenge
{
    public class Position
    {
        // position of toyrobot
        int xCoord;
        int yCoord;
        Facing direction;

        public enum Facing
        {
            NORTH,
            SOUTH,
            EAST,
            WEST
        };

        public Position(int x = -1, int y = -1)
        {
            xCoord = x;
            yCoord = y;
        }

        // getters/setters for position
        public int X { get => xCoord; set => xCoord = value; }
        public int Y { get => yCoord; set => yCoord = value; }
        public Facing Direction { get => direction; set => direction = value; }

       
    }
}
