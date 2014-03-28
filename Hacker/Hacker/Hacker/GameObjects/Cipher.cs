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
    class Cipher : Npc
    {
        public Cipher()
            : base("Cipher", "NAN.NAN.NAN.NAN")
        {
            Id = "cipher";

            AddComponent(new Position(480, 192));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("cipher_up"), 45, 59, 0.3f, true));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("cipher_down"), 45, 59, 0.3f, true));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("cipher_left"), 45, 59, 0.3f, true));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("cipher_right"), 45, 59, 0.3f, true));
            sprite.PlayAnimation("down");
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new CipherConversation(this, this.Name, this.IpAddress)));
            AddComponent(new Keyloggable("cipher"));
        }
    }
}
