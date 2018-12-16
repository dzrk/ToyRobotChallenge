using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotChallenge
{
    public class ToyRobot
    {
        // position of toyrobot
        int xCoord;
        int yCoord;
        Facing direction;

        // getters/setters for position
        public int X { get => xCoord; set => xCoord = value; }
        public int Y { get => yCoord; set => yCoord = value; }
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
            this.xCoord = x;
            this.yCoord = y;
        }

        public void Execute(string cmd)
        {
            // check if cmd starting with PLACE, if found, split and call place method
            // do RotateLeft || RotateRight || Move
            if (cmd.StartsWith("PLACE"))
            {
                char[] delimChars = { ' ', ',' };
                string[] placeCmd = cmd.Split(delimChars);

                try
                {
                    int xPlace = Convert.ToInt32(placeCmd[1]);
                    int yPlace = Convert.ToInt32(placeCmd[2]);
                    Facing dirPlace = ConvertToEnum<Facing>(placeCmd[3]);

                    if (isValidPosition(xPlace, yPlace, dirPlace))
                    {
                        PlaceRobot(xPlace, yPlace, dirPlace);
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("{0} is not a valid direction.", placeCmd[3]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} or {1} argument is in the wrong format.", placeCmd[1], placeCmd[2]);
                }
            }
            else if (cmd.StartsWith("echo"))
            {
                Console.WriteLine(cmd.Substring(5));
            }
            else if (cmd == "MOVE")
            {
                MoveForward();
            }
            else if (cmd == "RIGHT")
            {
                RotateRight();
            }
            else if (cmd == "LEFT")
            {
                RotateLeft();
            }
            else if (cmd == "REPORT")
            {
                Console.WriteLine(ReportPosition());
            }
            else if (cmd.StartsWith("VALIDATE"))
            {
                // get x,y,z and compare to report position
                string[] validatePos = cmd.Split(' ');
                if (validatePos[1] == ReportPosition())
                {
                    Console.WriteLine("VALIDATION SUCCESS");
                }
                else
                {
                    Console.WriteLine("VALIDATION FAILED");
                }
            }
        }

        public void PlaceRobot(int x, int y, Facing direction)
        {
            this.xCoord = x;
            this.yCoord = y;
            this.direction = direction;
        }

        public void RotateLeft()
        {
            // switch case to rotate anticlockwise ie. West to South
            switch (direction)
            {
                case Facing.NORTH:
                    direction = Facing.WEST;
                    break;
                case Facing.WEST:
                    direction = Facing.SOUTH;
                    break;
                case Facing.SOUTH:
                    direction = Facing.EAST;
                    break;
                case Facing.EAST:
                    direction = Facing.NORTH;
                    break;
            }
        }
        public void RotateRight()
        {
            // switch case to rotate clockwise
            switch (direction)
            {
                case Facing.NORTH:
                    direction = Facing.EAST;
                    break;
                case Facing.EAST:
                    direction = Facing.SOUTH;
                    break;
                case Facing.SOUTH:
                    direction = Facing.WEST;
                    break;
                case Facing.WEST:
                    direction = Facing.NORTH;
                    break;
            }
        }
        public void MoveForward()
        {
            // temp variable to hold x,y
            int tempX = xCoord;
            int tempY = yCoord;

            // incre position in current direction if valid position
            switch (direction)
            {
                case Facing.NORTH:
                    tempY++;
                    if (tempY < boardHeight)
                    {
                        yCoord++;
                    }
                    break;
                case Facing.EAST:
                    tempX++;
                    if (tempX < boardLength)
                    {
                        xCoord++;
                    }
                    break;
                case Facing.SOUTH:
                    tempY--;
                    if (tempY >= 0)
                    {
                        yCoord--;
                    }
                    break;
                case Facing.WEST:
                    tempX--;
                    if (tempX >= 0)
                    {
                        xCoord--;
                    }
                    break;

            }
        }
        public string ReportPosition()
        {
            // return toy robots current x,y,facing coords
            if(xCoord != -1 || yCoord != -1)
            {
                return xCoord.ToString() + ","
                + yCoord.ToString() + ","
                + Enum.GetName(direction.GetType(), direction);
            }
            return "Robot not placed";

        }

        public static string ConvertToString(Facing direction)
        {
            return Enum.GetName(direction.GetType(), direction);
        }

        public static Facing ConvertToEnum<Facing>(String enumValue)
        {
            return (Facing)Enum.Parse(typeof(Facing), enumValue);
        }

        public bool isValidPosition(int xPlace, int yPlace, Facing direction)
        {
            bool isValid = false;
            // check if place position is possible
            if((xPlace > -1 && xPlace < boardLength) && (yPlace > -1 && yPlace < boardHeight))
            {
                // check if direction is a valid direction
                if (Enum.IsDefined(typeof(Facing), direction))
                {
                    isValid = true;
                }
            }
            return isValid;
        }
    }

}