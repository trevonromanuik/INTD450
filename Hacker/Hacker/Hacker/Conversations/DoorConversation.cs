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
using Hacker.Managers;
using Hacker.Screens;

namespace Hacker.Conversations
{
    class DoorConversation : Conversation
    {
        public DoorConversation(GameObject owner)
            : base(owner, "Door", string.Empty)
        {
            Message message1 = new Message("Hello Mr. Blackmoore. Please answer the security questions to open the door.", () => Player.Instance.SpoofId == "blackmoore");
            InputMessage message11111 = new InputMessage("First question: what is your favorite food?");
            InputMessage message111111 = new InputMessage("Correct. Second question: what is your first dog's name?", () => message11111.Output == "caviar");
            InputMessage message1111111 = new InputMessage("Correct. Final question: what is your mother's maiden name?", () => message111111.Output == "winston");
            Message message11111111 = new Message("Correct. Door unlocked.", () => message1111111.Output == "rockefeller", () =>
            {
                owner.GetComponent<Sprite>().Texture = AssetManager.LoadTexture("metal_door_open");
                owner.RemoveComponent<ConversationInteraction>();
                owner.RemoveComponent<MovementCollision>();
                owner.AddComponent(new LevelSwitchCollision<ClubOfficeLevel>(new Vector2(320, 400)));
            });

            Message message111112 = new Message("Incorrect. Please try again.");

            message1111111.Messages.Add(message11111111);
            message1111111.Messages.Add(message111112);
            message111111.Messages.Add(message1111111);
            message111111.Messages.Add(message111112);
            message11111.Messages.Add(message111111);
            message11111.Messages.Add(message111112);
            message1.Messages.Add(message11111);
            Messages.Add(message1);

            Messages.Add(new Message("Door locked. Only Blackmoore may unlock it."));
        }
    }
}
