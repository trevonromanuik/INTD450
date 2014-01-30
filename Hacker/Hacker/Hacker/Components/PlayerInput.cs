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
using Hacker.Levels;
using Hacker.Screens;

namespace Hacker.Components
{
    class PlayerInput : Component
    {
        private const float _speed = 3.0f;

        private KeyboardState _keyState;
        private KeyboardState _prevKeyState;

        public override void Update(GameTime gameTime)
        {
            var position = GetComponent<Position>();
            if (position == null)
                return;

            var sprite = GetComponent<AnimatedSprite>();
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

            switch (position.Direction)
            {
                case Direction.Up:
                    sprite.PlayAnimation("up");
                    break;
                case Direction.Down:
                    sprite.PlayAnimation("down");
                    break;
                case Direction.Left:
                    sprite.PlayAnimation("left");
                    break;
                case Direction.Right:
                    sprite.PlayAnimation("right");
                    break;
            }

            // check for tilde
            if (_prevKeyState != null && _prevKeyState.IsKeyUp(Keys.OemTilde)
                && _keyState.IsKeyDown(Keys.OemTilde))
            {
                GameScreen.Level.PushLayer(new ConsoleLayer());
            }

            // check for enter
            if (_prevKeyState != null && _prevKeyState.IsKeyUp(Keys.Enter)
                && _keyState.IsKeyDown(Keys.Enter))
            {
                foreach (GameObject gameObject in GameScreen.Level.GetLayer<MapLayer>().GameObjectManager.GameObjects)
                {
                    if (gameObject.Id != this.Owner.Id)
                    {
                        var _position = gameObject.GetComponent<Position>();
                        var interaction = gameObject.GetComponent<PlayerInteraction>();
                        if (_position != null && interaction != null)
                        {
                            float dx = _position.X - position.X;
                            float dy = -(_position.Y - position.Y);
                            double distance = Math.Sqrt(dx * dx + dy * dy);
                            if (distance < 100.0)
                            {
                                bool b = false;
                                double d;
                                switch (position.Direction)
                                {
                                    case Direction.Up:
                                        d = Math.Atan(dx / dy);
                                        b = (dy > 0 && (-0.52 < d && d < 0.52));
                                        break;
                                    case Direction.Down:
                                        d = Math.Atan(dx / dy);
                                        b = (dy < 0 && (-0.52 < d && d < 0.52));
                                        break;
                                    case Direction.Right:
                                        d = Math.Atan(dy / dx);
                                        b = (dx > 0 && (-0.52 < d && d < 0.52));
                                        break;
                                    case Direction.Left:
                                        d = Math.Atan(dy / dx);
                                        b = (dx < 0 && (-0.52 < d && d < 0.52));
                                        break;
                                }

                                if (b) interaction.Interact();
                            }
                        }
                    }
                }
            }

            _prevKeyState = _keyState;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
