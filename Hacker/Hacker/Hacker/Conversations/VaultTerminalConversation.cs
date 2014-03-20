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
            Message message111 = new Message("Download complete. Encrypted files now available in your 'GlobeComm Deliveries/Downloads' directory.");
            Message message1111 = new Message(" ", () =>
            {
                Player.Instance.GameCompleteState = GameCompleteState.DataBankComplete;
                GameScreen.LoadLevel<HubLevel>(new FadeTransition(new Vector2(320, 384)));
                return true;
            });
            message1.Messages.Add(message11);
            message11.Messages.Add(message111);
            message111.Messages.Add(message1111);
            Messages.Add(message1);
        }
    }
}
