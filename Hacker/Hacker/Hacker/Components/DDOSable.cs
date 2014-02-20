using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Managers;

namespace Hacker.Components
{
    class DDOSable : Component
    {
        public bool Enabled { get; private set; }
        private Texture2D ddosTexture;

        public DDOSable()
        {
            Enabled = false;
            ddosTexture = AssetManager.LoadTexture("ddos");
        }

        public void DDOS()
        {
            Enabled = true;
        }

        public void UnDDOS()
        {
            Enabled = false;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Enabled)
            {
                var position = GetComponent<Position>();
                var sprite = GetComponent<Sprite>();
                var _position = new Vector2(position.X - sprite.Width / 2, position.Y - sprite.Height / 2);
                _position = CameraManager.GetScreenPosition(_position);
                if (CameraManager.IsInCamera(_position, ddosTexture.Width, ddosTexture.Height))
                {
                    spriteBatch.Draw(ddosTexture, _position, Color.White);
                }
            }
        }
    }
}
