using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Actions;
using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Helpers;
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
            //hardcode this variable to launch the game at a specific story point
            Player.Instance.GameCompleteState = GameCompleteState.GameStart;

            // Post-terminal convo
            Message message2 = new Message("You should read the email I've sent you about your project brief.", () => owner.GetBooleanVariable("terminal_done") && Player.Instance.GameCompleteState == GameCompleteState.GameStart);
            Message message21 = new Message("I'll connect you now to the virtual dock that acts as the point of entry to Blackmoore's private publicity event.");
            Message message211 = new Message("Keep an eye on your inbox. You might receive further correspondence from me. Good luck now, friend.", () => true,
                () => GameScreen.LoadLevel<ClubExteriorLevel>(new FadeTransition(new Vector2(832, 320))));

            message21.Messages.Add(message211);
            message2.Messages.Add(message21);
            Messages.Add(message2);

            Messages.Add(new Message("Don't forget to check your e-mail.", () => owner.GetBooleanVariable("done") && Player.Instance.GameCompleteState == GameCompleteState.GameStart));

            // Game intro convo (GameStart)
            Message message1 = new Message("Ahh, the illustrious 'hacker' finally arrives. Welcome to GlobeComm, " + Player.Instance.GetStringVariable("Username") + ". 'Where virtual communication's gone global!' ...Heh, or so the fancy logo says.", () => Player.Instance.GameCompleteState == GameCompleteState.GameStart);
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

            // Club complete convo (ClubComplete)
            Message message3 = new Message("Hey, good work. ", () => Player.Instance.GameCompleteState == GameCompleteState.ClubComplete);
            Message message3a = new Message("I disconnected you from Blackmoore's yacht server as soon as you found what we needed. Didn't want you in the wolves' den any longer than necessary.");
            Message message3b = new Message("Now, we need to gather hard evidence on Blackmoore's plans. Luckily, all his confidential files are stored in one data bank...");
            Message message3c = new Message("...In the vault that you just found the number for. Good work! I'm sure that Blackmoore's been keeping sensitive files secure there.");
            Message message3d = new Message("Inside that vault, there should be some files that outline testing that was done on the Mindshare device. I suspect that we'll find evidence of its unpredictability and signs that it's caused brain damage.");
            Message message3e = new Message("I'll connect you to the data bank now. I've also sent you an email that outlines your objective. Read it.", () => true, () =>
            {
                EmailHelper.SendMessage("databank_email");
            });
            Message message3f = new Message("We're hazarding security central now, so tread carefully. I'm counting on you.", () => true, () =>
            {
                GameScreen.LoadLevel<DataBankLevel>(new FadeTransition(new Vector2(512, 1024)));
            });

            message3e.Messages.Add(message3f);
            message3d.Messages.Add(message3e);
            message3c.Messages.Add(message3d);
            message3b.Messages.Add(message3c);
            message3a.Messages.Add(message3b);
            message3.Messages.Add(message3a);
            Messages.Add(message3);

            // Data bank complete convo (DataBankComplete)
            Message message4 = new Message("You're back! I traced you and saw you download those files. I knew I hired you for the right reasons.", () => Player.Instance.GameCompleteState == GameCompleteState.DataBankComplete);
            Message message4a = new Message("Looks like you've picked up files called Tech_Analysis, Resources_Request, and Experimental_Error. That's great. Let me just take a look... wait a minute...");
            Message message4b = new Message("Motherboards! Those files have been encrypted. I should have expected this. Take a look at them, there's no way to read them. ");
            Message message4c = new Message("Hmmm... decryption programs are illegal, so we'll have to take a dip in the deep web to find someone tech-savvy enough to help us out.");
            Message message4d = new Message("I was hoping to avoid any sketchy servers. It's bad luck to take a wrong turn on the web. But I know of a decryption specialist named Cipher, and I know the server she hangs out on.");
            Message message4e = new Message("I'll link you to part of the deep web. Find Cipher, and get her help decrypting these files.", () => true, () =>
            {
                GameScreen.LoadLevel<DeepWebLevel>(new FadeTransition(new Vector2(224, 832)));
            });

            message4d.Messages.Add(message4e);
            message4c.Messages.Add(message4d);
            message4b.Messages.Add(message4c);
            message4a.Messages.Add(message4b);
            message4.Messages.Add(message4a);
            Messages.Add(message4);

            // End game convo (DeepWebComplete)
            Message message5 = new Message("This is the end of the game!",  () => Player.Instance.GameCompleteState == GameCompleteState.DeepWebComplete);

            Messages.Add(message5);
        }
    }
}
