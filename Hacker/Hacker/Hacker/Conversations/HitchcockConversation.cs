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
    class HitchcockConversation : Conversation
    {
        public HitchcockConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            // If spoofing Blackmoore in the Data Bank
            Messages.Add(new Message("Mr. Blackmoore. Come to check on your assets? We're maintaining security protocols as always.", () => Player.Instance.GameCompleteState == GameCompleteState.ClubComplete && Player.Instance.SpoofId == "blackmoore"));

            // Default data bank convo
            Messages.Add(new Message("Here to cause trouble for the boss man? Don't try anything funny.", () => owner.GetIntegerVariable("count") % 3 == 0, () => owner.IncrementIntegerVariable("count")));
            Messages.Add(new Message("I've got my eyes on you.", () => owner.GetIntegerVariable("count") % 3 == 1, () => owner.IncrementIntegerVariable("count")));
            Messages.Add(new Message("Think you're hot stuff? You ain't worth jack.", () => owner.GetIntegerVariable("count") % 3 == 2, () => owner.IncrementIntegerVariable("count")));
        }
    }
}
