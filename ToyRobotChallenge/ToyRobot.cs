using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotChallenge
{
    public class ToyRobot
    {
        // position of toyrobot
        int x;
        int y;
        Facing direction;

        // getters/setters for position
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Facing Direction { get => direction; set => direction = value; }

        public enum Facing
        {
            NORTH,
            SOUTH,
            EAST,
            WEST
        };

        // properties of board
        int boardLength = 5;
        int boardHeight = 5;

        // getters/setters for board dimensions
        public int BoardLength { get => boardLength; set => boardLength = value; }
        public int BoardHeight { get => boardHeight; set => boardHeight = value; }

        // toy robot constructor w/ default values of -1, -1 as a check if it's been placed
        public ToyRobot(int x = -1, int y = -1)
        {
            this.x = x;
            this.y = y;
        }

        public void Execute(string cmd)
        {
            // check if cmd starting with PLACE, if found, split and call place method
            // do RotateLeft || RotateRight || Move
            // until REPORT
            // reset robot for next test
        }

        public void PlaceRobot(int x, int y, Facing direction)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
        }

        public void RotateLeft()
        {
            // switch case to rotate anticlockwise ie. West to South
        }
        public void RotateRight()
        {
            // switch case to rotate clockwise
        }
        public void MoveForward()
        {
            // temp variable to hold x,y
            // incre position in current direction if valid position
        }
        public string ReportPosition()
        {
            // return toy robots current x,y,facing coords
            return x.ToString() + ", "
                + y.ToString() + ", "
                + Enum.GetName(direction.GetType(), direction);
        }
    }

}