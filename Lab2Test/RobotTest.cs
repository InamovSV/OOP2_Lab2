using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2.Items;
using Lab2.Robots;
using System.Collections.Generic;
using System.Linq;

namespace Lab2Test
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void WorkerTest()
        {
            var robot = new Worker();
            var rand = new Random();
            var items = new List<Item>(10).Select(x => new SimpleItem(rand.Next(0, 100), rand.Next(100)));
            foreach (var item in items)
            {
                robot.TakeItem(item);
            }

            var weight = robot.Cargo.Sum(x => x.Weight);
            Assert.IsTrue(weight <= robot.MaxCapacity);
            Assert.IsTrue(weight <= items.Sum(x => x.Weight) );

            var steps = rand.Next((int)robot.MaxCharge);
            for (int i = 0; i < steps; i++)
            {
                robot.Move(Lab2.Game.MoveSide.Down);
            }

            Assert.AreEqual(robot.Charge, robot.MaxCharge - steps);

        }

        [TestMethod]
        public void KiborgTest()
        {
            var robot = new Kiborg();
            var generator = new ItemGenerator(42, 42);
            var item = generator.GetToxicSpoiled(42,42, 5);

            Assert.IsFalse(robot.TakeItem(item));
            Assert.AreEqual(robot.Cargo.Count, 0);
            Assert.AreEqual(robot.CurrentCapacity, 0);
        }
    }
}
