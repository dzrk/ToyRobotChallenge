using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotChallenge
{
    public class Board
    {
        // properties of board
        int length;
        int height;
        List<Position> obstacleList;

        // board commands
        static string[] _commands = { "OBSTACLE", "VALIDATE", "ECHO"};

        public Board(int x = 5, int y = 5)
        {
            length = x;
            height = y;
            obstacleList = new List<Position>();

        }

        public int Length { get => length; set => length = value; }
        public int Height { get => height; set => height = value; }
        public List<Position> ObstacleList { get => obstacleList; set => obstacleList = value; }

        public static bool IsBoardCommand(string command)
        {
            // check if command in commands and ignores case
            return _commands.Any(s => command.IndexOf(s,StringComparison.OrdinalIgnoreCase)>=0);
        }
        
        public string Execute(string cmd, ToyRobot robot)
        {
            string result = "";
            if (cmd.StartsWith("echo"))
            {
                result = cmd.Substring(5);
            }
            else if (cmd.StartsWith(_commands[0]))
            {
                char[] delimChars = { ' ', ',' };
                string[] obsCmd = cmd.Split(delimChars);

                // creates obstacle and appends to obstacleList
                result = AddObstacle(Convert.ToInt32(obsCmd[1]), Convert.ToInt32(obsCmd[2]), robot);

            }
            else if (cmd.StartsWith(_commands[1]))
            {
                // get x,y,z and compare to report position
                string[] validatePos = cmd.Split(' ');
                if (validatePos[1] == robot.ReportPosition())
                {
                    result = "VALIDATION SUCCESS";
                }
                else
                {
                    result = "VALIDATION FAILED";
                }
            }

            Console.WriteLine(result);
            return result;
        }

        public string AddObstacle(int xObs, int yObs, ToyRobot robot)
        {
            string result = "";
            if (xObs != robot.CurrentPosition.X && yObs != robot.CurrentPosition.Y)
            {
                Position newObstacle = new Position(xObs, yObs, true);
                obstacleList.Add(newObstacle);
                result = "Added obstacle at " + xObs + ", " + yObs;
            }
            else
            {
                result = "Cannot place obstacle on robot";
            }

            return result;
        }
    }
}
