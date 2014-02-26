using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.GameObjects;

namespace Hacker.Abilities
{
    class SpoofAbility : Ability
    {
        public SpoofAbility()
        {
            Command = "spoof";
        }

        public override string Use(string[] args)
        {
            if (args.Length != 2)
            {
                return "Invalid number of parameters";
            }
            else if (args[1] == "reset")
            {
                Player.Instance.SpoofReset();
                return "Spoof reset successful";
            }
            else
            {
                Npc npc = GetNpcByIp(args[1]);
                if (npc == null)
                {
                    return "Unknown IP Address: " + args[1];
                }
                else
                {
                    Player.Instance.Spoof(npc);
                    return "Spoof successful";
                }
            }
        }
    }
}
