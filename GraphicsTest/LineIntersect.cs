using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphics;
using OpenTK;

namespace GraphicsTest
{
    [TestClass]
    public class LineIntersect
    {
        [TestMethod]
        public void IntersectingLines()
        {
            var line1 = new Line(0, 0, 5, 5);
            var line2 = new Line(5, 5, 5, 0);

            Assert.IsTrue(line1.Intersects(line2));
        }

        [TestMethod]
        public void ParallelLines()
        {
            var line1 = new Line(0, 0, 5, 5);
            var line2 = new Line(0, 5, 5, 10);

            Assert.IsFalse(line1.Intersects(line2));
        }

        [TestMethod]
        public void NonIntersectingLines()
        {
            var line1 = new Line(0, 0, 5, 5);
            var line2 = new Line(0, 5, 5, 7);

            Assert.IsFalse(line1.Intersects(line2));
        }

        [TestMethod]
        public void IntersectingLinesWithPoint()
        {
            Vector2 result;
            var line1 = new Line(0, 0, 5, 5);
            var line2 = new Line(5, 5, 5, 0);

            var intersect = line1.Intersects(line2, out result);

            Assert.IsTrue(result.Y == 5 && result.X == 5 && intersect);
        }

        [TestMethod]
        public void ParallelLinesWithPoint()
        {
            Vector2 result;
            var line1 = new Line(0, 0, 5, 5);
            var line2 = new Line(0, 5, 5, 10);

            Assert.IsFalse(line1.Intersects(line2, out result));
        }

        [TestMethod]
        public void NonIntersectingLinesWithPoint()
        {
            Vector2 result;
            var line1 = new Line(0, 0, 5, 5);
            var line2 = new Line(0, 5, 5, 7);

            Assert.IsFalse(line1.Intersects(line2, out result));
        }
    }
}
