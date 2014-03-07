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
    class Teller : GameObject
    {
        public Teller()
        {
            Id = "teller";

            AddComponent(new Position(732, 640));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            Sprite sprite = new Sprite(AssetManager.LoadTexture("teller"));
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new TellerConversation(this, "Teller", string.Empty)));
        }
    }
}
