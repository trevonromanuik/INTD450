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

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("anon_up"), 45, 53, 0.3f, true));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("anon_down"), 45, 53, 0.3f, true));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("anon_left"), 45, 53, 0.3f, true));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("anon_right"), 45, 53, 0.3f, true));
            sprite.PlayAnimation("down");
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new AnonConversation(this, "Anon", string.Empty)));
        }
    }
}
