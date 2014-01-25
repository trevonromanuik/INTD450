using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hacker.Conversations
{
    class SpoofConversation : Conversation
    {
        public SpoofConversation()
            : base()
        {
            Messages.Add(new Message("Hello Hacker"));
            Messages.Add(new Message("asdfdasfasdfdasfdasfdsafdfas\nasdfasdfasdfdasdfas\nasdfa"));
            Messages.Add(new Message("This is a conversation"));
            Messages.Add(new Message("This is the last message"));
        }
    }
}
