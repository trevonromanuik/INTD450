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
            : base("Juliana", "32.14.53.175")
        {
            Id = "juliana";

            AddComponent(new Position(320, 298));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("juliana_up"), 51, 64, 0.3f, true));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("juliana_down"), 53, 64, 0.3f, true));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("juliana_left"), 47, 64, 0.3f, true));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("juliana_right"), 43, 64, 0.3f, true));
            sprite.PlayAnimation("right");
            AddComponent(sprite);

            AddComponent(new Spoofable());
            AddComponent(new ConversationInteraction(new JulianaConversation(this, Name, IpAddress)));
        }
    }
}
