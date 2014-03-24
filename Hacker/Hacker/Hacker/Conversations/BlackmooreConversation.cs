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
            Message message11 = new Message("It is an exciting passage in history for us as we are finally preparing to actualize our latest bleeding-edge technology... The mindshare device!");
            Message message111 = new Message("It is our most sincere hope that you will be interested in jumping aboard our innovative project. If you have any questions, I'm yours for the evening.", () => true, () => owner.SetBooleanVariable("triggered", true));

            message11.Messages.Add(message111);
            message1.Messages.Add(message11);
            Messages.Add(message1);

            // If Spoofing Blackmoore
            Messages.Add(new Message("I am flattered that you would copy my avatar, but if you do not change it soon I will have you kicked out of my club.", () => Player.Instance.SpoofId == owner.Id));

            // If Spoofing Juliana
            Message message2 = new Message("Ah, Juliana! I was hoping you'd turn up. I hope recruitment went swimmingly.", () => Player.Instance.SpoofId == "juliana");
            Message message21 = new Message("There've been rumors that some hactivist cretins are aiming to make another attack on my business. Could you ask the guards at the Data Bank to update my password again?");
            Message message211 = new Message("I wouldn't want the mindshare files leaked under any circumstances. Remember, the vault number is #3266845875.", ()=> true, () =>
            {
                Player.Instance.GameCompleteState = GameCompleteState.ClubComplete;
                GameScreen.LoadLevel<HubLevel>(new FadeTransition(new Vector2(320, 384)));
            });

            message21.Messages.Add(message211);
            message2.Messages.Add(message21);
            Messages.Add(message2);

            // If just talking to him
            Messages.Add(new Message("The mindshare operation is tried, tested, and true. I haven't suffered a single negative side effect and I've undergone the operation myself.", () => owner.GetIntegerVariable("count") % 3 == 0, () => owner.IncrementIntegerVariable("count")));
            Messages.Add(new Message("In just three years, our company took the lead in advanced neurosurgery. Of course, even though it's a very exciting moment in history, there will always be dissidents.", () => owner.GetIntegerVariable("count") % 3 == 1, () => owner.IncrementIntegerVariable("count")));
            Messages.Add(new Message("Over time, Blackmoore Industries will prove its technology reliable. Interested in making a contribution? I'll need a ball-park figure for the news reporters and press releases.", () => owner.GetIntegerVariable("count") % 3 == 2, () => owner.IncrementIntegerVariable("count")));
        }
    }
}
