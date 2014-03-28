using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.Components;
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
                    var spoofable = npc.GetComponent<Spoofable>();
                    if (spoofable == null)
                    {
                        return "Unable to spoof IP address: " + args[1] + ". This user has spoof counter-measure software enabled.";
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
}
