using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Actions;
using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Managers;
using Hacker.Screens;

namespace Hacker.Conversations
{
    class WedgeConversation : Conversation
    {
        public WedgeConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            // If spoofing Blackmoore in the club
            Messages.Add(new Message("Oh, Mr. Blackmoore! Cheers to your business, eh? With a fancy show like this, I'll be sure to sign up for that Mindshare volunteer trial program of yours.", () => Player.Instance.GameCompleteState == GameCompleteState.GameStart && Player.Instance.SpoofId == "blackmoore"));

            // If spoofing Juliana in the club
            Messages.Add(new Message("Hey there, Juliana. This is a pretty nice do you and Mr. Blackmoore organized! You're really going all-out to advertise Mindshare, huh?", () => Player.Instance.GameCompleteState == GameCompleteState.GameStart && Player.Instance.SpoofId == "juliana"));

            // Default Club convo
            Messages.Add(new Message("Normally I just work guard duty for Blackmoore, but the employee bonus he's offering for Mindshare volunteer participants is looking pretty sweet to me right now.", () => Player.Instance.GameCompleteState == GameCompleteState.GameStart));

            // If spoofing Blackmoore in the Data Bank
            Messages.Add(new Message("Oh, M-Mr. Blackmoore! You're....you're having a nice day, I suppose? I mean, er, great party you threw! That Mindshare product of yours is sure...something!", () => Player.Instance.SpoofId == "blackmoore"));

            // If spoofing Juliana in the Data Bank
            Messages.Add(new Message("Hi Miss Juliana. Was there an inspection scheduled today? I... well, I thought I would have written it down, but...", () => Player.Instance.SpoofId == "juliana"));

            
            // Data bank default convo
            Messages.Add(new Message("*Sigh*", () => owner.GetIntegerVariable("count") == 0, () => owner.IncrementIntegerVariable("count")));

            Messages.Add(new Message("Hitchcock's boot-licking actually worked on Blackmoore. Make's me sick.", () => owner.GetIntegerVariable("count") == 1, () => owner.IncrementIntegerVariable("count")));

            Messages.Add(new Message("Hey Briggs. Wait... you're not Briggs... What's wrong with me? Gonna lose my job at this rate...", () => owner.GetIntegerVariable("count")== 2, () => owner.IncrementIntegerVariable("count")));

            Message message1 = new Message("I'm tired of working for that conceited prig Blackmoore. He's up to no good.", () => owner.GetIntegerVariable("count") == 3, () => owner.IncrementIntegerVariable("count"));
            Message message11 = new Message("He invited me to his club and I haven't been able to think clearly since logging out!");
            Message message111 = new Message("First I pour orange juice in my cereal, then toast bread in the microwave.");
            Message message1111 = new Message("He's playing God using that damned Mindshare device of his and there's nothing I can do.");
            Message message11111 = new Message("Wh-What was I just doing?");

            Messages.Add(message1);
            message1.Messages.Add(message11);
            message11.Messages.Add(message111);
            message111.Messages.Add(message1111);
            message1111.Messages.Add(message11111);

            Messages.Add(new Message("Hey Briggs. Wait... you're not Briggs... What's wrong with me? Gonna lost my job at this rate...", () => owner.GetIntegerVariable("count") == 4));
        }
    }
}
