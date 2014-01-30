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
    class BouncerConversation : Conversation
    {
        bool firstFlag = false;
        bool secondFlag = false;
        bool thirdFlag = false;

        bool doneFlag = false;

        public BouncerConversation(string name, string ipAddress)
            : base(name, ipAddress)
        {
            Message message0 = new Message("I hate my job...", () => doneFlag);
            Messages.Add(message0);

            Message message1 = new Message("Oh hello Spoofie.", () => Player.Instance.SpoofId == "spoofie");
            Message message11 = new Message("Don't tell me. You forgot your password again.");
            Message message111 = new Message("You know I can't let you in without your password.");
            Message message1111 = new Message("Ok well you know the drill: answer the security questions and\nI'll let you in.");
            InputMessage message11111 = new InputMessage("First question: what's your mother's maiden name?");
            InputMessage message111111 = new InputMessage("Right. Ok, second question: what is your dog's name?", () => message11111.Output == "smith");
            InputMessage message1111111 = new InputMessage("Right. Ok, final question: in which city were you born?", () => message111111.Output == "roscoe");
            Message message11111111 = new Message("Perfect. Ok, go on in.", () => message1111111.Output == "edmonton", () =>
            {
                doneFlag = true;
                GameScreen.Level.GetLayer<MapLayer>().GameObjectManager.GetGameObjectById("bouncer").GetComponent<Position>().Teleport(448, 160);
            });

            Message message111112 = new Message("That's wrong. Guess I can't let you in.");

            message1111111.Messages.Add(message11111111);
            message1111111.Messages.Add(message111112);
            message111111.Messages.Add(message1111111);
            message111111.Messages.Add(message111112);
            message11111.Messages.Add(message111111);
            message11111.Messages.Add(message111112);
            message1111.Messages.Add(message11111);
            message111.Messages.Add(message1111);
            message11.Messages.Add(message111);
            message1.Messages.Add(message11);
            Messages.Add(message1);

            Message message2 = new Message("I don't recognize you. Get out of here.");
            Messages.Add(message2);
        }
    }
}
