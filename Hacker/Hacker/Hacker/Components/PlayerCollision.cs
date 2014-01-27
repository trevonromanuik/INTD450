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
    class PlayerCollision : Component
    {
        public Vector2 CheckCollision(Vector2 position, int width, int height)
        {
            var _position = GetComponent<Position>();
            var sprite = GetComponent<Sprite>();

            Rectangle bounds = new Rectangle((int)position.X - (sprite.Width / 2), (int)position.Y - (sprite.Height / 2), sprite.Width, sprite.Height);

            Rectangle playerBounds = new Rectangle((int)_position.X - (width / 2), (int)_position.Y - (height / 2), width, height);

            Vector2 depth = bounds.GetIntersectionDepth(playerBounds);
            if (depth != Vector2.Zero)
            {
                float absDepthX = Math.Abs(depth.X);
                float absDepthY = Math.Abs(depth.Y);

                if (absDepthY < absDepthX)
                {
                    bounds.Y += (int)depth.Y;
                    position.Y += depth.Y;
                }
                else
                {
                    bounds.X += (int)depth.X;
                    position.X += depth.X;
                }
            }

            return position;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
