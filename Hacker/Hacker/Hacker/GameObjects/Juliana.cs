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
    class Juliana : Npc
    {
        public Juliana()
            : base("Juliana", "5678")
        {
            Id = "juliana";

            AddComponent(new Position(192, 320));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("juliana"), 64, 64, 0.3f, true));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("juliana"), 64, 64, 0.3f, true));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("juliana"), 64, 64, 0.3f, true));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("juliana"), 64, 64, 0.3f, true));
            sprite.PlayAnimation("down");
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new JulianaConversation(this, Name, IpAddress)));
        }
    }
}
