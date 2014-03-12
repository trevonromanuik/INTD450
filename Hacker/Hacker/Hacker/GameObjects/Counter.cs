using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Components;
using Hacker.Managers;

namespace Hacker.GameObjects
{
    class Counter : GameObject
    {
        public Counter(int left, int top, int rX)
        {
            var texture = AssetManager.LoadTexture("counter");

            AddComponent(new Position(
                left + (texture.Width * rX) / 2, 
                top + (texture.Height) / 2
            ));
            AddComponent(new RepeatingSprite(texture, rX, 1));
            AddComponent(new BoundedMovementCollision(new Rectangle(0, 32, 64 * rX, 32)));
        }
    }
}
