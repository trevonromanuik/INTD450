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
    class InvisibleDoorSprite : Npc
    {
        public InvisibleDoorSprite()
            : base("Door", string.Empty)
        {
            Id = "invisibledoor";
            AddComponent(new Position(0,0));
            AddComponent(new Sprite(AssetManager.LoadTexture("invisible")));
            AddComponent(new ConversationInteraction(new InvisibleDoorConversation(this, this.Name, this.IpAddress)));
        }
    }
}
