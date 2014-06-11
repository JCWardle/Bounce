using Graphics;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Ball
    {
        private static Random _random = new Random();

        private Circle _circle;
        private Vector2 _direction;
        private const float SPEED = 2.5f;
        private const int MIN_COORDS = -1;
        private const int MAX_COORDS = 1;
        private Line[] _hitbox;

        public Ball(float radius)
        {
            _circle = new Circle
            {
                Position = new Vector2 { X = 200, Y = 200},
                Radius = radius
            };

            var destination = new Vector2
            {
                X = _random.Next() * (MAX_COORDS - MIN_COORDS) + MIN_COORDS,
                Y = _random.Next() * (MAX_COORDS - MIN_COORDS) + MIN_COORDS
            };

            _direction = new Vector2
            {
                X = destination.X - _circle.Position.X,
                Y = destination.Y - _circle.Position.Y
            };

            var hypotenuse = Math.Sqrt(Math.Pow(_direction.X, 2) + Math.Pow(_direction.Y, 2));
            _direction.X /= (float)hypotenuse;
            _direction.Y /= (float)hypotenuse;

            CalculateHitBox();
        }

        public void Update()
        {
            _circle.Position.X += _direction.X * SPEED;
            _circle.Position.Y += _direction.Y * SPEED;

            CalculateHitBox();
        }

        public void Render()
        {
            _circle.Render();

            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(_circle.Position);
            GL.Vertex2(_circle.Position + _direction * 20);
            GL.End();
        }

        public void RenderHitBox()
        {
            foreach (var l in _hitbox)
                l.Render();
        }

        private void CalculateHitBox()
        {
            _hitbox = new Line[]{
                new Line(_circle.Position.X - _circle.Radius, _circle.Position.Y - _circle.Radius, _circle.Position.X +_circle.Radius, _circle.Position.Y - _circle.Radius),
                new Line(_circle.Position.X +_circle.Radius, _circle.Position.Y - _circle.Radius, _circle.Position.X + _circle.Radius, _circle.Position.Y - _circle.Radius),
                new Line(_circle.Position.X + _circle.Radius, _circle.Position.Y - _circle.Radius, _circle.Position.X + _circle.Radius, _circle.Position.Y + _circle.Radius),
                new Line(_circle.Position.X + _circle.Radius, _circle.Position.Y + _circle.Radius, _circle.Position.X - _circle.Radius, _circle.Position.Y + _circle.Radius)
                };
        }

        private Vector2? HitBoxCollidesWith(Triangle triangle)
        {
            var edge1 = new Line { Start = triangle.Point1, End = triangle.Point2 };
            var edge2 = new Line { Start = triangle.Point2, End = triangle.Point3 };
            var edge3 = new Line { Start = triangle.Point3, End = triangle.Point1 };
            Vector2 intersection;

            foreach(var l in _hitbox)
                if (l.Intersects(edge1, out intersection) || l.Intersects(edge2, out intersection) || l.Intersects(edge3, out intersection))
                    return intersection;

            return null;
        }

        internal void Bounce()
        {
            _direction = _direction.PerpendicularLeft;
        }

        internal void CollisionCheck(Triangle triangle)
        {
            var collision = HitBoxCollidesWith(triangle);
            if (collision != null && (_circle.Position - collision.Value).Length > _circle.Radius)
            {
                Bounce();
            }
        }
    }
}
