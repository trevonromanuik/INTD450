using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Components;
using Hacker.Conversations;
using Hacker.Managers;

namespace Hacker.GameObjects
{
    class Bouncer : GameObject
    {
        public Bouncer()
        {
            Id = "bouncer";

            AddComponent(new Position(320, 128));
            AddComponent(new Shadow(128));
            AddComponent(new MovementCollision());

            Sprite sprite = new Sprite(AssetManager.LoadTexture("bouncer"));
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new BouncerConversation("Bouncer", string.Empty)));
        }
    }
}
