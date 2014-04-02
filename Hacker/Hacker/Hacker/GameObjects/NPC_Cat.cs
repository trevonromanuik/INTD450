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
    class NPC_Cat : Npc
    {
        public NPC_Cat()
            : base("Meowsmith_2032", string.Empty)
        {
            Id = "cat";

            AddComponent(new Position(480, 600));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("cat_left"), 45, 59, 0.3f, true));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("cat_right"), 45, 59, 0.3f, true));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("cat_left"), 45, 59, 0.3f, true));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("cat_right"), 45, 59, 0.3f, true));
            sprite.PlayAnimation("right");
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new CatConversation(this, this.Name, this.IpAddress)));
        }
    }
}
