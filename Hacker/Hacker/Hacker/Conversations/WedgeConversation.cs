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
            Messages.Add(new Message("*Sigh*", () => owner.GetIntegerVariable("count") == 0, () => owner.IncrementIntegerVariable("count")));

            Messages.Add(new Message("Hitchcock's boot-licking actually worked on Blackmoore. Make's me sick.", () => owner.GetIntegerVariable("count") == 1, () => owner.IncrementIntegerVariable("count")));

            Messages.Add(new Message("Hey Briggs. Wait... you're not Briggs... What's wrong with me? Gonna lost my job at this rate...", () => owner.GetIntegerVariable("count")== 2, () => owner.IncrementIntegerVariable("count")));

            Message message1 = new Message("I'm tired of working for that conceited prig Blackmoore. He's up to no good.", () => owner.GetIntegerVariable("count") == 3, () => owner.IncrementIntegerVariable("count"));
            Message message11 = new Message("He invited me to his club and I haven't been able to think clearly since logging out!");
            Message message111 = new Message("First I pour orange juice in my cereal, then toast bread in the microwave.");
            Message message1111 = new Message("He's playing God using that damned mindshare device of his and there's nothing I can do.");
            Message message11111 = new Message("Wait a second! You seem like a capable sort. Tell you what I'm going to do. I'm going to give you the password to Blackmoore's vault.");
            Message message111111 = new Message("Well... actually I only have one part of his password.");
            Message message1111111 = new Message("Briggs and Hitchcock have the other two, but they'll never crack. You might have to keylog them or something.");
            Message message11111111 = new Message("Anyways, write this down because I'm not going to say it again... Hell, I might even forget!");
            Message message111111111 = new Message("The second part of the password is 'p1ckles' with a one instead of the i.");
            Message message1111111111 = new Message("Now go! I'm counting on you!");

            Messages.Add(message1);
            message1.Messages.Add(message11);
            message11.Messages.Add(message111);
            message111.Messages.Add(message1111);
            message1111.Messages.Add(message11111);
            message11111.Messages.Add(message111111);
            message111111.Messages.Add(message1111111);
            message1111111.Messages.Add(message11111111);
            message11111111.Messages.Add(message111111111);
            message111111111.Messages.Add(message1111111111);

            Messages.Add(new Message("Hey Briggs. Wait... you're not Briggs... What's wrong with me? Gonna lost my job at this rate...", () => owner.GetIntegerVariable("count") == 4));
        }
    }
}
