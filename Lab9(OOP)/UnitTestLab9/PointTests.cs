using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using Lab9_OOP_;

namespace UnitTestLab9
{
    [TestClass]
    public class UnitTestL9
    {
        [TestMethod]
        public void ZeroDistanceTest()
        {
            //Arrange
            Point p1 = new Point();

            //Act
            float res = 0;

            //Assert
            Assert.AreEqual(p1.GetDistance(), res);
        }

        [TestMethod]
        public void PropertiesTest()
        {
            //Arrange
            Point p1 = new Point(15, -25);

            //Act
            Point p2 = new Point();
            p2.X = 15;
            p2.Y = -25;

            //Assert
            Assert.AreEqual((p1.X, p1.Y), (p2.X, p2.Y));
        }

        [TestMethod]
        public void StaticGetDistanceTest()
        {
            Point point = new Point(15, 25);
            Assert.AreEqual(Point.GetDistance(point), Math.Sqrt(15 * 15 + 25 * 25));
        }

        [TestMethod]
        public void DecrementTest()
        {
            Point p1 = new Point(-15, 25);
            Point p2 = new Point(-16, 24);

            p1--;
            Assert.AreEqual((p1.X, p1.Y), (p2.X, p2.Y));  
        }

        [TestMethod]
        public void UnarnOperTest()
        {
            Point p = new Point(15, 25);
            p = -p;
            Assert.AreEqual((p.X, p.Y), (25, 15));
        }

        [TestMethod]
        public void BinPITest()
        {
            Point p = new Point(15, 25);
            p = p - 5;
            Assert.AreEqual(p.X, 10);
        }

        [TestMethod]
        public void BinIPTest()
        {
            Point p = new Point(15, 25);
            p = 5 - p;
            Assert.AreEqual(p.Y, 20);
        }

        [TestMethod]
        public void BinPPTest()
        {
            Point p = new Point(15, 25);
            Point p2 = new Point();
            
            Assert.AreEqual(p - p2, p.GetDistance());
        }

        [TestMethod]
        public void ImplIntTest()
        {
            Point p = new Point(15.65, 25);
            int x = p;

            Assert.AreEqual(15, x);
        }

        [TestMethod]
        public void ExplDoubleTest()
        {
            Point p = new Point(15.65, 25.137);

            Assert.AreEqual(25.137, (double)p);
        }

    }
}
