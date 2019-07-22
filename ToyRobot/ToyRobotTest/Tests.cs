using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace ToyRobotTest
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void InvalidInputForPlaceTest()
        {
            TableSize tableSize = new TableSize();
            Robot robot = new Robot(tableSize);
            string result = robot.Command("PLACE /,-,NORTH");
            Assert.AreEqual(Robot.ExceptionMessage, result);
        }

        [TestMethod]
        public void InvalidInputCommandAfterPlaceTest()
        {
            TableSize tableSize = new TableSize();
            Robot robot = new Robot(tableSize);
            string result = robot.Command("PLACE 1,1,NORTH");
            result = robot.Command("INVALID");
            Assert.AreEqual(Robot.InvalidCommand, result);
        }

        [TestMethod]
        public void RobotPlacedSuccessfullyTest()
        {
            TableSize tableSize = new TableSize();
            Robot robot = new Robot(tableSize);
            string result = robot.Command("PLACE 0,0,NORTH");
            Assert.AreEqual(Robot.SuccessfulPlaceOrMove, result);
        }

        [TestMethod]
        public void RobotNotPlacedTest()
        {
            TableSize tableSize = new TableSize();
            Robot robot = new Robot(tableSize);
            string result = robot.Command("MOVE");
            Assert.AreEqual(Robot.RobotNotPlaced, result);
        }

        [TestMethod]
        public void RobotPlaceOutOfTest()
        {
            TableSize tableSize = new TableSize();
            Robot robot = new Robot(tableSize);
            string result = robot.Command("PLACE -1,-1,NORTH");
            Assert.AreEqual(Robot.OutOfBoundary, result);
        }

        [TestMethod]
        public void RobotPlaceMoveReportTest()
        {
            TableSize tableSize = new TableSize();
            Robot robot = new Robot(tableSize);
            string result = robot.Command("PLACE 0,0,NORTH");
            robot.Command("MOVE");
            result = robot.Command("REPORT");
            Assert.AreEqual("0,1,NORTH", result);
        }

        [TestMethod]
        public void RobotLeftReportTest()
        {
            TableSize tableSize = new TableSize();
            Robot robot = new Robot(tableSize);
            string result = robot.Command("PLACE 2,2,NORTH");
            robot.Command("LEFT");
            result = robot.Command("REPORT");
            Assert.AreEqual("2,2,WEST", result);
        }

        [TestMethod]
        public void RobotRightReportTest()
        {
            TableSize tableSize = new TableSize();
            Robot robot = new Robot(tableSize);
            string result = robot.Command("PLACE 2,2,NORTH");
            robot.Command("RIGHT");
            result = robot.Command("REPORT");
            Assert.AreEqual("2,2,EAST", result);
        }
    }
}
