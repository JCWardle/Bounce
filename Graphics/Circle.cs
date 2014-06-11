using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Graphics
{
    public class Circle : Shape
    {
        public float Radius;

        public void Render()
        {
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(Color);
            for (int i = 1; i <= 360; i++ )
            {
                var radians = (Math.PI / 180) * i;
                var x = (Radius) * Math.Cos(radians) + Position.X;
                var y = (Radius) * Math.Sin(radians) + Position.Y;
                GL.Vertex2(x, y);
            }

            GL.End();
        }
    }
}
