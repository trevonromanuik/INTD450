using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hacker.Components
{
    class PlayerInput : Component
    {
        private const float _speed = 2.0f;

        private KeyboardState _keyState;
        private KeyboardState _prevKeyState;

        public override void Update(GameTime gameTime)
        {
            var position = GetComponent<Position>();
            if (position == null)
                return;

            var sprite = GetComponent<Sprite>();
            if (sprite == null)
                return;

            _keyState = Keyboard.GetState();

            bool isUp = _keyState.IsKeyDown(Keys.Up);
            bool isDown = _keyState.IsKeyDown(Keys.Down);
            bool isLeft = _keyState.IsKeyDown(Keys.Left);
            bool isRight = _keyState.IsKeyDown(Keys.Right);

            var x = 0.0f;
            var y = 0.0f;

            if (isUp ^ isDown)
                y = isUp ? -_speed : _speed;

            if (isLeft ^ isRight)
                x = isLeft ? -_speed : _speed;

            position.Move(x, y);

            _prevKeyState = _keyState;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
