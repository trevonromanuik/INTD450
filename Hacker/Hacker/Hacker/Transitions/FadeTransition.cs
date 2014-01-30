using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Levels;
using Hacker.Managers;

namespace Hacker.Transitions
{
    class FadeTransition : Transition
    {
        const double fadeTime = 0.5;
        double fadeTimer;
        bool fadeOut;

        float opacity;

        Texture2D blackTexture;

        Vector2 _newPlayerPosition;

        public FadeTransition(Vector2 newPlayerPosition)
        {
            fadeTimer = 0.0;
            fadeOut = true;

            opacity = 0.0f;

            blackTexture = AssetManager.LoadTexture("black");

            _newPlayerPosition = newPlayerPosition;
        }

        public override void Update(GameTime gameTime)
        {
            if (fadeOut)
            {
                fadeTimer += gameTime.ElapsedGameTime.TotalSeconds;
                opacity = (float)Math.Min(fadeTimer / fadeTime, 1.0);
                if (opacity == 1.0)
                {
                    Player.Instance.GetComponent<Position>().Teleport(_newPlayerPosition.X, _newPlayerPosition.Y);
                    fadeOut = false;
                }
            }
            else
            {
                fadeTimer -= gameTime.ElapsedGameTime.TotalSeconds;
                opacity = (float)Math.Max(fadeTimer / fadeTime, 0.0);
                if (opacity == 0.0)
                {
                    Done();
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (fadeOut)
            {
                _oldLevel.Draw(spriteBatch);
            }
            else
            {
                _newLevel.Draw(spriteBatch);
            }

            spriteBatch.Draw(blackTexture, new Rectangle(0, 0, spriteBatch.GraphicsDevice.Viewport.Width, spriteBatch.GraphicsDevice.Viewport.Height), Color.White * opacity);
        }
    }
}
