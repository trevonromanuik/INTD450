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
    class SailorMoonConversation : Conversation
    {
        public SailorMoonConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            Messages.Add(new Message("I am Sailor Moon, champion of justice! On behalf of the moon, I will right wrongs and triumph over evil, and that means you!", () => owner.GetIntegerVariable("count") % 3 == 0, () =>
            {
                owner.IncrementIntegerVariable("count");
                owner.GetComponent<AnimatedSprite>().PlayAnimation("left");
            }));

            Messages.Add(new Message("Luna, you really must get a black cat avatar for this to be authentic.", () => owner.GetIntegerVariable("count") % 3 == 1, () =>
            {
                owner.IncrementIntegerVariable("count");
                owner.GetComponent<AnimatedSprite>().PlayAnimation("left");
            }));

            Messages.Add(new Message("afk mom says the hot pockets are ready", () => owner.GetIntegerVariable("count") % 3 == 2, () =>
            {
                owner.IncrementIntegerVariable("count");
                owner.GetComponent<AnimatedSprite>().PlayAnimation("left");
            }));
        }
    }
}
