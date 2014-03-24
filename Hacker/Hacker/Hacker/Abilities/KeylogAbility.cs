using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.Components;
using Hacker.GameObjects;

namespace Hacker.Abilities
{
    class KeylogAbility : Ability
    {
        public KeylogAbility()
        {
            Command = "keylog";
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
                    var keyloggable = npc.GetComponent<Keyloggable>();
                    if (keyloggable == null)
                    {
                        return "Unable to keylog IP address: " + args[1];
                    }
                    else
                    {
                        Player.Instance.Keylog(npc);
                        return "Keylog successful. Please wait for keylog output to 'GlobeComm Deliveries/Keylogs'.";
                    }
                }
            }
        }
    }
}
