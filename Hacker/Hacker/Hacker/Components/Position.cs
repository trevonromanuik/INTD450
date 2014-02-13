using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Levels;
using Hacker.Screens;

namespace Hacker.Components
{
    class Position : Component
    {
        private Vector2 _position;
        public Direction Direction { get; set; }

        public float X
        {
            get { return _position.X; }
            set { _position.X = value; }
        }

        public float Y
        {
            get { return _position.Y; }
            set { _position.Y = value; }
        }

        public Position(float x, float y)
        {
            _position = new Vector2(x, y);
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public void Move(float x, float y)
        {
            _position.X += x;
            _position.Y += y;

            // Do map collision detection
            var collision = GetComponent<Collision>();
            var sprite = GetComponent<Sprite>();
            var shadow = GetComponent<Shadow>();

            _position.Y = _position.Y + (sprite.Height / 2);

            _position = collision.CheckCollision(
                _position, 
                shadow.Width, 
                shadow.Height
            );

            _position.Y = _position.Y - (sprite.Height / 2);

            // Do gameobject collision detection
            foreach (GameObject gameObject in GameScreen.Level.GetLayer<MapLayer>().GameObjectManager.GameObjects)
            {
                var playerCollision = gameObject.GetComponent<PlayerCollision>();
                if (playerCollision != null)
                {
                    playerCollision.Collide();
                }
            }
        }

        public void Teleport(float x, float y)
        {
            _position = new Vector2(x, y);
        }
    }
}
