using Graphics;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            World world = new World();
            using (var game = new GameWindow(400, 400))
            {
                game.Load += (sender, e) =>
                    {
                        game.VSync = VSyncMode.On;
                        GL.MatrixMode(MatrixMode.Projection);
                        GL.LoadIdentity();
                        GL.Ortho(0, game.Width, game.Height, 0, 0.0, 0.0);
                    };

                game.Resize += (sender, e) =>
                    {
                        GL.Viewport(0, 0, game.Width, game.Height);
                    };

                game.UpdateFrame += (sender, e) =>
                    {
                        if (game.Keyboard[Key.Escape])
                            game.Exit();
                        world.Update();
                    };

                game.RenderFrame += (sender, e) =>
                    {
                        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                        GL.Ortho(0, game.Width, game.Height, 0, -1, 1);

                        GL.MatrixMode(MatrixMode.Modelview);
                        GL.LoadIdentity();

                        GL.Begin(PrimitiveType.LineLoop);
                        GL.Color3(Color.Pink);
                        GL.Vertex2(0, 0);
                        GL.Vertex2(400, 400);
                        GL.End();

                        world.Render();
                        game.SwapBuffers();
                    };

                game.Run(60.0);
            }
        }
    }
}