using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Hacker.Components
{
    class BoundedMovementCollision : ShadowMovementCollision
    {
        private Rectangle bounds;
        protected override Rectangle Bounds
        {
            get
            {
                var position = GetComponent<Position>();
                var sprite = GetComponent<Sprite>();
                return new Rectangle(
                    (int)position.X - (sprite.Width / 2) + bounds.X,
                    (int)position.Y - (sprite.Height / 2) + bounds.Y,
                    bounds.Width,
                    bounds.Height
                ); 
            }
        }

        public BoundedMovementCollision(Rectangle bounds)
        {
            this.bounds = bounds;
        }
    }
}
