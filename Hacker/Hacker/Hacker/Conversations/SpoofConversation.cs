using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.GameObjects;
using Hacker.Components;

namespace Hacker.Conversations
{
    class SpoofConversation : Conversation
    {
        public SpoofConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            Message message1 = new Message("Why do you look like me?", () => Player.Instance.SpoofId == "spoofie");
            Message message11 = new Message("I don't like this.");
            message1.Messages.Add(message11);
            Messages.Add(message1);

            Message message3 = new Message("Oh dear me. It seems that I have been DDOSed. How unfortunate.", () => owner.GetComponent<DDOSable>().Enabled);
            Messages.Add(message3);

            Message message2 = new Message("Oh hello there.");
            Message message21 = new Message("My name is Ryan Blackmoore.");
            Message message211 = new Message("We should be Facebook friends.");
            Message message2111 = new Message("My Facebook url is https://www.facebook.com/ryan.blackmoore.9.");
            Message message21111 = new Message("Look me up sometime!", () => true, () => { 
                //Helpers.EmailHelper.sendMessage("opening_email"); 
            });
            message2111.Messages.Add(message21111);
            message211.Messages.Add(message2111);
            message21.Messages.Add(message211);
            message2.Messages.Add(message21);
            Messages.Add(message2);
        }
    }
}
