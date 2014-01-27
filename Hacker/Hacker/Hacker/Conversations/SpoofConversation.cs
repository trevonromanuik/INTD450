using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.GameObjects;

namespace Hacker.Conversations
{
    class SpoofConversation : Conversation
    {
        public SpoofConversation(string name, string ipAddress)
            : base(name, ipAddress)
        {
            Message message1 = new Message("Why do you look like me?", () => Player.Instance.SpoofId == "spoofie");
            Message message11 = new Message("I don't like this.");
            message1.Messages.Add(message11);
            Messages.Add(message1);

            Message message2 = new Message("Hello Hacker.");
            Message message21 = new Message("asdfdasfasdfdasfdasfdsafdfas\nasdfasdfasdfdasdfas\nasdfa.");
            Message message211 = new Message("This is a conversation.");
            Message message2111 = new Message("This is the last message.");
            message211.Messages.Add(message2111);
            message21.Messages.Add(message211);
            message2.Messages.Add(message21);
            Messages.Add(message2);
        }
    }
}
