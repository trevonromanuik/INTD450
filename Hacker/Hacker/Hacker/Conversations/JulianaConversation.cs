using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.GameObjects;
using Hacker.Components;
using Hacker.Helpers;

namespace Hacker.Conversations
{
    class JulianaConversation : Conversation
    {
        public JulianaConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            Messages.Add(new Message("Mr. Blackmoore! I wasn't expecting to see you out here. Shouldn't you be inside with the investors?", () => Player.Instance.SpoofId == "blackmoore"));

            Message message1 = new Message("Wow! I adore your Jimmy-Choos! They look just like- Wait a minute...", () => Player.Instance.SpoofId == owner.Id);
            Message message11 = new Message("Did you copy my avatar!? I'm quite certain that's against server policy...");
            message1.Messages.Add(message11);
            Messages.Add(message1);

            Messages.Add(new Message("I was there once, in your shoes. Well, not those particular shoes, but you know what I mean.", () => owner.GetIntegerVariable("count") > 0));

            Message message2 = new Message("I'm Juliana Smith, a talent scout for Blackmoore Industries, and Blackmoore's right-hand lady when it comes to publicity!");
            Message message21 = new Message("Sometimes people are blessed with amazing talents that just go to waste due to the limited opportunities that a sustainable economy offers.");
            Message message211 = new Message("But here at Blackmoore Industries, we aim to make use of every wasted talent using the revolutionary mindshare device!");
            Message message2111 = new Message("The process is simple and painless. Both client and artist connect to the GlobeComm transferal center using the appropriate headgear.");
            Message message21111 = new Message("Then one of our operators will initiate the transfer process!");
            Message message211111 = new Message("Within seconds that talent will transfer from artist to client while the payment will transfer from the client's bank account to the artist's. Amazing, isn't it?");
            Message message2111111 = new Message("It's a shame you can't enjoy this event, sweety. It's only open to investors and employees. I should be heading in shortly, myself.", () => true, () =>
            {
                if (owner.GetBooleanVariable("sentmsg") == false)
                {
                    EmailHelper.SendMessage("readme_email");
                    owner.SetBooleanVariable("sentmsg", true);
                }
            });

            message211111.Messages.Add(message2111111);
            message21111.Messages.Add(message211111);
            message2111.Messages.Add(message21111);
            message211.Messages.Add(message2111);
            message21.Messages.Add(message211);
            message2.Messages.Add(message21);
            Messages.Add(message2);
        }
    }
}
