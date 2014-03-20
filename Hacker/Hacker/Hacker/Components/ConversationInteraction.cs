using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Hacker;
using Hacker.Helpers;
using Hacker.Conversations;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Levels;
using Hacker.Screens;
using Hacker.Managers;

namespace Hacker.Components
{
    class ConversationInteraction : PlayerInteraction
    {
        Conversation _conversation;
        public ConversationInteraction(Conversation conversation)
        {
            _conversation = conversation;
        }

        public override void Interact()
        {
            GameScreen.Level.PushLayer(
                new ConversationLayer(_conversation)
            );

            AnimatedSprite sprite = this.Owner.GetComponent<AnimatedSprite>();
            if (sprite != null)
            {
                var playerPos = Player.Instance.GetComponent<Position>();
                if (sprite.Animations.ContainsKey("up"))
                {
                    switch (playerPos.Direction)
                    {
                        case Direction.Up:
                            sprite.PlayAnimation("down");
                            break;
                        case Direction.Down:
                            sprite.PlayAnimation("up");
                            break;
                        case Direction.Left:
                            sprite.PlayAnimation("right");
                            break;
                        case Direction.Right:
                            sprite.PlayAnimation("left");
                            break;
                    }
                }
                else
                {
                    var thisPos = this.Owner.GetComponent<Position>();
                    var dx = playerPos.X - thisPos.X;
                    var dy = playerPos.Y - thisPos.Y;
                    if (playerPos.X < thisPos.X)
                        sprite.PlayAnimation("left");
                    else
                        sprite.PlayAnimation("right");
                }
            }
            //FileWriterHelper.writeFile("opening_message");
            //SoundManager.PlaySound("seal", true, false);
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
