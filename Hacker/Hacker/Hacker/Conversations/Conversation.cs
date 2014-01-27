using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hacker.Conversations
{
    class Conversation
    {
        public List<Message> Messages { get; private set; }
        public string Name { get; private set; }
        public string IpAddress { get; private set; }

        public Conversation(string name, string ipAddress)
        {
            Messages = new List<Message>();
            Name = name;
            IpAddress = ipAddress;
        }

        public Message First()
        {
            return Messages.First(x => x.Func());
        }
    }
}
