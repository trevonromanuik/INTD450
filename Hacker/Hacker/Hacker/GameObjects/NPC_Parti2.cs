using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Components;
using Hacker.Conversations;
using Hacker.GameObjects;
using Hacker.Managers;

namespace Hacker.Conversations
{
    class Parti2Conversation : Conversation
    {
        public Parti2Conversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            Messages.Add(new Message("You're quite the cyber fashionista, Miss Juliana. Did you have your avatar's shoes custom designed?", () => Player.Instance.SpoofId == "juliana"));
            Messages.Add(new Message("Hello again, Mr. Blackmoore. My husband and I will certainly be investing in your new technology.", () => Player.Instance.SpoofId == "blackmoore"));

            Messages.Add(new Message("I adore the color of your avatar! Jaune is so in style this cyber season. I see you think like I do; an avatar with a hidden face is very incognito-chique! ", () => owner.GetIntegerVariable("count") % 3 == 0, () =>
            {
                owner.IncrementIntegerVariable("count");
            }));

            Messages.Add(new Message("Being able to buy a talent you've always wanted, and express it immediately without practice? What an amazing invention.", () => owner.GetIntegerVariable("count") % 3 == 1, () =>
            {
                owner.IncrementIntegerVariable("count");
            }));

            Messages.Add(new Message("I may need to invest in this technology for my husband's sake, if you catch my meaning...", () => owner.GetIntegerVariable("count") % 3 == 2, () =>
            {
                owner.IncrementIntegerVariable("count");
            }));
        }
    }
}

namespace Hacker.GameObjects
{
    class NPC_Parti2 : Npc
    {
        public NPC_Parti2()
            : base("Zecora", string.Empty)
        {
            Id = "parti2";

            AddComponent(new Position(800, 416));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("parti2_left"), 45, 65, 0.3f, true));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("parti2_right"), 45, 65, 0.3f, true));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("parti2_left"), 45, 65, 0.3f, true));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("parti2_right"), 45, 65, 0.3f, true));
            sprite.PlayAnimation("left");
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new Parti2Conversation(this, this.Name, this.IpAddress)));
        }
    }
}
