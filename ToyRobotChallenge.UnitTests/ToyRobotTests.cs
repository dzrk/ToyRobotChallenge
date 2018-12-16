using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ToyRobotChallenge.ToyRobot;

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

            Assert.AreEqual(expected: toyRobot.X, actual: x);
            Assert.AreEqual(expected: toyRobot.Y, actual: y);
            Assert.AreEqual(expected: toyRobot.Direction, actual: direction);

        }

        public void PlaceRobot_CorrectPosition_ReturnsTrue(ToyRobot robot, int x, int y, Facing direction)
        {
            robot.PlaceRobot(x, y, direction);

            Assert.AreEqual(expected: robot.X, actual: x);
            Assert.AreEqual(expected: robot.Y, actual: y);
            Assert.AreEqual(expected: robot.Direction, actual: direction);

        }

        [TestMethod]
        public void PlaceRobot_CorrectPositionWhenPlacedMultipleTimesWithinBoard_ReturnsTrue()
        {
            var toyRobot = new ToyRobot();
            var boardHeight = toyRobot.BoardHeight;
            var boardLength = toyRobot.BoardLength;
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
            var toyRobot = new ToyRobot();
            // placing robot at 1,2,NORTH
            toyRobot.PlaceRobot(1, 2, Facing.NORTH);

            // moves to 1,3
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.X, actual: 1);
            Assert.AreEqual(expected: toyRobot.Y, actual: 3);

            // moves to 1,4
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.X, actual: 1);
            Assert.AreEqual(expected: toyRobot.Y, actual: 4);

            // moves to 1,5
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.X, actual: 1);
            Assert.AreEqual(expected: toyRobot.Y, actual: 5);

            // moves to 1,5
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.X, actual: 1);
            Assert.AreEqual(expected: toyRobot.Y, actual: 5);

        }

        [TestMethod]
        public void MoveRobot_MovingRightAndCheckBounds_ReturnsTrue()
        {
            var toyRobot = new ToyRobot();
            // placing robot at 1,2,EAST
            toyRobot.PlaceRobot(1, 2, Facing.EAST);

            // moves to 2,2
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.X, actual: 2);
            Assert.AreEqual(expected: toyRobot.Y, actual: 2);

            // moves to 3,2
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.X, actual: 3);
            Assert.AreEqual(expected: toyRobot.Y, actual: 2);

            // moves to 4,2
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.X, actual: 4);
            Assert.AreEqual(expected: toyRobot.Y, actual: 2);

            // moves to 5,2
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.X, actual: 5);
            Assert.AreEqual(expected: toyRobot.Y, actual: 2);

            // moves to 5,2
            toyRobot.MoveForward();
            Assert.AreEqual(expected: toyRobot.X, actual: 5);
            Assert.AreEqual(expected: toyRobot.Y, actual: 2);

        }

        private static void RotateLeft_AtSpecificBoardPositions_ReturnsTrue(ToyRobot robot, int x, int y)
        {
            // defaults at NORTH
            robot.RotateLeft();
            Assert.AreEqual(expected: robot.Direction, actual: Facing.WEST);
            Assert.AreEqual(expected: robot.X, actual: x);
            Assert.AreEqual(expected: robot.Y, actual: y);

            robot.RotateLeft();
            Assert.AreEqual(expected: robot.Direction, actual: Facing.SOUTH);
            Assert.AreEqual(expected: robot.X, actual: x);
            Assert.AreEqual(expected: robot.Y, actual: y);

            robot.RotateLeft();
            Assert.AreEqual(expected: robot.Direction, actual: Facing.EAST);
            Assert.AreEqual(expected: robot.X, actual: x);
            Assert.AreEqual(expected: robot.Y, actual: y);

            robot.RotateLeft();
            Assert.AreEqual(expected: robot.Direction, actual: Facing.NORTH);
            Assert.AreEqual(expected: robot.X, actual: x);
            Assert.AreEqual(expected: robot.Y, actual: y);
        }

        private static void RotateRight_AtSpecificBoardPositions_ReturnsTrue(ToyRobot robot, int x, int y)
        {
            // defaults at NORTH
            robot.RotateRight();
            Assert.AreEqual(expected: robot.Direction, actual: Facing.EAST);
            Assert.AreEqual(expected: robot.X, actual: x);
            Assert.AreEqual(expected: robot.Y, actual: y);

            robot.RotateRight();
            Assert.AreEqual(expected: robot.Direction, actual: Facing.SOUTH);
            Assert.AreEqual(expected: robot.X, actual: x);
            Assert.AreEqual(expected: robot.Y, actual: y);

            robot.RotateRight();
            Assert.AreEqual(expected: robot.Direction, actual: Facing.WEST);
            Assert.AreEqual(expected: robot.X, actual: x);
            Assert.AreEqual(expected: robot.Y, actual: y);

            robot.RotateRight();
            Assert.AreEqual(expected: robot.Direction, actual: Facing.NORTH);
            Assert.AreEqual(expected: robot.X, actual: x);
            Assert.AreEqual(expected: robot.Y, actual: y);
        }

        [TestMethod]
        public void RotateRight_AllValidBoardPositions_ReturnsTrue()
        {
            var toyRobot = new ToyRobot();
            var boardHeight = toyRobot.BoardHeight;
            var boardLength = toyRobot.BoardLength;

            for (int x = 0; x < boardLength; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    toyRobot.PlaceRobot(x, y, Facing.NORTH);
                    RotateRight_AtSpecificBoardPositions_ReturnsTrue(toyRobot, x, y);
                }

            }
        }

        [TestMethod]
        public void RotateLeft_AllValidBoardPositions_ReturnsTrue()
        {
            var toyRobot = new ToyRobot();
            var boardHeight = toyRobot.BoardHeight;
            var boardLength = toyRobot.BoardLength;

            for (int x = 0; x < boardLength; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    toyRobot.PlaceRobot(x, y, Facing.NORTH);
                    RotateLeft_AtSpecificBoardPositions_ReturnsTrue(toyRobot, x, y);
                }

            }
        }
    }
}
