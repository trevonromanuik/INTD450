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
    class Bouncer : GameObject
    {
        public Bouncer()
        {
            Id = "bouncer";

            AddComponent(new Position(576, 244));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(    AssetManager.LoadTexture("bouncer_red"), 102, 90, 0.3f, true));
            sprite.AddAnimation("down", new Animation(  AssetManager.LoadTexture("bouncer_red"), 102, 90, 0.3f, true));
            sprite.AddAnimation("left", new Animation(  AssetManager.LoadTexture("bouncer_red"), 102, 90, 0.3f, true));
            sprite.AddAnimation("right", new Animation( AssetManager.LoadTexture("bouncer_red"), 102, 90, 0.3f, true));
            sprite.PlayAnimation("down");
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new BouncerConversation(this, "Bouncer Protocol", string.Empty)));
        }
    }
}
