using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Components;
using Hacker.Conversations;
using Hacker.Managers;

namespace Hacker.GameObjects
{
    class HubTerminal : GameObject
    {
        public HubTerminal()
        {
            Id = "hub_terminal";

            AddComponent(new Position(320, 64));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            Sprite sprite = new Sprite(AssetManager.LoadTexture("terminalstand"));
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new HubTerminalConversation(this, "Terminal", string.Empty)));
        }
    }
}
