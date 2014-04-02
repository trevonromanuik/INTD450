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
    class ArtistConversation : Conversation
    {
        public ArtistConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            // Artist is in the club and deep web and should say different things
            if (Player.Instance.GameCompleteState == GameCompleteState.DataBankComplete)
            {
                Messages.Add(new Message("you ever do that thing where you check the time and then you think ah great swell and then ten seconds later you check again? do you?", () => owner.GetIntegerVariable("count") % 3 == 0, () =>
                {
                    owner.IncrementIntegerVariable("count");
                    owner.GetComponent<AnimatedSprite>().PlayAnimation("left");
                }));

                Messages.Add(new Message("i'm goin out of my mind, can't even get any rnr by painting like i used to, it's like i'm useless with a brush lately", () => owner.GetIntegerVariable("count") % 3 == 1, () =>
                {
                    owner.IncrementIntegerVariable("count");
                    owner.GetComponent<AnimatedSprite>().PlayAnimation("left");
                }));

                Messages.Add(new Message("it seems like every day is like this now, don't know what's wrong with what's wrong with me man. wait who are you?", () => owner.GetIntegerVariable("count") % 3 == 2, () =>
                {
                    owner.IncrementIntegerVariable("count");
                    owner.GetComponent<AnimatedSprite>().PlayAnimation("left");
                }));
            }
            else
            {
                Messages.Add(new Message("Did you speak to Miss Juliana outside? She's always been lovely to me. Very enamoured with my artwork. She convinced me to try the Mindshare device in the first place!", () => owner.GetIntegerVariable("count") % 3 == 0, () =>
                {
                    owner.IncrementIntegerVariable("count");
                    owner.GetComponent<AnimatedSprite>().PlayAnimation("left");
                }));

                Messages.Add(new Message("I was born with natural artistic talent, but never really wanted to make a career out of it. I keep getting invited to Blackmoore's events because he considers me a perfect match for his new technology.", () => owner.GetIntegerVariable("count") % 3 == 1, () =>
                {
                    owner.IncrementIntegerVariable("count");
                    owner.GetComponent<AnimatedSprite>().PlayAnimation("left");
                }));

                Messages.Add(new Message("Who are you again? Hmm... I wonder where I was supposed to be after this.", () => owner.GetIntegerVariable("count") % 3 == 2, () =>
                {
                    owner.IncrementIntegerVariable("count");
                    owner.GetComponent<AnimatedSprite>().PlayAnimation("left");
                }));
            }
        }
    }
}
