using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Components;
using Hacker.Conversations;
using Hacker.Managers;

namespace Hacker.GameObjects
{
    class Npc : GameObject
    {
        public string Name { get; private set; }
        public string IpAddress { get; private set; }

        public Npc(string name, string ipAddress)
        {
            Name = name;
            IpAddress = ipAddress;
        }
    }
}
