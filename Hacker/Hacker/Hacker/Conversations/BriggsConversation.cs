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
    class BriggsConversation : Conversation
    {
        public BriggsConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            // If spoofing Blackmoore in the Data Bank
            Messages.Add(new Message("Mr. Blackmoore! Pleasure to see you. Routine password updates are moving ahead as scheduled.", () => Player.Instance.GameCompleteState == GameCompleteState.ClubComplete && Player.Instance.SpoofId == "blackmoore"));

            Messages.Add(new Message("What brings you to the data bank?", () => owner.GetIntegerVariable("count") % 3 == 0, () => owner.IncrementIntegerVariable("count")));
            Messages.Add(new Message("I've been working on this project for over a year now. Our security system is impenetrable.", () => owner.GetIntegerVariable("count") % 3 == 1, () => owner.IncrementIntegerVariable("count")));
            Messages.Add(new Message("Even I don't know the entire password to Blackmoore's vault.", () => owner.GetIntegerVariable("count") % 3 == 2, () => owner.IncrementIntegerVariable("count")));
        }
    }
}
