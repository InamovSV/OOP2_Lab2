using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2.Items;
using Lab2.Robots;

namespace Lab2Test
{
    [TestClass]
    public class ItemTest
    {
        [TestMethod]
        public void SimpleItemTest()
        {
            var robot = new Worker();
            var item = new SimpleItem(100, 100);
            Assert.IsTrue(robot.TakeItem(item));
            Assert.AreEqual(robot.Cargo.Count, 1);
            Assert.AreEqual(robot.CurrentCapacity, 100);
            Assert.AreEqual(robot.Money, 100);
        }

        [TestMethod]
        public void ToxicItemTest()
        {
            var robot1 = new Kiborg();
            var item1 = new ToxicItem(100, 100);
            Assert.IsFalse(robot1.TakeItem(item1));
            Assert.AreEqual(robot1.Cargo.Count, 0);
            Assert.AreEqual(robot1.CurrentCapacity, 0);

            var robot2 = new Worker();
            var item2 = new ToxicItem(100, 100);
            Assert.IsTrue(robot2.TakeItem(item2));
            Assert.AreEqual(robot2.Cargo.Count, 1);
            Assert.AreEqual(robot2.CurrentCapacity, 100);
            Assert.AreEqual(robot2.Money, 100);
        }

        [TestMethod]
        public void SpoilableItemTest()
        {
            var robot = new Worker();
            var item = new SpoilableItem(100, 100, 10);
            robot.TakeItem(item);
            for (int i = 0; i < 11; i++)
            {
                robot.Move(Lab2.Game.MoveSide.Right);
            }
            try
            {
                Console.WriteLine(robot.Cargo[0].ToString());
                var res = (robot.Cargo[0] as SpoilableItem);

                Assert.IsTrue(res.IsSpoiled);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
