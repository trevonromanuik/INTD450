using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Screens;
using Hacker.Managers;
using System.Net.NetworkInformation;

namespace Hacker.Conversations
{
    class LoginConversation : Conversation
    {
        private ScreenManager _screenManager;

        public LoginConversation(ScreenManager screenManager)
            : base(null, "System Login", null)
        {
            _screenManager = screenManager;
            var Message0  = new Message("Welcome to GlobeCom.");
            var Message1 = new Message("Verifying your connection...");
            var Message10 = new Message("Connection verified.", () => checkInterwebs());
            var Message11 = new Message("Sorry, we could not verify your internet connection.");
            var Message2 = new InputMessage("Please enter your username.");
            string username = Message2.Output;
            var Message3 = new InputMessage("Please enter your email address.");
            var Message4 = new Message("Thank you. Your session ID is "+ Guid.NewGuid().ToString());
            var Message5 = new Message("Enjoy your stay.", () => true);

            string email = Message3.Output;

            Messages.Add(Message0);
            Message0.Messages.Add(Message1);
            Message1.Messages.Add(Message10);
            Message1.Messages.Add(Message11);
            Message10.Messages.Add(Message2);
            Message2.Messages.Add(Message3);
            Message3.Messages.Add(Message4);
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

        public override void Done()
        {
            _screenManager.LoadNewScreen(new GameScreen(_screenManager));
        }
    }
}
