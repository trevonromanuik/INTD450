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
    class Wedge : Npc
    {
        public Wedge()
            : base("Wedge", "179.245.40.160")
        {
            Id = "wedge";

            AddComponent(new Position(224, 640));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            AddComponent(new Sprite(AssetManager.LoadTexture("wedge")));

            AddComponent(new ConversationInteraction(new WedgeConversation(this, this.Name, this.IpAddress)));
            AddComponent(new Keyloggable("wedge"));
        }
    }
}
