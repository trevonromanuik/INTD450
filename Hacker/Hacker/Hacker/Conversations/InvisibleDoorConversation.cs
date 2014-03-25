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
    class InvisibleDoorConversation : Conversation
    {
        public InvisibleDoorConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            // Leftmost door
            Messages.Add(new Message("What? Codes: I'm not here. Come back when I'm not busy playing Titanfall.", () => Player.Instance.GetComponent<Position>().X < 350));

            // Middle door
            Messages.Add(new Message("DOS->BOSS: CLZD. Open on Australian time only.", () => Player.Instance.GetComponent<Position>().X < 500));

            // Rightmost (Cipher) door
            Messages.Add(new Message("The Cipher Cave: Welcome, come on in!", () => true, () =>
                {
                    GameScreen.LoadLevel<CipherStoreLevel>(new FadeTransition(new Vector2(320, 320)));
                }));
        }
    }
}
