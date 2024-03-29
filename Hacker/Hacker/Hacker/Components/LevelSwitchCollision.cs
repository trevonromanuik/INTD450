﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Extensions;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Levels;
using Hacker.Screens;
using Hacker.Transitions;

namespace Hacker.Components
{
    class LevelSwitchCollision<T> : PlayerCollision where T : Level, new()
    {
        Vector2 _newPlayerPosition;

        public LevelSwitchCollision(Vector2 newPlayerPosition)
        {
            _newPlayerPosition = newPlayerPosition;
        }

        public override void Collide()
        {
            var position = GetComponent<Position>();
            var sprite = GetComponent<Sprite>();

            Rectangle bounds = new Rectangle((int)position.X - (sprite.Width / 2), (int)position.Y - (sprite.Height / 2), sprite.Width, sprite.Height);

            var playerPosition = Player.Instance.GetComponent<Position>();
            var playerSprite = Player.Instance.GetComponent<Sprite>();
            var playerShadow = Player.Instance.GetComponent<Shadow>();

            Rectangle playerBounds = new Rectangle((int)playerPosition.X - (playerShadow.Width / 2), (int)playerPosition.Y + (playerSprite.Height / 2) - (playerShadow.Height / 2), playerShadow.Width, playerShadow.Height);

            Vector2 depth = playerBounds.GetIntersectionDepth(bounds);
            if (depth != Vector2.Zero)
            {
                GameScreen.LoadLevel<T>(new FadeTransition(_newPlayerPosition));
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
