using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Managers;

namespace Hacker.Components
{
    class Sprite : Component
    {
        private Texture2D _texture;
        public virtual int Width 
        {
            get { return _texture.Width; }
        }
        
        public virtual int Height 
        {
            get { return _texture.Height; }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
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
                spriteBatch.Draw(_texture, new Vector2(screenPosition.X - Width / 2, screenPosition.Y - Height / 2), Color.White);
            }
        }
    }
}
