using Graphics;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class World
    {
        private Triangle _triangle;
        private List<Ball> _balls;
        public bool RenderHitBoxes { get; set; }

        public World()
        {
            _triangle = new Triangle() 
            { 
                Point1 = new Vector2(0, 0), 
                Point2 = new Vector2(200, 400), 
                Point3 = new Vector2(400, 0), 
                Position = new Vector2(0, 0), 
                Color = Color.White 
            };

            _balls = new List<Ball>();
            for (int i = 0; i < 1; i++)
                _balls.Add(new Ball(15));
        }

        public void Update()
        {
            foreach (var b in _balls)
            {
                b.Update();
                b.CollisionCheck(_triangle);
            }
            
        }

        public void Render()
        {
            _triangle.Render();

            if (RenderHitBoxes)
            {
                foreach (var b in _balls)
                {
                    b.Render();
                    b.RenderHitBox();
                }
            }
            else
            {
                foreach (var b in _balls)
                    b.Render();
            }

        }
    }
}
