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

            FileWriterHelper.writeFile("opening_message");
            SoundManager.PlaySound("seal", true, false);
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
