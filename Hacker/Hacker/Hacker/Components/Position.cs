﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker;

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
            x += _position.X;
            y += _position.Y;

            // Do collision detection
            var collision = GetComponent<Collision>();
            var sprite = GetComponent<Sprite>();
            _position = collision.CheckCollision(
                new Vector2(x, y), 
                sprite.Width, 
                sprite.Height
            );
        }

        public void Teleport(float x, float y)
        {
            _position = new Vector2(x, y);
        }
    }
}
