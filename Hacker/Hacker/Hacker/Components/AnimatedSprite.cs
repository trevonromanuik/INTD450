using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Managers;
using Hacker.Extensions;

namespace Hacker.Components
{
    class AnimatedSprite : Sprite
    {
        public Animation Animation { get; set; }

        public Dictionary<string, Animation> Animations { get; set; }
        private int _frameIndex;
        private double _time;
        private bool _frozen;

        public AnimatedSprite()
            : base(null)
        {
            Animations = new Dictionary<string, Animation>();
        }

        public void AddAnimation(string name, Animation animation)
        {
            Animations.Add(name, animation);
        }

        public void PlayAnimation(string name)
        {
            if (Animation == Animations[name])
                return;

            Animation test = Animations[name];
            if (test != null)
            {
                Animation = test;
                _frameIndex = 0;
                _time = 0.0f;
            }
        }

        public void Freeze()
        {
            _frozen = true;
        }

        public void Unfreeze()
        {
            _frozen = false;
        }

        public override int Width
        {
            get { return Animation.FrameWidth; }
        }

        public override int Height
        {
            get { return Animation.FrameHeight; }
        }

        public override void Update(GameTime gameTime)
        {
            if (Animation == null)
                throw new NotSupportedException("No animation is currently playing.");

            // Process passing time.
            // Only if not frozen.
            if (!_frozen)
            {
                _time += gameTime.ElapsedGameTime.TotalSeconds;
                while (_time > Animation.FrameTime)
                {
                    _time -= Animation.FrameTime;

                    // Advance the frame index; looping or clamping as appropriate.
                    if (Animation.IsLooping)
                    {
                        _frameIndex = (_frameIndex + 1) % Animation.FrameCount;
                    }
                    else
                    {
                        _frameIndex = Math.Min(_frameIndex + 1, Animation.FrameCount - 1);
                    }
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var position = GetComponent<Position>();
            if (position == null)
                return;

            int frameIndex = _frozen ? 0 : _frameIndex;

            var screenPosition = CameraManager.GetScreenPosition(new Vector2(position.X, position.Y));
            if (CameraManager.IsInCamera(screenPosition, Animation.FrameWidth, Animation.FrameHeight))
            {
                // Calculate the source rectangle of the current frame.
                Rectangle destination = new Rectangle(
                    (int)screenPosition.X - Animation.FrameWidth / 2,
                    (int)screenPosition.Y - Animation.FrameHeight / 2,
                    Animation.FrameWidth,
                    Animation.FrameHeight);

                Rectangle source = new Rectangle(
                    frameIndex * Animation.FrameWidth,
                    0,
                    Animation.FrameWidth,
                    Animation.FrameHeight);

                float depth = screenPosition.Y / 512;

                spriteBatch.DrawZ(Animation.Texture, destination, source, Color.White, depth);
            }
        }
    }
}
