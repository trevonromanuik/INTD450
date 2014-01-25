using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Hacker;
using Hacker.Conversations;
using Hacker.GameObjects;
using Hacker.Layers;

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

            if (x != 0 ^ y != 0)
            {
                if (x > 0) position.Direction = Direction.Right;
                else if (x < 0) position.Direction = Direction.Left;
                else if (y > 0) position.Direction = Direction.Down;
                else if (y < 0) position.Direction = Direction.Up;
            }

            position.Move(x, y);

            // check for tilde
            if (_prevKeyState != null && _prevKeyState.IsKeyUp(Keys.OemTilde)
                && _keyState.IsKeyDown(Keys.OemTilde))
            {
                MapLayer.Instance.Level.PushLayer(new ConsoleLayer());
            }

            // check for enter
            if (_prevKeyState != null && _prevKeyState.IsKeyUp(Keys.Enter)
                && _keyState.IsKeyDown(Keys.Enter))
            {
                foreach (GameObject gameObject in MapLayer.Instance.GameObjectManager.GameObjects)
                {
                    if (gameObject.Id != this.OwnerId)
                    {
                        var _position = gameObject.GetComponent<Position>();
                        if (_position != null)
                        {
                            float dx = position.X - _position.X;
                            float dy = position.Y - _position.Y;
                            double distance = Math.Sqrt(dx * dx + dy * dy);
                            if (distance < 100.0)
                            {
                                double direction = Math.Tan(dy / dx);
                                Console.WriteLine(direction);
                            }
                        }
                    }
                }

                /*MapLayer.Instance.Level.PushLayer(
                    new ConversationLayer(new SpoofConversation())
                );*/
            }

            _prevKeyState = _keyState;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
