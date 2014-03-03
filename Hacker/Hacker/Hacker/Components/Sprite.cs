using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Managers;
using Hacker.Extensions;
using Hacker.Screens;

namespace Hacker.Components
{
    class Sprite : Component
    {
        private Texture2D _texture;
        public virtual int Width { get; private set; }
        public virtual int Height { get; private set; }

        public Sprite(Texture2D texture)
        {
            _texture = texture;

            if (texture != null)
            {
                Width = _texture.Width;
                Height = _texture.Height;
            }
        }

        public Sprite(Texture2D texture, int width, int height)
        {
            _texture = texture;
            Width = width;
            Height = height;
        }

        public override void Update(GameTime gameTime)
        {
            
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
                Rectangle dest = new Rectangle(
                    (int)(screenPosition.X - Width / 2),
                    (int)(screenPosition.Y - Height / 2), 
                    Width, Height);
                spriteBatch.DrawZ(_texture, dest, null, Color.White, depth);
            }
        }
    }
}
