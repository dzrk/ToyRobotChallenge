using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ToyRobotChallenge.ToyRobot;
using static ToyRobotChallenge.Position;

namespace ToyRobotChallenge.UnitTests
{
    [TestClass]
    public class ToyRobotTests
    {
        [TestMethod]
        public void PlaceRobot_CorrectPosition_ReturnsTrue()
        {
            var toyRobot = new ToyRobot();
            int x = 1;
            int y = 2;
            Facing direction = Facing.NORTH;
            toyRobot.PlaceRobot(x, y, direction);

            Assert.AreEqual(expected: toyRobot.CurrentPosition.X, actual: x);
            Assert.AreEqual(expected: toyRobot.CurrentPosition.Y, actual: y);
            Assert.AreEqual(expected: toyRobot.CurrentPosition.Direction, actual: direction);

        }

        public void PlaceRobot_CorrectPosition_ReturnsTrue(ToyRobot toyRobot, int x, int y, Facing direction)
        {
            toyRobot.PlaceRobot(x, y, direction);

            Assert.AreEqual(expected: toyRobot.CurrentPosition.X, actual: x);
            Assert.AreEqual(expected: toyRobot.CurrentPosition.Y, actual: y);
            Assert.AreEqual(expected: toyRobot.CurrentPosition.Direction, actual: direction);

        }

        [TestMethod]
        public void PlaceRobot_CorrectPositionWhenPlacedMultipleTimesWithinBoard_ReturnsTrue()
        {
            var board = new Board();
            var toyRobot = new ToyRobot();
            // init robot placement and board
            toyRobot.Execute("PLACE 1,2,EAST", board);

            var boardHeight = toyRobot.CurrentBoard.Height;
            var boardLength = toyRobot.CurrentBoard.Length;
            var dirCount = Enum.GetNames(typeof(Facing)).Length;

            for (int x=0; x < boardLength; x++) {
                for(int y=0; y < boardHeight; y++)
                {
                    for(int z=0; z < dirCount; z++)
                    {
                        PlaceRobot_CorrectPosition_ReturnsTrue(toyRobot, x, y, (Facing)z);
                    }
          
                }
                
            }
        }

        [TestMethod]
        public void MoveRobot_MovingUpAndCheckBounds_ReturnsTrue()
        {
            var board = new Board();
            var toyRobot = new ToyRobot();
            // placing robot at 1,2,NORTH
            toyRobot.Execute("PLACE 1,2,NORTH", board);

            // moves to 1,3
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.CurrentPosition.X, actual: 1);
            Assert.AreEqual(expected: toyRobot.CurrentPosition.Y, actual: 3);

            // moves to 1,4
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.CurrentPosition.X, actual: 1);
            Assert.AreEqual(expected: toyRobot.CurrentPosition.Y, actual: 4);

            // moves to 1,4
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.CurrentPosition.X, actual: 1);
            Assert.AreEqual(expected: toyRobot.CurrentPosition.Y, actual: 4);

            // moves to 1,4
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.CurrentPosition.X, actual: 1);
            Assert.AreEqual(expected: toyRobot.CurrentPosition.Y, actual: 4);

        }

        [TestMethod]
        public void MoveRobot_MovingRightAndCheckBounds_ReturnsTrue()
        {
            var board = new Board();
            var toyRobot = new ToyRobot();
            // placing robot at 1,2,EAST
            toyRobot.Execute("PLACE 1,2,EAST", board);

            // moves to 2,2
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.CurrentPosition.X, actual: 2);
            Assert.AreEqual(expected: toyRobot.CurrentPosition.Y, actual: 2);

            // moves to 3,2
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.CurrentPosition.X, actual: 3);
            Assert.AreEqual(expected: toyRobot.CurrentPosition.Y, actual: 2);

            // moves to 4,2
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.CurrentPosition.X, actual: 4);
            Assert.AreEqual(expected: toyRobot.CurrentPosition.Y, actual: 2);

            // moves to 4,2
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.CurrentPosition.X, actual: 4);
            Assert.AreEqual(expected: toyRobot.CurrentPosition.Y, actual: 2);

            // moves to 4,2
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.CurrentPosition.X, actual: 4);
            Assert.AreEqual(expected: toyRobot.CurrentPosition.Y, actual: 2);

        }

        private static void RotateLeft_AtSpecificBoardPositions_ReturnsTrue(ToyRobot robot, int x, int y)
        {
            // defaults at NORTH
            robot.RotateLeft();
            Assert.AreEqual(expected: robot.CurrentPosition.Direction, actual: Facing.WEST);
            Assert.AreEqual(expected: robot.CurrentPosition.X, actual: x);
            Assert.AreEqual(expected: robot.CurrentPosition.Y, actual: y);

            robot.RotateLeft();
            Assert.AreEqual(expected: robot.CurrentPosition.Direction, actual: Facing.SOUTH);
            Assert.AreEqual(expected: robot.CurrentPosition.X, actual: x);
            Assert.AreEqual(expected: robot.CurrentPosition.Y, actual: y);

            robot.RotateLeft();
            Assert.AreEqual(expected: robot.CurrentPosition.Direction, actual: Facing.EAST);
            Assert.AreEqual(expected: robot.CurrentPosition.X, actual: x);
            Assert.AreEqual(expected: robot.CurrentPosition.Y, actual: y);

            robot.RotateLeft();
            Assert.AreEqual(expected: robot.CurrentPosition.Direction, actual: Facing.NORTH);
            Assert.AreEqual(expected: robot.CurrentPosition.X, actual: x);
            Assert.AreEqual(expected: robot.CurrentPosition.Y, actual: y);
        }

        private static void RotateRight_AtSpecificBoardPositions_ReturnsTrue(ToyRobot robot, int x, int y)
        {
            // defaults at NORTH
            robot.RotateRight();
            Assert.AreEqual(expected: robot.CurrentPosition.Direction, actual: Facing.EAST);
            Assert.AreEqual(expected: robot.CurrentPosition.X, actual: x);
            Assert.AreEqual(expected: robot.CurrentPosition.Y, actual: y);

            robot.RotateRight();
            Assert.AreEqual(expected: robot.CurrentPosition.Direction, actual: Facing.SOUTH);
            Assert.AreEqual(expected: robot.CurrentPosition.X, actual: x);
            Assert.AreEqual(expected: robot.CurrentPosition.Y, actual: y);

            robot.RotateRight();
            Assert.AreEqual(expected: robot.CurrentPosition.Direction, actual: Facing.WEST);
            Assert.AreEqual(expected: robot.CurrentPosition.X, actual: x);
            Assert.AreEqual(expected: robot.CurrentPosition.Y, actual: y);

            robot.RotateRight();
            Assert.AreEqual(expected: robot.CurrentPosition.Direction, actual: Facing.NORTH);
            Assert.AreEqual(expected: robot.CurrentPosition.X, actual: x);
            Assert.AreEqual(expected: robot.CurrentPosition.Y, actual: y);
        }

        [TestMethod]
        public void RotateRight_AllValidBoardPositions_ReturnsTrue()
        {
            var board = new Board();
            var toyRobot = new ToyRobot();

            // init robot position and board
            toyRobot.Execute("PLACE 1,1,NORTH", board);

            var boardHeight = toyRobot.CurrentBoard.Height;
            var boardLength = toyRobot.CurrentBoard.Length;
            

            for (int x = 0; x < boardLength; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    toyRobot.Execute("PLACE "+ x +"," + y + ","+ Facing.NORTH, board);
                    RotateRight_AtSpecificBoardPositions_ReturnsTrue(toyRobot, x, y);
                }

            }
        }

        [TestMethod]
        public void RotateLeft_AllValidBoardPositions_ReturnsTrue()
        {
            var board = new Board();
            var toyRobot = new ToyRobot();

            // init robot position and board
            toyRobot.Execute("PLACE 1,1,NORTH", board);

            var boardHeight = toyRobot.CurrentBoard.Height;
            var boardLength = toyRobot.CurrentBoard.Length;



            for (int x = 0; x < boardLength; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    toyRobot.Execute("PLACE " + x + "," + y + "," + Facing.NORTH, board);
                    RotateLeft_AtSpecificBoardPositions_ReturnsTrue(toyRobot, x, y);
                }

            }
        }
    }
}
