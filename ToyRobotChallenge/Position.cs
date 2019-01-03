using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotChallenge
{
    public class Position
    {
        // properties of position
        // used by toyrobot and board (obstacles)

        int xCoord;
        int yCoord;
        Facing direction;
        bool isObstacle;

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
            isObstacle = false;
        }

        public Position(int x = -1, int y = -1, bool isObstacle = false)
        {
            xCoord = x;
            yCoord = y;
            this.isObstacle = isObstacle;
        }

        // getters/setters for position
        public int X { get => xCoord; set => xCoord = value; }
        public int Y { get => yCoord; set => yCoord = value; }
        public Facing Direction { get => direction; set => direction = value; }
        public bool IsObstacle { get => isObstacle; set => isObstacle = value; }



    }
}
