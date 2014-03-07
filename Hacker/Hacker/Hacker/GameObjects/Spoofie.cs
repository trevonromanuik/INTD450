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
            : base("Ryan Blackmoore", "1234")
        {
            Id = "spoofie";

            AddComponent(new Position(480, 576));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("spoofie_up"), 45, 59, 0.3f, true));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("spoofie_down"), 45, 59, 0.3f, true));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("spoofie_left"), 45, 59, 0.3f, true));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("spoofie_right"), 45, 59, 0.3f, true));
            sprite.PlayAnimation("down");
            AddComponent(sprite);

            AddComponent(new Keyloggable("guard_1"));
            AddComponent(new DDOSable());
            AddComponent(new ConversationInteraction(new SpoofConversation(this, Name, IpAddress)));
        }
    }
}
