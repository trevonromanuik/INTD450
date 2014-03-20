using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Actions;
using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Helpers;
using Hacker.Layers;
using Hacker.Screens;

namespace Hacker.Conversations
{
    class HubTerminalConversation : Conversation
    {
        public HubTerminalConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            var Message1 = new Message("Login of user " + Player.Instance.GetStringVariable("Username") + " confirmed.");
            var Message11 = new Message("Now sending private message to address " + Player.Instance.GetStringVariable("Email") + ".", () => true, () => 
            { 
                EmailHelper.SendMessage("opening_email"); 
                owner.Manager.GetGameObjectById("anon").SetBooleanVariable("terminal_done", true); 
            });
            var Message111 = new Message("Message sent - may take a minute to arrive. Please check your email to receive private message.");

            Messages.Add(Message1);
            Message1.Messages.Add(Message11);
            Message11.Messages.Add(Message111);
        }
    }
}
