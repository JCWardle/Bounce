using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    public class Triangle : Shape
    {
        public Vector2 Point1 { get; set; }
        public Vector2 Point2 { get; set; }
        public Vector2 Point3 { get; set; }

        public void Render()
        {
            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color);
            GL.Vertex2(Point1);
            GL.Vertex2(Point2);
            GL.Vertex2(Point3);

            GL.End();
        }
    }
}
