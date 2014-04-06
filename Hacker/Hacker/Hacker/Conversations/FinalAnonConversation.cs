using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Xna.Framework;

using Hacker.Actions;
using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Helpers;
using Hacker.Layers;
using Hacker.Managers;
using Hacker.Screens;

namespace Hacker.Conversations
{
    class FinalAnonConversation : Conversation
    {
        public FinalAnonConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            // Transformation at start of convo
            Message message1 = new Message("I've decided it's time for some company downsizing.", () =>
            {
                Player.Instance.GetComponent<AnimatedSprite>().PlayAnimation("down");
                owner.Manager.GetGameObjectById("anon").SetBooleanVariable("transform_done", true);
                return true;
            }, () =>
            {
                owner.GetComponent<Position>().Direction = Direction.Down;
                owner.AddAction(new TransformAction(owner.GetComponent<AnimatedSprite>(), GameScreen.Level.GetLayer<ObjectLayer>().GameObjectManager.GetGameObjectById("juliana").GetComponent<AnimatedSprite>(), owner));
                owner.AddAction(new ConversationAction(new FinalAnonConversation(owner, "Juliana", string.Empty)));
                SoundManager.PlayMusic("revelation");

            });

            // Rest of convo as Juliana
            Message message1a = new Message("I saw firsthand how Blackmoore's mindshare device could shatter participants' minds when I used it to draw talent from a painter. You may have seen him in the deep web, mumbling uselessly.", () =>
            {
                return owner.Manager.GetGameObjectById("anon").GetBooleanVariable("transform_done");
            }, () =>
            {
                AnimatedSprite sprite = owner.GetComponent<AnimatedSprite>();
                sprite.PlayAnimation("up");
                owner.GetComponent<Position>().Direction = Direction.Up;
            });
            Message message1b = new Message("Blackmoore tried to cover up the device's flaws by locking negative reports away in his data bank and throwing parties to impress the media.");
            Message message1c = new Message("He instructed me to hire a hacker like you to identify and patch his security holes. But with access to his account, I can now delete all evidence of Mindshare's flaws and begin my own enterprise...");
            Message message1d = new Message("Just think about it. Artists who undergo the Mindshare transferal process currently suffer short-term memory loss. What if we left them without memories of the exchange even happening?");
            Message message1e = new Message("Well, I'd end up with both the talents and the money in my pocket.", () => true, () =>
            {
                Position pos = owner.GetComponent<Position>();
                Vector2 posA = new Vector2(pos.X, pos.Y);
                Vector2 posB = new Vector2(pos.X, pos.Y - 64);
                owner.AddAction(new MoveToAction(posA, posB, 0.25));
                owner.AddAction(new ConversationAction(new FinalAnonConversation(owner, "Juliana", string.Empty)));
                owner.Manager.GetGameObjectById("anon").SetBooleanVariable("move_done", true);
            });
            
            // After Juliana moves up
            Message message1f = new Message("I'll start by eliminating Blackmoore himself, using his own device. It shouldn't be difficult, considering he jacks into it regularly. Why split profits for a product that could become my own intellectual property?", () =>
            {
                return owner.Manager.GetGameObjectById("anon").GetBooleanVariable("move_done");
            });
            Message message1g = new Message("Oh, and thank you, dear. I do appreciate your gumption in helping an anonymous hacktivist, but you really should be wary of who you trust on the internet.");
            Message message1h = new Message("Did I mention that the newest prototype of Mindshare can project a wireless electromagnetic field from any computer connected to GlobeComm? You should have obscured your IP behind a proxy, sweety.");
            Message message1i = new Message("Now hold still, this will only take a moment.", () => true, () =>
            {
                EmailHelper.SendMessage("endgame_email");
                SoundManager.PlaySound("glitchcrash", true);
                System.Windows.Forms.MessageBox.Show("You have been disconnected from GlobeComm.");
                Hacker.HackerExit();
            });

            message1h.Messages.Add(message1i);
            message1g.Messages.Add(message1h);
            message1f.Messages.Add(message1g);
            Messages.Add(message1f);
            
            message1d.Messages.Add(message1e);
            message1c.Messages.Add(message1d);
            message1b.Messages.Add(message1c);
            message1a.Messages.Add(message1b);
            Messages.Add(message1a);
            Messages.Add(message1);
        }
    }
}
