using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hacker.Conversations
{
    class Message
    {
        public string Text { get; private set; }
        public Func<bool> Func { get; private set; }

        public List<Message> Messages { get; private set; }

        public Message(string text)
            : this(text, () => true)
        {

        }

        public Message(string text, Func<bool> func)
        {
            Text = text;
            Func = func;

            Messages = new List<Message>();
        }

        public Message Next()
        {
            return Messages.FirstOrDefault(x => x.Func());
        }
    }
}
