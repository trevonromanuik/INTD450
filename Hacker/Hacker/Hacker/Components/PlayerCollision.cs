using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Extensions;
using Hacker.Layers;

namespace Hacker.Components
{
    abstract class PlayerCollision : Component
    {
        public abstract void Collide();
    }
}
