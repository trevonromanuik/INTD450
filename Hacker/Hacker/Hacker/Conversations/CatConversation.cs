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
    class CatConversation : Conversation
    {
        public CatConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            Messages.Add(new Message(":3 Meow, meow! *Mowow* <3", () => owner.GetIntegerVariable("count") % 3 == 0, () => 
                {
                    owner.IncrementIntegerVariable("count");
                    owner.GetComponent<AnimatedSprite>().PlayAnimation("right");
                }));

            Messages.Add(new Message("Leave me alone, I'm RPing.", () => owner.GetIntegerVariable("count") % 3 == 1, () => 
                {
                    owner.IncrementIntegerVariable("count");
                    owner.GetComponent<AnimatedSprite>().PlayAnimation("right");
                }));

            Messages.Add(new Message("srsly dude pls go", () => owner.GetIntegerVariable("count") % 3 == 2, () => 
                {
                    owner.IncrementIntegerVariable("count");
                    owner.GetComponent<AnimatedSprite>().PlayAnimation("right");
                }));
        }
    }
}
