using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Conversations;
using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Managers;

namespace Hacker.GameObjects
{
    class OfficeTerminal : GameObject
    {
        public OfficeTerminal(int x, int y)
        {
            AddComponent(new Position(x, y));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());
            AddComponent(new Sprite(AssetManager.LoadTexture("terminalstand")));

            AddComponent(new ConversationInteraction(new OfficeTerminalConversation(this, "Terminal", string.Empty)));
        }
    }
}
