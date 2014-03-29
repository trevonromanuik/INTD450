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
    class WallTerminal : GameObject
    {
        public WallTerminal(int x, int y)
        {
            AddComponent(new Position(x, y));
            AddComponent(new Sprite(AssetManager.LoadTexture("wall_terminal")));

            AddComponent(new ConversationInteraction(new WallTerminalConversation(this, "Terminal", string.Empty)));
        }
    }
}
