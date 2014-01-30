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

            Message message2 = new Message("Oh hello there.");
            Message message21 = new Message("Nice weather we're having, isn't it?");
            message2.Messages.Add(message21);
            Messages.Add(message2);
        }
    }
}
