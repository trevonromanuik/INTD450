using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Actions;
using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Levels;
using Hacker.Screens;
using Hacker.Transitions;

namespace Hacker.Conversations
{
    class BlackmooreConversation : Conversation
    {
        public BlackmooreConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            // Trigger conversation
            Message message1 = new Message("Good evening my fellow envisioneers! I want to start by thanking you for honouring Blackmoore Industries with your time.", () => !owner.GetBooleanVariable("triggered"));
            Message message11 = new Message("It is an exciting passage in history for us as we are finally preparing to actualize our latest bleeding-edge technology... The Mindshare device!");
            Message message111 = new Message("It is our most sincere hope that you will be interested in jumping aboard our innovative project. If you have any questions, I'm yours for the evening.", () => true, () => owner.SetBooleanVariable("triggered", true));
            Message message1111 = new Message("In the mean time, I invite you all to take a look at our brochure, which I've downloaded to your 'GlobeComm Deliveries' folder on your desktop. Feel free to connect with me on facebook as well! ", () => true, () =>
            {
                Helpers.FileCopyHelper.copyFile("Mindshare device.pdf");
            });

            message111.Messages.Add(message1111);
            message11.Messages.Add(message111);
            message1.Messages.Add(message11);
            Messages.Add(message1);

            // If Spoofing Blackmoore
            Messages.Add(new Message("I am flattered that you would copy my avatar, but I would encourage you to change it when we are amongst professional company.", () => Player.Instance.SpoofId == owner.Id));

            // If Spoofing Juliana
            Message message2 = new Message("Ah, Juliana! I was hoping you'd turn up. I hope recruitment went swimmingly.", () => Player.Instance.SpoofId == "juliana");
            Message message21 = new Message("There've been rumors that some hactivist cretins are aiming to make another attack on my business. Could you ask the guards at the Data Bank to update my password again?");
            Message message211 = new Message("Ah, what was the number of my account again? I can't remember. Remind me to look it up on my office terminal.");

            message21.Messages.Add(message211);
            message2.Messages.Add(message21);
            Messages.Add(message2);

            // If just talking to him
            Messages.Add(new Message("The Mindshare operation is tried, tested, and true. I haven't suffered a single negative side effect and I've undergone the operation myself.", () => owner.GetIntegerVariable("count") % 3 == 0, () => owner.IncrementIntegerVariable("count")));
            Messages.Add(new Message("In just three years, our company took the lead in advanced neurosurgery. Of course, even though it's a very exciting moment in history, there will always be dissidents.", () => owner.GetIntegerVariable("count") % 3 == 1, () => owner.IncrementIntegerVariable("count")));
            Messages.Add(new Message("Over time, Blackmoore Industries will prove its technology reliable. Did you find our brochure in your 'GlobeComm Deliveries/Downloads' folder? I'd say it's quite interesting reading material, but of course, I'm biased!", () => owner.GetIntegerVariable("count") % 3 == 2, () => owner.IncrementIntegerVariable("count")));
        }
    }
}
