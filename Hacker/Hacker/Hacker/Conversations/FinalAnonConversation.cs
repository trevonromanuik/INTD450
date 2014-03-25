using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Actions;
using Hacker.Components;
using Hacker.GameObjects;

namespace Hacker.Conversations
{
    class FinalAnonConversation : Conversation
    {
        public FinalAnonConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            Message message1 = new Message("IT IS I, JULIANA, BWAHAHAHA", () =>
            {
                Player.Instance.GetComponent<AnimatedSprite>().PlayAnimation("down");
                return true;
            }, () =>
            {

            });

            // TODO: Put in the rest of the conversation, and the appearance of Juliana, and end of game stuff

            Messages.Add(message1);
        }
    }
}
