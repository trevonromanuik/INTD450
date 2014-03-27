using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Components;
using Hacker.Conversations;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Screens;

namespace Hacker.Actions
{
    class TransformAction : Action
    {
        private AnimatedSprite spriteOld, spriteNew, spriteFlip;
        GameObject transformer;

        private double time = 1;
        private double elapsedTime;

        private bool flip;
        private bool playerInputBefore;

        public TransformAction(AnimatedSprite spriteOld, AnimatedSprite spriteNew, GameObject transformer)
        {
            this.spriteOld = spriteOld;
            this.spriteNew = spriteNew;
            this.transformer = transformer;
            spriteFlip = new AnimatedSprite();
            getTransformSprites();
        }

        public override void Initialize(GameObject owner)
        {
            playerInputBefore = Player.Instance.GetComponent<PlayerInput>().Disabled;
            Player.Instance.GetComponent<PlayerInput>().Disabled = true;
            spriteOld.Animations = spriteFlip.Animations;
        }

        public override void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;

            if (flip)
            {
                spriteOld.PlayAnimation("old");
                flip = false;
            }
            else
            {
                spriteOld.PlayAnimation("new");
                flip = true;
            }

            if (elapsedTime / time > 1.0)
            {
                spriteOld.PlayAnimation("new");
                spriteOld.Animations = spriteNew.Animations;
                Player.Instance.GetComponent<PlayerInput>().Disabled = playerInputBefore;
                Done = true;
            }
        }

        public void getTransformSprites()
        {
            var pos = transformer.GetComponent<Position>();
            if (spriteOld.Animations.ContainsKey("up"))
            {
                switch (pos.Direction)
                {
                    case Direction.Up:
                        spriteFlip.AddAnimation("old", spriteOld.Animations["up"]);
                        spriteFlip.AddAnimation("new", spriteNew.Animations["up"]);
                        break;
                    case Direction.Down:
                        spriteFlip.AddAnimation("old", spriteOld.Animations["down"]);
                        spriteFlip.AddAnimation("new", spriteNew.Animations["down"]);
                        break;
                    case Direction.Left:
                        spriteFlip.AddAnimation("old", spriteOld.Animations["left"]);
                        spriteFlip.AddAnimation("new", spriteNew.Animations["left"]);
                        break;
                    case Direction.Right:
                        spriteFlip.AddAnimation("old", spriteOld.Animations["right"]);
                        spriteFlip.AddAnimation("new", spriteNew.Animations["right"]);
                        break;
                }
            }
            else
            {

                spriteFlip.AddAnimation("old", spriteOld.Animations["left"]);
                spriteFlip.AddAnimation("new", spriteNew.Animations["left"]);
            }
        }
    }
}
