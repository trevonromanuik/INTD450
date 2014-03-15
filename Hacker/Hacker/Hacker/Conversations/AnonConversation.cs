using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Actions;
using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Levels;
using Hacker.Screens;
using Hacker.Transitions;

namespace Hacker.Conversations
{
    class AnonConversation : Conversation
    {
        public AnonConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            Message message2 = new Message("You should read the email I've sent you about your project brief.", () => owner.GetBooleanVariable("terminal_done"));
            Message message21 = new Message("I'll connect you now to the virtual dock that acts as the point of entry to Blackmoore's private publicity event.");
            Message message211 = new Message("Keep your eye on your inbox. You might find yourself receiving further correspondence from me. Good luck now, friend.", () => true,
                () => GameScreen.LoadLevel<ClubExteriorLevel>(new FadeTransition(new Vector2(832, 320))));

            message21.Messages.Add(message211);
            message2.Messages.Add(message21);
            Messages.Add(message2);

            Messages.Add(new Message("Don't forget to check your e-mail when you finish", () => owner.GetBooleanVariable("done")));

            Message message1 = new Message("Ahh, the illustrious 'hacker' finally arrives. Welcome to GlobeComm, " + Player.Instance.GetStringVariable("Username") + ". 'Where communication's gone global!' ...Heh, or so the fancy logo says.");
            Message message1a = new Message("Normally when you join this service you'd get dropped into a public park, or a place where you could chat with your friends, but I intercepted your connection and brought you here.");
            Message message1b = new Message("Since this software's so new I'll give you a quick 411. Elite capitalists and tech tychoons are all over this social networking service. Using it to impress investors, share data, or store money...");
            Message message1c = new Message("Regular joes hang out here too of course, only they're not so much allowed in the elitists' locales. You can buy most anything from the criminals and weirdos who hang out in the underbellies of some servers.");
            Message message1d = new Message("Me? You can call me 'Anon.' It doesn't matter who I am. I've heard you know your way around the internet. You're obscure and unpredictable. I've got a job for you, and if you scratch my back, I'll scratch yours.");
            Message message1e = new Message("But enough talk for now, time for your first exercise. Go up to that terminal north of me and give it a gander.", () => true, () => 
            { 
                owner.Manager.AddGameObject(new HubTerminal()); 
                owner.SetBooleanVariable("done", true); 
            });

            message1d.Messages.Add(message1e);
            message1c.Messages.Add(message1d);
            message1b.Messages.Add(message1c);
            message1a.Messages.Add(message1b);
            message1.Messages.Add(message1a);
            Messages.Add(message1);
        }
    }
}
