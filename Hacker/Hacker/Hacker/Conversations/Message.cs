using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hacker.Conversations
{
    class Message
    {
        public string Text { get; private set; }

        public Message(string text)
        {
            Text = text;
        }
    }
}
