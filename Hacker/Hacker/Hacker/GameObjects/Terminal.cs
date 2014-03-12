using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Conversations;
using Hacker.Components;
using Hacker.Extensions;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Levels;
using Hacker.Managers;

namespace Hacker.GameObjects
{
    class Terminal : GameObject
    {
        public Terminal()
        {
            Id = "terminal";

            AddComponent(new Position(320, 160));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            Sprite sprite = new Sprite(AssetManager.LoadTexture("terminal"));
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new TerminalConversation(this, "Terminal", string.Empty)));
        }
    }
}
