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
    class Julianna : Npc
    {
        public Julianna()
            : base("Julianna", "5678")
        {
            Id = "julianna";

            AddComponent(new Position(192, 320));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("julianna"), 64, 64, 0.3f, true));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("julianna"), 64, 64, 0.3f, true));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("julianna"), 64, 64, 0.3f, true));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("julianna"), 64, 64, 0.3f, true));
            sprite.PlayAnimation("down");
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new JuliannaConversation(this, Name, IpAddress)));
        }
    }
}
