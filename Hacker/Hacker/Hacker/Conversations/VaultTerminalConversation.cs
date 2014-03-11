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
    class VaultTerminalConversation : Conversation
    {
        public VaultTerminalConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            Message message1 = new Message("Welcome, Mr. Blackmoore.");
            Message message11 = new Message("Download request received. Now downloading files: Experimental_Error, Tech_Analysis, and Resources_Request.", () =>
            {
                Helpers.FileWriterHelper.writeFile("experimental_error", "Downloads/");
                Helpers.FileWriterHelper.writeFile("tech_analysis", "Downloads/");
                Helpers.FileWriterHelper.writeFile("resources_request", "Downloads/");
                return true;
            });
            Message message111 = new Message("Download complete. Encrypted files now available in your home directory.");
            message1.Messages.Add(message11);
            message11.Messages.Add(message111);
            Messages.Add(message1);
        }
    }
}
