using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Levels;
using Hacker.Screens;

namespace Hacker.Conversations
{
    class OfficeTerminalConversation : Conversation
    {
        public OfficeTerminalConversation(GameObject owner, string name, string ipAddress)
            : base(owner, name, ipAddress)
        {
            Messages.Add(new Message("Your confidential files are stored in Data Bank vault #3266845875.", () => Player.Instance.GameCompleteState == GameCompleteState.ClubComplete));

            Message message1 = new Message("Welcome, Mr. Blackmoore.");
            Message message11 = new Message("Your upcoming itinerary for the day includes:\n"+
                                            "11am - Mindshare Investor and Employee Yacht Event\n"+
                                            "3:30pm - Schedule routine Data Bank password update\n"+
                                            "8pm - Benefit dinner with Hartington Institute [CANCELLED]");
            Message message111 = new Message("Sticky Reminder: Your confidential files are stored in Data Bank vault #3266845875. Don't forget to schedule the next three week's routine password updates.", () => true, () =>
            {
                Player.Instance.GameCompleteState = GameCompleteState.ClubComplete;
            });
            message1.Messages.Add(message11);
            message11.Messages.Add(message111);
            Messages.Add(message1);
        }
    }
}
