using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ToyRobotChallenge.UnitTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void CleanLine_CorrectPlaceCmd_ReturnsTrue()
        {
            var parser = new Parser();
            string input = "PLACE 1,1,NORTH";
            var actualLine = parser.CleanLine(input);
            var expectedLine = new List<string>();
            expectedLine.Add(input);

            CollectionAssert.AreEqual(expectedLine, actualLine);

        }

        [TestMethod]
        public void CleanLine_IncorrectPlaceCmd_ReturnsTrue()
        {
            var parser = new Parser();
            var actualLine = parser.CleanLine("PLaCE 1,1,NORTH");
            var expectedLine = new List<string>();

            CollectionAssert.AreEqual(expectedLine, actualLine);

        }

        [TestMethod]
        public void CleanLine_MultipleCmdsOnSameLine_ReturnsTrue()
        {
            var parser = new Parser();
            string input = "PLACE 4,1,WEST MOVE MOVE REPORT PLACE 4,1,WEST";
            var actualLine = parser.CleanLine(input);

            Assert.AreEqual(5, actualLine.Count);

        }

        [TestMethod]
        public void CleanLine_MutlipleCmdsOnSameLineWithUknownCmdsInbetween_ReturnsTrue()
        {
            var parser = new Parser();
            string input = "PLACE 4,1,WEST asdfsdaffg MOVE ddfadf dadfafddeef MOVE fdadfas REPORT RepORT PLACE PLACE PLACE 4,1,WEST asdfasdf";
            var actualLine = parser.CleanLine(input);

            Assert.AreEqual(5, actualLine.Count);


        }

    }
}
