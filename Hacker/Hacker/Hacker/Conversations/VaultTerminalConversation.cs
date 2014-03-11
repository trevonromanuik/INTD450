using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Levels;
using Hacker.Screens;
using Hacker.Transitions;

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
            Message message1111 = new Message("You've completed the Data Bank level. You will now be teleported to the Deep Web level, where you must try to find Cipher, who will decrypt these files.");
            Message message11111 = new Message(" ", () =>
            {
                GameScreen.LoadLevel<DeepWebLevel>(new FadeTransition(new Vector2(224, 832)));
                return true;
            });
            message1.Messages.Add(message11);
            message11.Messages.Add(message111);
            message111.Messages.Add(message1111);
            message1111.Messages.Add(message11111);
            Messages.Add(message1);
        }
    }
}
