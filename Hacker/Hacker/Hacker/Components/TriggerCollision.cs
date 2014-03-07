using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Extensions;
using Hacker.GameObjects;

namespace Hacker.Components
{
    class TriggerCollision : PlayerCollision
    {
        private bool triggered;
        private Action action;

        public TriggerCollision(Action action)
        {
            this.triggered = false;
            this.action = action;
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
            if (depth == Vector2.Zero)
            {
                triggered = false;
            }
            else if (!triggered)
            {
                triggered = true;
                action();
            }
        }
    }
}
