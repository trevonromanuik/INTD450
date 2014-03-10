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
    class NPC_SailorMoon : Npc
    {
        public NPC_SailorMoon()
            : base("Serena_MoonPrncss", "199.23.122.69")
        {
            Id = "moon";

            AddComponent(new Position(544, 600));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("moon_left"), 45, 59, 0.3f, true));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("moon_right"), 45, 59, 0.3f, true));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("moon_left"), 45, 59, 0.3f, true));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("moon_right"), 45, 59, 0.3f, true));
            sprite.PlayAnimation("left");
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new SailorMoonConversation(this, this.Name, this.IpAddress)));
            AddComponent(new Keyloggable("moon"));
        }
    }
}
