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
    class Parti1Conversation : Conversation
    {
        public Parti1Conversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {

            Messages.Add(new Message("Oh hello there, dear. What a lovely party your employer has thrown.", () => Player.Instance.SpoofId == "juliana"));
            Messages.Add(new Message("Lovely to see you again, Mr. Blackmoore. Each of your events is more impressive than the last.", () => Player.Instance.SpoofId == "blackmoore"));

            Messages.Add(new Message("Blackmoore Industries always hosts the most elaborate events on GlobeComm. For investors like us around the globe, it's an excellent opportunity to gather and discuss new technologies!", () => owner.GetIntegerVariable("count") % 3 == 0, () =>
            {
                owner.IncrementIntegerVariable("count");
            }));

            Messages.Add(new Message("I've attended every tech conference and launch event in the last eight months, but I don't recognize your avatar. Did you change it recently?", () => owner.GetIntegerVariable("count") % 3 == 1, () =>
            {
                owner.IncrementIntegerVariable("count");
            }));

            Messages.Add(new Message("Are you new? How did you receive your invite? As a leader in the development of new human-computer interfaces, it's natural that I'd be here, but I don't recognize you...", () => owner.GetIntegerVariable("count") % 3 == 2, () =>
            {
                owner.IncrementIntegerVariable("count");
            }));
        }
    }
}

namespace Hacker.GameObjects
{
    class NPC_Parti1 : Npc
    {
        public NPC_Parti1()
            : base("Xelha", string.Empty)
        {
            Id = "parti1";

            AddComponent(new Position(96, 608));
            AddComponent(new Shadow());
            AddComponent(new ShadowMovementCollision());

            AnimatedSprite sprite = new AnimatedSprite();
            sprite.AddAnimation("up", new Animation(AssetManager.LoadTexture("parti1_left"), 45, 59, 0.3f, true));
            sprite.AddAnimation("down", new Animation(AssetManager.LoadTexture("parti1_right"), 45, 59, 0.3f, true));
            sprite.AddAnimation("left", new Animation(AssetManager.LoadTexture("parti1_left"), 45, 59, 0.3f, true));
            sprite.AddAnimation("right", new Animation(AssetManager.LoadTexture("parti1_right"), 45, 59, 0.3f, true));
            sprite.PlayAnimation("right");
            AddComponent(sprite);

            AddComponent(new ConversationInteraction(new Parti1Conversation(this, this.Name, this.IpAddress)));
        }
    }
}
