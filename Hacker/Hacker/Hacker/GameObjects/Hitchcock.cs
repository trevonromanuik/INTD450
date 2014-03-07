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
    class Hitchcock : Npc
    {
        public Hitchcock() 
            : base("Hitchcock", "44.89.43.33")
        {
            Id = "hitchcock";

            AddComponent(new Position(800, 768));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            AddComponent(new Sprite(AssetManager.LoadTexture("hitchcock")));

            AddComponent(new ConversationInteraction(new HitchcockConversation(this, this.Name, this.IpAddress)));
            AddComponent(new Keyloggable("hitchcock"));
        }
    }
}
