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
    class NPC_Mantis : Npc
    {
        public NPC_Mantis()
            : base("LuckyGuy88", string.Empty)
        {
            Id = "manty";

            AddComponent(new Position(640, 856));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("manty_left"), 45, 59, 0.3f, true));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("manty_right"), 45, 59, 0.3f, true));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("manty_left"), 45, 59, 0.3f, true));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("manty_right"), 45, 59, 0.3f, true));
            sprite.PlayAnimation("left");
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new MantisConversation(this, this.Name, this.IpAddress)));
        }
    }
}
