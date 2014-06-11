using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    public class Line
    {
        public Vector2 Start { get; set; }
        public Vector2 End { get; set; }

        public Line() { }

        public Line(int startX, int startY, int endX, int endY)
        {
            Start = new Vector2(startX, startY);
            End = new Vector2(endX, endY);
        }

        public Line(float startX, float startY, float endX, float endY)
        {
            Start = new Vector2(startX, startY);
            End = new Vector2(endX, endY);
        }

        public void Render()
        {
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(Start);
            GL.Vertex2(End);
            GL.End();
        }

        public bool Intersects(Line otherLine)
        {
            var l1 = End - Start;
            var l2 = otherLine.End - otherLine.Start;

            var s = (-l1.Y * (Start.X - otherLine.Start.X) + l1.X * (Start.Y - otherLine.Start.Y)) / (-l2.X * l1.Y + l1.X * l2.Y);
            var t = (l2.X * (Start.Y - otherLine.Start.Y) - l2.Y * (Start.X - otherLine.Start.X)) / (-l2.X * l1.Y + l1.X * l2.Y);

            return s >= 0 && s <= 1 && t >= 0 && t <= 1;
        }

        public bool Intersects(Line otherLine, out Vector2 intersection)
        {
            intersection = new Vector2();
            var l1 = End - Start;
            var l2 = otherLine.End - otherLine.Start;

            var s = (-l1.Y * (Start.X - otherLine.Start.X) + l1.X * (Start.Y - otherLine.Start.Y)) / (-l2.X * l1.Y + l1.X * l2.Y);
            var t = (l2.X * (Start.Y - otherLine.Start.Y) - l2.Y * (Start.X - otherLine.Start.X)) / (-l2.X * l1.Y + l1.X * l2.Y);

            if (s >= 0 && s <= 1 && t >= 0 && t <= 1)
            {
                intersection = new Vector2
                {
                    X = Start.X + (t * l1.X),
                    Y = Start.Y + (t * l1.Y)
                };
                return true;
            }

            return false;
        }
    }
}
