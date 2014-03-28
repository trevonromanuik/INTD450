﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Screens;
using Hacker.Managers;
using Hacker.Helpers;
using System.Net.NetworkInformation;

namespace Hacker.Conversations
{
    class LoginConversation : Conversation
    {
        private ScreenManager _screenManager;
        private string username, email;

        public LoginConversation(ScreenManager screenManager)
            : base(null, "System Login", null)
        {
            _screenManager = screenManager;
            var Message0 = new Message("Welcome to GlobeComm, the newest and most exciting virtual reality world-simulation and social networking software!");
            var Message1 = new Message("Verifying your connection...");
            var Message10 = new Message("Connection verified.", () => ConnectionMonitor.checkInterwebs());
            var Message11 = new Message("Sorry, we could not verify your internet connection. Please connect to the internet and launch GlobeComm again.");
            var Message2 = new InputMessage("Please enter your username.");
            var Message20 = new Message("Thank you.", () => !String.IsNullOrWhiteSpace(Message2.Output), () => { username = Message2.Output; });
            var Message21 = new Message("That is not a valid username, please try again.");
            var Message3 = new InputMessage("Please enter your email address.");
            var Message30 = new Message("Thank you.", () => EmailHelper.IsValidEmail(Message3.Output), () => { email = Message3.Output; });
            var Message31 = new Message("That is not a valid email address. Please try again.");
            var Message4 = new Message("Your session ID is "+ Guid.NewGuid().ToString());
            var Message5 = new Message("Enjoy your stay at GlobeComm ~ where virtual communication's gone global!", () => true);

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

        public override void Done()
        {
            Player.Instance.SetStringVariable("Username", username);
            Player.Instance.SetStringVariable("Email", email);
            //new ConnectionMonitor(); // Internet heartbeat monitor
            _screenManager.LoadNewScreen(new GameScreen(_screenManager));
        }
    }
}
