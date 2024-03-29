﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Components;
using Hacker.Conversations;
using Hacker.Managers;

namespace Hacker.GameObjects
{
    class Briggs : Npc
    {
        public Briggs()
            : base("Briggs", "174.23.148.69")
        {
            Id = "briggs";

            AddComponent(new Position(512, 928));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            var sprite = new AnimatedSprite();
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("briggs_left"), 45, 65, 1.0f, false));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("briggs_right"), 45, 65, 1.0f, false));
            sprite.PlayAnimation("left");
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new BriggsConversation(this, this.Name, this.IpAddress)));
            AddComponent(new Keyloggable("briggs"));
        }
    }
}
