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
    class WallTerminalConversation : Conversation
    {
        public WallTerminalConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            InputMessage message1 = new InputMessage("Please enter your three-part password as one string, each part in order of time signature.");
            Message message11 = new Message("Password Correct. Have a nice day.", () => message1.Output == /*"password"*/ "cheezew1zmnemonicw1nst0n", () => { var vaultDoor = owner.Manager.GetGameObjectById("vault_door"); owner.Manager.GameObjects.Remove(vaultDoor); });
            Message message12 = new Message("Password Incorrect.");
            message1.Messages.Add(message11);
            message1.Messages.Add(message12);
            Messages.Add(message1);
        }
    }
}
