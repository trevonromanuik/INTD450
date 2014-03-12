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
    class MantisConversation : Conversation
    {
        public MantisConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            Messages.Add(new Message("hey m8 it's ur lucky day, i got just what you need", () => owner.GetIntegerVariable("count") % 3 == 0, () =>
            {
                owner.IncrementIntegerVariable("count");
            }));

            Messages.Add(new Message("srsly bruv i move in bulk, best deal, 8 $ for 2 7oz bags, you gonna get lucky", () => owner.GetIntegerVariable("count") % 3 == 1, () =>
            {
                owner.IncrementIntegerVariable("count");
            }));

            Messages.Add(new Message("yeah i knew youd be into it, check out my online shop @ http://goo.gl/zBkmsH", () => owner.GetIntegerVariable("count") % 3 == 2, () =>
            {
                owner.IncrementIntegerVariable("count");
            }));
        }
    }
}
