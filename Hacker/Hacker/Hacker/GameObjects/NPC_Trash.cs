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
    class NPC_Trash : Npc
    {
        public NPC_Trash()
            : base("Oscar_The_Grouch", string.Empty)
        {
            Id = "trash";

            AddComponent(new Position(416, 300));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            AddComponent(new Sprite(AssetManager.LoadTexture("trashcan")));

            AddComponent(new ConversationInteraction(new TrashConversation(this, this.Name, this.IpAddress)));
        }
    }
}
