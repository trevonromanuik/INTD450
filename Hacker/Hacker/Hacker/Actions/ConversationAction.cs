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
    class ConversationAction : Action
    {
        Conversation _conversation;

        public ConversationAction(Conversation conversation)
        {
            _conversation = conversation;
        }

        public override void Initialize(GameObject owner)
        {
        }

        public override void Update(GameTime gameTime)
        {
            GameScreen.Level.PushLayer(new ConversationLayer(_conversation));
            Done = true;
        }
    }
}
