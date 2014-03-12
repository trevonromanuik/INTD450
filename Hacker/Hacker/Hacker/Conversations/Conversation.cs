using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.GameObjects;

namespace Hacker.Conversations
{
    class Conversation
    {
        public List<Message> Messages { get; private set; }
        public GameObject Owner { get; private set; }
        public string Name { get; private set; }
        public string IpAddress { get; private set; }

        public Conversation(GameObject owner, string name, string ipAddress)
        {
            Messages = new List<Message>();
            Owner = owner;
            Name = name;
            IpAddress = ipAddress;
        }

        public Message First()
        {
            return Messages.FirstOrDefault(x => x.Condition());
        }

        public virtual void Done() { }
    }
}
