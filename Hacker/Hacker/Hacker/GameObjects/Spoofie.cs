using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Components;
using Hacker.Conversations;
using Hacker.Managers;

namespace Hacker.GameObjects
{
    class Spoofie : Npc
    {
        public Spoofie()
            : base("Spoofie", "1.2.3.4")
        {
            Id = "spoofie";

            AddComponent(new Position(140, 60));
            AddComponent(new PlayerCollision());

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("spoofie_up"), 32, 32, 1, false));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("spoofie_down"), 32, 32, 1, false));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("spoofie_left"), 32, 32, 1, false));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("spoofie_right"), 32, 32, 1, false));
            sprite.PlayAnimation("down");
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new SpoofConversation(Name, IpAddress)));
        }
    }
}
