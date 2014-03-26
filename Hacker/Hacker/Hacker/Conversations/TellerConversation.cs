using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Actions;
using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Managers;
using Hacker.Screens;

namespace Hacker.Conversations
{
    class TellerConversation : Conversation
    {
        public TellerConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            Message message2 = new Message("Ah, Mr. Blackmoore! Always a pleasure. Here to access your account I presume? Right this way!", () => Player.Instance.SpoofId == "blackmoore", () => { var door = owner.Manager.GetGameObjectById("door"); door.GetComponent<Sprite>().Texture = AssetManager.LoadTexture("door_open"); door.RemoveComponent<MovementCollision>(); door.SetBooleanVariable("open", true); });
            Messages.Add(message2);

            // If spoofing Juliana
            Messages.Add(new Message("Oh, Miss Juliana. We appreciate the business that your coworker, Mr. Blackmoore, does with us.", () => Player.Instance.SpoofId == "juliana"));

            Message message1 = new Message("Welcome to the data bank. Sorry, but we are not accepting new members at this time. Only members with existing accounts may enter.");
            Messages.Add(message1);
        }
    }
}
