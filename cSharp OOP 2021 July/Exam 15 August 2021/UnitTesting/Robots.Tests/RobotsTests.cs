namespace Robots.Tests
{
    using System;
    using NUnit.Framework;
    using Robots;
    using System.Linq;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void ConstrucotrValid()
        {
            Robot robot1 = new Robot("gosho", 33);
            RobotManager robot2 = new RobotManager(10);
            Assert.AreEqual(robot2.Capacity, 10);

            Assert.AreEqual(robot1.Battery, 33);
            Assert.AreEqual(robot1.MaximumBattery, 33);
            Assert.AreEqual(robot1.Name, "gosho");

        }
        [Test]
        public void SetCapacityThrowExc()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-1));
            Assert.Throws<ArgumentException>(() => new RobotManager(-3331));
        }
        [Test]
        public void AddInvalidArguments()
        {
            RobotManager robot = new RobotManager(3);
            robot.Add(new Robot("gosho", 5));
            Assert.Throws<InvalidOperationException>(() => robot.Add(new Robot("gosho", 10)));
            Assert.AreEqual(robot.Count, 1);                        
        }

        [Test]
        public void AddInvalidArgumentsCapacity()
        {
            RobotManager robot = new RobotManager(2);
            robot.Add(new Robot("gosho", 5));
            robot.Add(new Robot("pesho", 5));
            Assert.AreEqual(robot.Count, 2);
            Assert.Throws<InvalidOperationException>(() => robot.Add(new Robot("ivan", 30)));
        }

        [Test]
        public void AddValidArgumentsCapacity()
        {
            RobotManager robot = new RobotManager(10);
            robot.Add(new Robot("gosho", 5));
            robot.Add(new Robot("pesho", 5));
            robot.Add(new Robot("ivan", 30));
            Assert.AreEqual(robot.Count, 3);           
        }

        [Test]
        public void RemoveThrowsExc()
        {
            RobotManager robot = new RobotManager(10);
            Assert.Throws<InvalidOperationException>(() => robot.Remove(null));
        }

        [Test]
        public void RemoveWorks()
        {
            RobotManager robot = new RobotManager(10);
            robot.Add(new Robot("gosho", 5));
            robot.Add(new Robot("pesho", 5));
            robot.Remove("gosho");
            Assert.AreEqual(robot.Count, 1);
        }

        [Test]
        public void WorkThrowsExc()
        {
            RobotManager robot = new RobotManager(10);
            
            Assert.Throws<InvalidOperationException>(()=> robot.Work(null, "4ista4", 33));
        }

        [Test]
        public void WorkThrowsExc2()
        {
            RobotManager robot = new RobotManager(10);
            robot.Add(new Robot("gosho", 5));
            robot.Add(new Robot("pesho", 5));
            Assert.Throws<InvalidOperationException>(() => robot.Work("gosho", "4ista4", 10));
        }

        [Test]
        public void ThisMethodWorksWork()
        {
            RobotManager robot = new RobotManager(10);
            Robot gosho = new Robot("gosho", 5);
            robot.Add(gosho);
            robot.Work("gosho", "4ista4", 2);
            Assert.AreEqual(gosho.Battery, 3);
        }

        [Test]
        public void ChargeThrowsException()
        {
            RobotManager robot = new RobotManager(10);
            Robot gosho = new Robot("gosho", 5);
            Assert.Throws<InvalidOperationException>(() => robot.Charge(null));
        }

        [Test]
        public void ChargeWorks()
        {
            RobotManager robot = new RobotManager(10);
            Robot gosho = new Robot("gosho", 5);
            robot.Add(gosho);
            robot.Work("gosho", "4ista4", 2);

            robot.Charge("gosho");
            Assert.AreEqual(gosho.Battery, gosho.MaximumBattery);
        }
    }
}
