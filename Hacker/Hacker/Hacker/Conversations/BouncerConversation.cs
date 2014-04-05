using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Actions;
using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Helpers;
using Hacker.Layers;
using Hacker.Screens;

namespace Hacker.Conversations
{
    class BouncerConversation : Conversation
    {
        public BouncerConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            Messages.Add(new Message("Have a wonderful day, Ms. Smith.", () => Player.Instance.SpoofId == "juliana" && owner.GetBooleanVariable("done")));

            Messages.Add(new Message("[Engaging Bouncer Protocol] Good evening Ms. Smith. Always a pleasure. Let me get out of your way.", () => Player.Instance.SpoofId == "juliana", () =>
            {
                owner.SetBooleanVariable("done", true);
                owner.AddAction(new MoveToAction(new Vector2(640, 244), 0.5));
            }));

            Messages.Add(new Message("[Engaging Bouncer Protocol] You're interested in the mindshare device, I assume? Mr. Blackmoore invited a few investors to discuss stocks and shares, but if you don't have an invitation then you're not getting inside.", () => owner.GetIntegerVariable("count") % 3 == 0, () =>
                {
                    owner.IncrementIntegerVariable("count");
                    if (owner.GetBooleanVariable("sentmsg") == false)
                    {
                        Helpers.FileCopyHelper.copyFile("README.txt");
                        owner.SetBooleanVariable("sentmsg", true);
                    }
                }));
            Messages.Add(new Message("Investors and employees only.", () => owner.GetIntegerVariable("count") % 3 == 1, () => owner.IncrementIntegerVariable("count")));
            Messages.Add(new Message("I advise you to extract yourself before I activate the security system.", () => owner.GetIntegerVariable("count") % 3 == 2, () => owner.IncrementIntegerVariable("count")));
            
            //For quick run-throughs
            //Messages.Add(new Message("Perfect. Ok, go on in.", () => true, ()=>
            //{
            //    owner.SetBooleanVariable("done", true);
            //    owner.AddAction(new MoveToAction(new Vector2(640, 244), 0.5));
            //}));
            
        }
    }
}
