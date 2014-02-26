using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Screens;

namespace Hacker.Abilities
{
    abstract class Ability
    {
        public string Command { get; protected set; }
        public abstract string Use(string[] args);

        protected Npc GetNpcByIp(string ip)
        {
            return GameScreen.Level.GetLayer<MapLayer>().GameObjectManager.GetNpcByIp(ip);
        }
    }
}
