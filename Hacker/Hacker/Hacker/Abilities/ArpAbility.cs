using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.GameObjects;

namespace Hacker.Abilities
{
    class ArpAbility : Ability
    {
        public ArpAbility()
        {
            Command = "arp";
        }

        public override string Use(string[] args)
        {
            StringBuilder s = new StringBuilder();
            if (Player.Instance.IpAddresses.Count == 0)
            {
                return "No recent IP Addresses to display";
            }
            else
            {
                s.AppendLine("Name : Internet Address");
                foreach (Tuple<string, string> ipAddress in Player.Instance.IpAddresses)
                {
                    s.AppendLine(ipAddress.Item1 + " : " + ipAddress.Item2);
                }
                return s.ToString();
            }
        }
    }
}
