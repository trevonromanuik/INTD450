using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Extensions;
using Hacker.Managers;

namespace Hacker.Components
{
    class RepeatingSprite : Sprite
    {
        private int rX;
        private int rY;

        public RepeatingSprite(Texture2D texture, int rX, int rY)
            : base(texture)
        {
            this.rX = rX;
            this.rY = rY;
        }

        public override int Width
        {
            get
            {
                return base.Width * rX;
            }
        }

        public override int Height
        {
            get
            {
                return base.Height * rY;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var position = GetComponent<Position>();
            if (position == null)
                return;

            var screenPosition = CameraManager.GetScreenPosition(new Vector2(position.X, position.Y));
            if (CameraManager.IsInCamera(screenPosition, Width, Height))
            {
                // Add to other draw functions
                float depth = MathHelper.Clamp(screenPosition.Y / 512, 0.0001f, 0.9999f);
                int left = (int)(screenPosition.X - Width / 2);
                int top = (int)(screenPosition.Y - Height / 2);
                for (var i = 0; i < rX; i++)
                {
                    for (var j = 0; j < rY; j++)
                    {
                        Rectangle dest = new Rectangle(
                            left + i * texture.Width,
                            top + j * texture.Height,
                            texture.Width, 
                            texture.Height);
                        spriteBatch.DrawZ(texture, dest, null, Color.White, depth);
                    }
                }
            }
        }
    }
}
