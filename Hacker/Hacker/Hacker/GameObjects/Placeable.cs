using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;

using Hacker.Components;

namespace Hacker.GameObjects
{
    class Placeable : GameObject
    {
        public Placeable(int x, int y, Texture2D texture)
        {
            AddComponent(new Position(x, y));
            AddComponent(new Sprite(texture));
            AddComponent(new MovementCollision());
        }

        public Placeable(string id, int x, int y, Texture2D texture)
            : this(x, y, texture)
        {
            this.Id = id;
        }
    }
}
