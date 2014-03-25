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
using Hacker.Managers;
using Hacker.Screens;
using Hacker.Transitions;

namespace Hacker.Conversations
{
    class CipherConversation : Conversation
    {
        public CipherConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            // After completing the riddle
            Messages.Add(new Message("Shh, I'm invisible. Did you run the program to decrypt your files? I worked so hard on that for you!", () => Player.Instance.GameCompleteState == GameCompleteState.DeepWebComplete));

            // Answering the riddle
            InputMessage message3 = new InputMessage("Did you figure out the five-digit street address?", () => owner.GetBooleanVariable("puzzle_given"));
            Message message31 = new Message("Correct! And here I thought I threw you for a loophole.", () => message3.Output == "24085");
            Message message311 = new Message("Okay... hold on... alllllmost... not quite... There! You should have a nice little program sitting on your hard drive that will decrypt your files for you.", () =>
            {
                Helpers.FileCopyHelper.copyFile("DecryptionProgram.lnk", "Downloads/");
                return true;
            });
            Message message3111 = new Message("Find it in your 'GlobeComm Deliveries/Downloads' folder on your desktop, and just double click it!");
            Message message31111 = new Message("Well, it's been a pleasure, but I best grab a new IP and disappear before MI5 comes for me. See you!");
            Message message311111 = new Message("*poof*", () => true, () =>
            {
                AnimatedSprite sprite = GameScreen.Level.GetLayer<ObjectLayer>().GameObjectManager.GetGameObjectById("cipher").GetComponent<AnimatedSprite>();
                GameScreen.Level.GetLayer<ObjectLayer>().GameObjectManager.GetGameObjectById("cipher").AddComponent(new Sprite(AssetManager.LoadTexture("invisible")));
                sprite.Remove();
                
                Player.Instance.GameCompleteState = GameCompleteState.DeepWebComplete;
            });
            
            // Incorrect answer clues
            Message message3a = new Message("Nope. Take another look and try harder this time. You do know that you can press CTRL+F to search for a keyword within a document, right?", () => owner.GetIntegerVariable("count") % 3 == 0, () =>
            {
                owner.IncrementIntegerVariable("count");
            });

            Message message3b = new Message("Sorry, that's wrong. Did you at least find the name of the company? Why not try searching the internet for that name?", () => owner.GetIntegerVariable("count") % 3 == 1, () =>
            {
                owner.IncrementIntegerVariable("count");
            });

            Message message3c = new Message("You STILL can't figure it out? Fine, the company's name is 'QuinStar.' Search Google for that and tell me their 5-digit street address number.", () => owner.GetIntegerVariable("count") % 3 == 2, () =>
            {
                owner.IncrementIntegerVariable("count");
            });
           
            message3.Messages.Add(message31);
            message3.Messages.Add(message3a);
            message3.Messages.Add(message3b);
            message3.Messages.Add(message3c);
            message31.Messages.Add(message311);
            message311.Messages.Add(message3111);
            message3111.Messages.Add(message31111);
            message31111.Messages.Add(message311111);
            Messages.Add(message3);

            // Giving the riddle
            Message message2 = new Message("Welcome to the Cipher Cave!");
            Message message20 = new Message("So you're looking for help decrypting files, hmm? Let me take a look.");
            Message message21 = new Message("Aha, I can see Blackmoore's signature on some of these!");
            Message message211 = new Message("Normally I'd ask for payment, but you're an unusual customer with unusual needs, and I'd like to have some unusual fun with you. Hold on...");
            Message message2111 = new Message("Okay, I sent something to your e-mail. Solve the riddle and I'll decrypt the files.", () => true, () =>
            {
                owner.SetBooleanVariable("puzzle_given", true);
                Helpers.EmailHelper.SendMessage("cipher_puzzle_email"); 
            });
            message211.Messages.Add(message2111);
            message21.Messages.Add(message211);
            message20.Messages.Add(message21);
            message2.Messages.Add(message20);
            Messages.Add(message2);


        }
    }
}
