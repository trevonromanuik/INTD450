using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Hacker;
using Hacker.Extensions;
using Hacker.Conversations;
using Hacker.GameObjects;
using Hacker.Layers;

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
            MapLayer.Instance.Level.PushLayer(
                new ConversationLayer(_conversation)
            );

            var writer = new Extensions.FileWriterExtension();
            writer.writeFile("Messages/openingMessage");
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
