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
    class AnonConversation : Conversation
    {
        public AnonConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            Message message2 = new Message("Ok I am going to send you to Blackmoore's private yacht, the SS Touch Tonic.", () => owner.GetBooleanVariable("terminal_done"));
            Message message21 = new Message("Blackmoore is hosting an exclusive event there. See what you can find.");
            Message message211 = new Message("Good luck.", () => true,
                () => GameScreen.LoadLevel<ClubExteriorLevel>(new FadeTransition(new Vector2(832, 320))));

            message21.Messages.Add(message211);
            message2.Messages.Add(message21);
            Messages.Add(message2);

            Messages.Add(new Message("Don't forget to check your e-mail when you finish", () => owner.GetBooleanVariable("done")));

            Message message1 = new Message("Ahh, the illustrious hacker finally arrives.");
            Message message11 = new Message("Still looking for a job? You'll need to jack into the terminal and put your details into the system.", () => true, () => { owner.Manager.AddGameObject(new HubTerminal()); owner.SetBooleanVariable("done", true); });
            Message message111 = new Message("Don't forget to check your e-mail when you finish, then come back and talk to me.");

            message11.Messages.Add(message111);
            message1.Messages.Add(message11);
            Messages.Add(message1);
        }
    }
}
