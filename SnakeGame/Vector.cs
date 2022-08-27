using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public struct  Vector
    {
        public float X { get; private set; }
        public float Y { get; private set; }

        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
