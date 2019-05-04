using Microsoft.VisualStudio.TestTools.UnitTesting;
using myDNA.Robot;
using myDNA.Robot.Interfaces;
using myDNA.Robot.Services;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        readonly IRobotPosition _Handler;

        public UnitTest1()
        {

            _Handler = new RobotPositionService();
        }
        [TestMethod]
        public void TestPlace()
        {
            _Handler.place(1, 2, "North");
             Assert.AreEqual("1,2,North", _Handler.report());
        }

        [TestMethod]
        public void TestReport()
        {
            _Handler.place(2, 2, "North");
            Assert.AreEqual("2,2,North", _Handler.report());    
        }
        
        [TestMethod]
        public void TestMove()
        {
            _Handler.place(1, 2, "North");
            _Handler.move();
            Assert.AreEqual("1,3,North", _Handler.report());       
        }

        [TestMethod]
        public void TestLeft()
        {
            _Handler.place(1, 2, "North");
            _Handler.left();
            Assert.AreEqual("1,2,West", _Handler.report());
        }

        [TestMethod]
        public void TestRight()
        {
            _Handler.place(1, 2, "North");
            _Handler.right();
            Assert.AreEqual("1,2,East", _Handler.report());

        }

        [TestMethod]
        public void TestMultiplePlace()
        {
            _Handler.place(1, 2, "North");
            _Handler.place(2, 2, "West");
             Assert.AreEqual("2,2,West", _Handler.report());
        }

        [TestMethod]
        public void TestMoveOnBoundary()
        {
            _Handler.place(4, 4, "North");
            _Handler.move();
            Assert.AreEqual("4,4,North", _Handler.report());

            _Handler.place(0, 0, "South");
            _Handler.move();
            Assert.AreEqual("0,0,South", _Handler.report());

            _Handler.place(0, 0, "West");
            _Handler.move();
            Assert.AreEqual("0,0,West", _Handler.report());

            _Handler.place(4, 4, "East");
            _Handler.move();
            Assert.AreEqual("4,4,East", _Handler.report());
        }

        [TestMethod]
        public void Test_Place_Move_Report()
        {
            _Handler.place(0, 0, "North");
            _Handler.move();
            Assert.AreEqual("0,1,North", _Handler.report());
        }

        [TestMethod]
        public void Test_Place_left_report()
        {
            _Handler.place(0, 0, "North");
            _Handler.left();
            Assert.AreEqual("0,0,West", _Handler.report());
        }

        [TestMethod]
        public void Test_Move_Move_Left_Move()
        {
            _Handler.place(1, 2, "East");
            _Handler.move();
            _Handler.move();
            _Handler.left();
            _Handler.move();
            Assert.AreEqual("3,3,North", _Handler.report());
        }
    }
}
