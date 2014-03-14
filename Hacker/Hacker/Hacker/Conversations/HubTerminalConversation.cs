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
            var Message0 = new Message("Welcome to GlobeCom.");
            var Message1 = new Message("Verifying your connection...");
            var Message10 = new Message("Connection verified.", () => checkInterwebs());
            var Message11 = new Message("Sorry, we could not verify your internet connection.");
            var Message2 = new InputMessage("Please enter your username.");
            var Message20 = new Message("Thank you.", () => !String.IsNullOrWhiteSpace(Message2.Output), () => Player.Instance.SetStringVariable("Username", Message2.Output));
            var Message21 = new Message("Sorry, you must enter a valid username.");
            var Message3 = new InputMessage("Please enter your email address.");
            var Message30 = new Message("Thank you.", () => IsValidEmail(Message3.Output), () => Player.Instance.SetStringVariable("Email", Message3.Output));
            var Message31 = new Message("Sorry, you must enter a valid email address.");
            var Message4 = new Message("Your session ID is " + Guid.NewGuid().ToString());
            var Message5 = new Message("Enjoy your stay.", () => true, () => { EmailHelper.SendMessage("opening_email"); owner.Manager.GetGameObjectById("anon").SetBooleanVariable("terminal_done", true); });

            Messages.Add(Message0);
            Message0.Messages.Add(Message1);
            Message1.Messages.Add(Message10);
            Message1.Messages.Add(Message11);
            Message10.Messages.Add(Message2);
            Message2.Messages.Add(Message20);
            Message2.Messages.Add(Message21);
            Message20.Messages.Add(Message3);
            Message21.Messages.Add(Message2);
            Message3.Messages.Add(Message30);
            Message3.Messages.Add(Message31);
            Message30.Messages.Add(Message4);
            Message31.Messages.Add(Message3);
            Message4.Messages.Add(Message5);
        }

        private bool checkInterwebs()
        {
            try
            {
                var reply = new Ping().Send("google.com", 1000, new byte[32], new PingOptions());
                return reply.Status == IPStatus.Success ? true : false;
            }
            catch (PingException)
            {
                return false;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
