using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    public class Shape
    {
        private static KnownColor[] _colorNames = (KnownColor[])Enum.GetValues(typeof(KnownColor));
        private static Random _random = new Random();
        public Vector2 Position;
        public Color Color;

        public Shape()
        {
            Color = Color.FromKnownColor(_colorNames[_random.Next(_colorNames.Length)]);
        }
    }
}
