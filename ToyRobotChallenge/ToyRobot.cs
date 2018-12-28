using System;
using System.Collections.Generic;
using System.Text;
using static ToyRobotChallenge.Position;


namespace ToyRobotChallenge
{
    public class ToyRobot
    {
        // robot's board
        Board currentBoard;
        Position currentPosition;

        public Position CurrentPosition { get => currentPosition; set => currentPosition = value; }
        public Board CurrentBoard { get => currentBoard; set => currentBoard = value; }


        // toy robot constructor w/ default values of -1, -1 as a check if it's been placed
        public ToyRobot()
        {
            currentPosition = new Position();
        }

        public string Execute(string cmd, Board board)
        {
            // check if cmd starting with PLACE, if found, split and call place method
            // do RotateLeft || RotateRight || Move || Report || Validate until echo
            string result = "";
            currentBoard = board;

            if (cmd.StartsWith("PLACE"))
            {
                char[] delimChars = { ' ', ',' };
                string[] placeCmd = cmd.Split(delimChars);
                Facing dirPlace = currentPosition.Direction;

                if (Enum.TryParse<Facing>(placeCmd[3], out dirPlace))
                {

                    int xPlace = Convert.ToInt32(placeCmd[1]);
                    int yPlace = Convert.ToInt32(placeCmd[2]);

                    if (isValidPosition(xPlace, yPlace, dirPlace))
                    {
                        PlaceRobot(xPlace, yPlace, dirPlace);
                    }
                }
                
            }
            else if (cmd.StartsWith("echo"))
            {
                result = cmd.Substring(5);
                Console.WriteLine(result);
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
                result = ReportPosition();
                Console.WriteLine(result);

            }
            else if (cmd.StartsWith("VALIDATE"))
            {
                // get x,y,z and compare to report position
                string[] validatePos = cmd.Split(' ');
                if (validatePos[1] == ReportPosition())
                {
                    result = "VALIDATION SUCCESS";
                    Console.WriteLine(result);
                }
                else
                {
                    result = "VALIDATION FAILED";
                    Console.WriteLine(result);
                }
            }
            return result;
        }

        public void PlaceRobot(int x, int y, Facing direction)
        {
            currentPosition.X = x;
            currentPosition.Y = y;
            currentPosition.Direction = direction;
        }

        public void RotateLeft()
        {
            // switch case to rotate anticlockwise ie. West to South
            switch (currentPosition.Direction)
            {
                case Facing.NORTH:
                    currentPosition.Direction = Facing.WEST;
                    break;
                case Facing.WEST:
                    currentPosition.Direction = Facing.SOUTH;
                    break;
                case Facing.SOUTH:
                    currentPosition.Direction = Facing.EAST;
                    break;
                case Facing.EAST:
                    currentPosition.Direction = Facing.NORTH;
                    break;
            }
        }
        public void RotateRight()
        {
            // switch case to rotate clockwise
            switch (currentPosition.Direction)
            {
                case Facing.NORTH:
                    currentPosition.Direction = Facing.EAST;
                    break;
                case Facing.EAST:
                    currentPosition.Direction = Facing.SOUTH;
                    break;
                case Facing.SOUTH:
                    currentPosition.Direction = Facing.WEST;
                    break;
                case Facing.WEST:
                    currentPosition.Direction = Facing.NORTH;
                    break;
            }
        }
        public void MoveForward()
        {
            // temp variable to hold x,y
            int tempX = currentPosition.X;
            int tempY = currentPosition.Y;

            // incre position in current direction if valid position ie. On the 5x5 board
            switch (currentPosition.Direction)
            {
                case Facing.NORTH:
                    tempY++;
                    if (tempY < currentBoard.Height)
                    {
                        currentPosition.Y++;
                    }
                    break;
                case Facing.EAST:
                    tempX++;
                    if (tempX < currentBoard.Length)
                    {
                        currentPosition.X++;
                    }
                    break;
                case Facing.SOUTH:
                    tempY--;
                    if (tempY >= 0)
                    {
                        currentPosition.Y--;
                    }
                    break;
                case Facing.WEST:
                    tempX--;
                    if (tempX >= 0)
                    {
                        currentPosition.X--;
                    }
                    break;

            }
        }
        public string ReportPosition()
        {
            // return toy robots current x,y,facing coords
            if(currentPosition.X != -1 || currentPosition.Y != -1)
            {
                return currentPosition.X.ToString() + ","
                + currentPosition.Y.ToString() + ","
                + Enum.GetName(currentPosition.Direction.GetType(), currentPosition.Direction);
            }
            return "Robot not placed";

        }

        // converts Enum to string
        public static string ConvertToString(Facing direction)
        {
            return Enum.GetName(direction.GetType(), direction);
        }

        // converts String to Enum
        public static Facing ConvertToEnum<Facing>(String enumValue)
        {
            return (Facing)Enum.Parse(typeof(Facing), enumValue);
        }

        public bool isValidPosition(int xPlace, int yPlace, Facing direction)
        {
            bool isValid = false;
            // check if place position is possible
            if((xPlace > -1 && xPlace < currentBoard.Length) && (yPlace > -1 && yPlace < currentBoard.Height))
            {
                // check if direction is a valid direction
                if (isValidDirection(direction))
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        public bool isValidDirection(Facing direction)
        {
            bool isValid = false;
            if (Enum.IsDefined(typeof(Facing), direction))
            {
                isValid = true;
            }
            return isValid;
        }
    }

}