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
    class TrashConversation : Conversation
    {
        public TrashConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            Messages.Add(new Message("Do you like my avatar? I like to call it 'Incognito Mode.'", () => owner.GetIntegerVariable("count") % 3 == 0, () =>
            {
                owner.IncrementIntegerVariable("count");
            }));

            Messages.Add(new Message("The front page of Google has at least 10 different answers for 'who invented the garbage can.' It's truly a modern mystery of our time.", () => owner.GetIntegerVariable("count") % 3 == 1, () =>
            {
                owner.IncrementIntegerVariable("count");
            }));

            Messages.Add(new Message("They said I could be anything, so I became a trash can.", () => owner.GetIntegerVariable("count") % 3 == 2, () =>
            {
                owner.IncrementIntegerVariable("count");
            }));
        }
    }
}