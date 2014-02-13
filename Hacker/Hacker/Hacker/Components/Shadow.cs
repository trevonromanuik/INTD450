using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Managers;

namespace Hacker.Components
{
    class Shadow : Component
    {
        private Texture2D shadowTexture;

        public Shadow()
        {
            shadowTexture = AssetManager.LoadTexture("shadow");
            Width = 64;
            Height = 32;
        }

        public Shadow(int width)
            : this()
        {
            Width = width;
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var position = GetComponent<Position>();
            if (position == null)
                return;

            var sprite = GetComponent<Sprite>();
            if (sprite == null)
                return;
            
            var _position = new Vector2(position.X, position.Y + sprite.Height / 2);

            var screenPosition = CameraManager.GetScreenPosition(_position);
            if (CameraManager.IsInCamera(screenPosition, Width, Height))
            {
                spriteBatch.Draw(shadowTexture, new Rectangle((int)(screenPosition.X - Width / 2), (int)(screenPosition.Y - Height / 2), Width, Height), Color.White);
            }
        }
    }
}
