using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hacker.Layers
{
    class CollisionLayer : Layer
    {
        public int[,] Collisions { get; private set; }

        public CollisionLayer(int[,] collisions)
        {
            Collisions = collisions;
        }
    }
}
