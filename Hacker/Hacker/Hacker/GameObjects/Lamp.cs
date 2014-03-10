using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Components;
using Hacker.Managers;

namespace Hacker.GameObjects
{
    class Lamp : GameObject
    {
        public Lamp(int x, int y)
        {
            AddComponent(new Position(x, y));
            AddComponent(new Sprite(AssetManager.LoadTexture("lam1p")));
            AddComponent(new BoundedMovementCollision(new Rectangle(0, 68, 20, 7)));
        }
    }
}
