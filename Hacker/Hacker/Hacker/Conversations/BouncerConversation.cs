using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Actions;
using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Screens;

namespace Hacker.Conversations
{
    class BouncerConversation : Conversation
    {
        public BouncerConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            Message message0 = new Message("Have a wonderful day, Ms. Smith.", () => Player.Instance.SpoofId == "julianna" && owner.GetBooleanVariable("done"));
            Messages.Add(message0);

            Message message1 = new Message("Good evening Ms. Smith. Always a pleasure. Ready to answer the security questions?", () => Player.Instance.SpoofId == "julianna");
            InputMessage message11111 = new InputMessage("First question: what is Blackmoore's favorite food?");
            InputMessage message111111 = new InputMessage("Right. Ok, second question: what is Blackmoore's first dog's name?", () => message11111.Output == "caviar");
            InputMessage message1111111 = new InputMessage("Right. Ok, final question: what is Blackmoore's mother's maiden name?", () => message111111.Output == "winston");
            Message message11111111 = new Message("Perfect. Ok, go on in.", () => message1111111.Output == "rockefeller", () =>
            {
                owner.SetBooleanVariable("done", true);
                owner.AddAction(new MoveToAction(new Vector2(640, 244), 0.5));
            });

            Message message111112 = new Message("I'm sorry but that's wrong. Guess I can't let you in. Company policy.");

            message1111111.Messages.Add(message11111111);
            message1111111.Messages.Add(message111112);
            message111111.Messages.Add(message1111111);
            message111111.Messages.Add(message111112);
            message11111.Messages.Add(message111111);
            message11111.Messages.Add(message111112);
            message1.Messages.Add(message11111);
            Messages.Add(message1);

            Messages.Add(new Message("You're interested in the mindshare device, I assume? Mr. Blackmoore invited a few investors to discuss stocks and shares, but if  you don't have an invitation then you're not getting inside.", () => owner.GetIntegerVariable("count") % 3 == 0, () => owner.IncrementIntegerVariable("count")));
            Messages.Add(new Message("Investors and employees only.", () => owner.GetIntegerVariable("count") % 3 == 1, () => owner.IncrementIntegerVariable("count")));
            Messages.Add(new Message("You'd better extract yourself before I activate the security system.", () => owner.GetIntegerVariable("count") % 3 == 2, () => owner.IncrementIntegerVariable("count")));
        }
    }
}
