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
            : base("Ryan Blackmoore", "74.128.225.96")
        {
            Id = "spoofie";

            AddComponent(new Position(480, 352));
            AddComponent(new Shadow());
            AddComponent(new MovementCollision());

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("spoofie_up"), 64, 64, 1, false));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("spoofie_down"), 64, 64, 1, false));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("spoofie_left"), 64, 64, 1, false));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("spoofie_right"), 64, 64, 1, false));
            sprite.PlayAnimation("down");
            AddComponent(sprite);

            AddComponent(new DDOSable());
            AddComponent(new ConversationInteraction(new SpoofConversation(this, Name, IpAddress)));
        }
    }
}
