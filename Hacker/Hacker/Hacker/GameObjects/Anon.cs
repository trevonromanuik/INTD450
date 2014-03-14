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
    class Anon : GameObject
    {
        public Anon()
        {
            Id = "anon";

            AddComponent(new Position(320, 256));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            Sprite sprite = new Sprite(AssetManager.LoadTexture("anon"));
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new AnonConversation(this, "Anon", string.Empty)));
        }
    }
}
