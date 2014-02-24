using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Screens;

namespace Hacker.Conversations
{
    class TerminalConversation : Conversation
    {
        public TerminalConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            Message message1 = new Message("Good job Hacker. You have beaten the prototype.\nPress ESC to exit the game.");
            Messages.Add(message1);
        }
    }
}
