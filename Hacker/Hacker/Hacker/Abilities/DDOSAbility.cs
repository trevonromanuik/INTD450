using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.Components;
using Hacker.GameObjects;

namespace Hacker.Abilities
{
    class DDOSAbility : Ability
    {
        public DDOSAbility()
        {
            Command = "ddos";
        }

        public override string Use(string[] args)
        {
            if (args.Length != 2)
            {
                return "Invalid number of parameters";
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
                    var ddosable = npc.GetComponent<DDOSable>();
                    if (ddosable == null)
                    {
                        return "Invalid IP Address: " + args[1];
                    }
                    else
                    {
                        Player.Instance.DDOS(npc);
                        return "DDOS successful";
                    }
                }
            }
        }
    }
}
