using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hacker.Conversations
{
    class Conversation
    {
        public List<Message> Messages { get; set; }

        public Conversation()
        {
            Messages = new List<Message>();
        }
    }
}
