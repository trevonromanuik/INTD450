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
    class NPC_Artist : Npc
    {
        public NPC_Artist()
            : base("Deviant_Picasso", string.Empty)
        {
            Id = "artist";

            // Artist is in the club and deep web and should stand in different places
            if (Player.Instance.GameCompleteState == GameCompleteState.DataBankComplete)
            {
                AddComponent(new Position(96, 224));
            }
            else
            {
                AddComponent(new Position(864, 672));
            }

            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("artsy_left"), 45, 59, 0.3f, true));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("artsy_right"), 45, 59, 0.3f, true));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("artsy_left"), 45, 59, 0.3f, true));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("artsy_right"), 45, 59, 0.3f, true));
            sprite.PlayAnimation("left");
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new ArtistConversation(this, this.Name, this.IpAddress)));
        }
    }
}
