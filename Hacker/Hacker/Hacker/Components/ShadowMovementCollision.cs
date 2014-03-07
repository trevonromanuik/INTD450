using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Extensions;
using Hacker.GameObjects;
using Hacker.Layers;

namespace Hacker.Components
{
    class ShadowMovementCollision : MovementCollision
    {
        protected override Rectangle Bounds
        {
            get 
            {
                var position = GetComponent<Position>();
                var sprite = GetComponent<Sprite>();
                var shadow = GetComponent<Shadow>();

                return new Rectangle(
                    (int)position.X - (shadow.Width / 2), 
                    (int)position.Y + (sprite.Height / 2) - (shadow.Height / 2), 
                    shadow.Width, 
                    shadow.Height
                ); 
            }
        }
    }
}
