﻿using System;
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
    class MovementCollision : PlayerCollision
    {
        public override void Collide()
        {
            var position = GetComponent<Position>();
            var sprite = GetComponent<Sprite>();

            Rectangle bounds = new Rectangle((int)position.X - (sprite.Width / 2), (int)position.Y - (sprite.Height / 2), sprite.Width, sprite.Height);

            var playerPosition = Player.Instance.GetComponent<Position>();
            var playerSprite = Player.Instance.GetComponent<Sprite>();

            Rectangle playerBounds = new Rectangle((int)playerPosition.X - (playerSprite.Width / 2), (int)playerPosition.Y - (playerSprite.Height / 2), playerSprite.Width, playerSprite.Height);

            Vector2 depth = playerBounds.GetIntersectionDepth(bounds);
            if (depth != Vector2.Zero)
            {
                float absDepthX = Math.Abs(depth.X);
                float absDepthY = Math.Abs(depth.Y);

                if (absDepthY < absDepthX)
                {
                    playerPosition.Y += depth.Y;
                }
                else
                {
                    playerPosition.X += depth.X;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
